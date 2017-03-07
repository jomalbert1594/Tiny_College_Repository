using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Nito.AsyncEx;
using TinyCollege.DataAccess;
using TinyCollege.Models.School;
using TinyCollege.Views.School;

namespace TinyCollege.Modules
{
    public class SchoolModule:ObservableObject
    {
        private IRepository _repository;

        public SchoolModule(IRepository repository)
        {
            _repository = repository;
            SchoolLoading = NotifyTaskCompletion.Create(() => LoadSchoolsAsync());
        }

        public ObservableCollection<SchoolModel> SchoolList { get; } = new ObservableCollection<SchoolModel>();

        private SchoolModel _selectedSchool;
        public SchoolModel SelectedSchool
        {
            get { return _selectedSchool; }
            set
            {
                _selectedSchool = value;
                if (value != null)
                {
                    _selectedSchool.LoadRelatedInfo();
                }
                RaisePropertyChanged(nameof(SelectedSchool));
            }
        }

        private async Task LoadSchoolsAsync()
        {
            var schools = await _repository.School.GetRangeAsync(CancellationToken.None);
            SchoolList.Clear();
            foreach (var school in schools)
            {
                var schoolmodel = new SchoolModel(school, _repository);
                schoolmodel.LoadRelatedInfo();
                SchoolList.Add(schoolmodel);
                await Task.Delay(100);
            }
        }

        public INotifyTaskCompletion SchoolLoading { get; private set; }

        private SchoolNewModel _newSchool;
        public SchoolNewModel NewSchool
        {
            get { return _newSchool;}
            set
            {
                _newSchool = value;
                RaisePropertyChanged(nameof(NewSchool));
            }
        }

        public ICommand AddSchoolCommand => new RelayCommand(AddSchoolProc);

        private SchoolAddingWindow _schooAddingWind;
        private void AddSchoolProc()
        {
            NewSchool?.Dispose();
            NewSchool = new SchoolNewModel();
            _schooAddingWind = new SchoolAddingWindow();
            _schooAddingWind.Owner = Application.Current.MainWindow;
            _schooAddingWind.Show();
        }

        public ICommand SaveSchoolCommand => new RelayCommand(SaveSchoolProc, SaveSchoolCondition);

        private bool SaveSchoolCondition()
        {
            return (NewSchool != null) && NewSchool.HasChanges && !NewSchool.HasErrors;
        }

        private async Task SaveSchoolProcAsync()
        {
            if (NewSchool == null) return;
            if (!NewSchool.HasChanges) return;
            try
            {
                try
                {
                    var professormodel = ViewModelLocatorStatic.Locator.ProfessorModule.ProfessorList.FirstOrDefault(p => p.Model.ProfessorId == NewSchool.ProfessorId);
                    if (professormodel.Department.Model.SchoolId != SelectedSchool.Model.SchoolId)
                    {
                        MessageBox.Show("The Department of the chosen Dean does not belong in this School!",
                            "Add School Dean", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        return;
                    }
                    professormodel.Model = NewSchool.Professor.Model;
                    professormodel.Model.IsSchoolHead = true;
                    await _repository.Professor.UpdateAsync(professormodel.Model, CancellationToken.None);
                }
                catch (Exception e) { }

                await _repository.School.AddAsync(NewSchool.ModelCopy, CancellationToken.None);
                SchoolList.Add(new SchoolModel(NewSchool.ModelCopy, _repository));
                _schooAddingWind.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to Save!", "Add School");
            }
        }

        private async void SaveSchoolProc()
        {
            await SaveSchoolProcAsync();
        }

        public ICommand CancelSchoolCommand => new RelayCommand(CancelSchoolProc);

        private void CancelSchoolProc()
        {
            NewSchool?.Dispose();
            _schooAddingWind.Close();
        }

        public ICommand DeleteSchoolCommmand => new RelayCommand(DeleteSchoolProc, DeleteSchoolCondition);

        private bool DeleteSchoolCondition()
        {
            return (SelectedSchool != null);
        }

        private async Task DeleteSchoolProcAsync()
        {
            if (SelectedSchool == null) return;
            try
            {
                var professormodel = SelectedSchool.Professor.Model;
                professormodel.IsSchoolHead = false;
                await _repository.Professor.UpdateAsync(professormodel, CancellationToken.None);
                await _repository.School.RemoveAsync(SelectedSchool.Model, CancellationToken.None);
                SchoolList.Remove(SelectedSchool);
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to Delete", "Delete School", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void DeleteSchoolProc()
        {
            await DeleteSchoolProcAsync();
        }
    }
}
    