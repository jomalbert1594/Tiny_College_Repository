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
using TinyCollege.Models.Class;
using TinyCollege.Models.Professor;
using TinyCollege.Views.Professor;

namespace TinyCollege.Modules
{
    public class ProfessorModule:ObservableObject
    {
        private IRepository _repository;

        public ProfessorModule(IRepository repository)
        {
            _repository = repository;
            ProfessorLoading = NotifyTaskCompletion.Create(() => LoadProfessorsAsync());
        }

        public ObservableCollection<ProfessorModel> ProfessorList { get; } = new ObservableCollection<ProfessorModel>();
        private ProfessorModel _selectedProfessor;

        public ProfessorModel SelectedProfessor
        {
            get { return _selectedProfessor; }
            set
            {
                _selectedProfessor = value;
                RaisePropertyChanged(nameof(SelectedProfessor));
            }
        }

        public INotifyTaskCompletion ProfessorLoading { get; private set; }

        public async Task LoadProfessorsAsync()
        {
            var professors = await _repository.Professor.GetRangeAsync(CancellationToken.None);
            foreach (var professor in professors)
            {
                var professormodel = new ProfessorModel(professor, _repository);
                professormodel.LoadRelatedInfo();
                ProfessorList.Add(professormodel);
                await Task.Delay(100);
            }

        }

        private ProfessorNewModel _newProfessor;

        public ProfessorNewModel NewProfessor
        {
            get { return _newProfessor; }
            set
            {
                _newProfessor = value;
                RaisePropertyChanged(nameof(NewProfessor));
            }
        }

        public ICommand AddProfCommand => new RelayCommand(AddProfProc);
        private ProfessorAddingWindow _professorAddingWindow;
        private void AddProfProc()
        {
            NewProfessor?.Dispose();
            NewProfessor = new ProfessorNewModel();
            _professorAddingWindow = new ProfessorAddingWindow { Owner = Application.Current.MainWindow };
            _professorAddingWindow.ShowDialog();
        }


        public ICommand SaveProfCommand => new RelayCommand(SaveProfProc, SaveProfCondition);

        private bool SaveProfCondition()
        {
            return (NewProfessor != null) && NewProfessor.HasChanges && !NewProfessor.HasErrors;
        }

        private async Task SaveProfProcAsync()
        {
            if (NewProfessor == null) return;
            if (!NewProfessor.HasChanges) return;

            if (NewProfessor.ModelCopy.DepartmentId == null)
            {
                MessageBox.Show("Department is a required field!", "Add Professor", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            try
            {
                NewProfessor.CurrentUnits = 0;
                NewProfessor.NoOfSubjects = 0;
                await _repository.Professor.AddAsync(NewProfessor.ModelCopy, CancellationToken.None);
                ProfessorList.Add(new ProfessorModel(NewProfessor.ModelCopy, _repository));
                _professorAddingWindow.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to Save!", "Add Professor");
            }
        }
        private async void SaveProfProc()
        {
            await SaveProfProcAsync();
        }

        public ICommand CancelProfCommand => new RelayCommand(CancelProcProf);

        private void CancelProcProf()
        {
            NewProfessor?.Dispose();
        }

        public ICommand DeleteProfCommand => new RelayCommand(DeleteProfProc, DeleteProfCondition);

        private bool DeleteProfCondition()
        {
            return (SelectedProfessor != null);
        }

        private async void DeleteProfProc()
        {
            await DeleteProfProcAsync();
        }

        private async Task DeleteProfProcAsync()
        {
            if(SelectedProfessor == null)return;

            try
            {
                await _repository.Professor.RemoveAsync(SelectedProfessor.Model, CancellationToken.None);
                ProfessorList.Remove(SelectedProfessor);
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to Delete", "Delete Professor", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
