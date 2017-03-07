using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
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
using TinyCollege.Models.Department;
using TinyCollege.Models.Professor;
using TinyCollege.Views.Department;

namespace TinyCollege.Modules
{
    public class DepartmentModule:ObservableObject
    {
        private IRepository _repository;
        public DepartmentModule(IRepository repository)
        {
            _repository = repository;
            DepartmentLoading = NotifyTaskCompletion.Create(() => LoadDepartments());
        }

        public ObservableCollection<DepartmentModel> DepartmentList { get; } = new ObservableCollection<DepartmentModel>();
        private DepartmentModel _selectedDepartment;

        public DepartmentModel SelectedDepartment
        {
            get { return _selectedDepartment;}
            set
            {
                _selectedDepartment = value;
                if (value != null)
                {
                    _selectedDepartment.LoadRelatedInfo();
                }
                RaisePropertyChanged(nameof(SelectedDepartment));
            }
        }

        private ProfessorEditModel _professorEditModel;

        public ProfessorEditModel ProfessorEditModel
        {
            get { return _professorEditModel; }
            set
            {
                _professorEditModel = value;
                RaisePropertyChanged(nameof(ProfessorEditModel));
            }
        }

        public INotifyTaskCompletion DepartmentLoading { get; set; }

        private async Task LoadDepartments()
        {
            var departments = await _repository.Department.GetRangeAsync();
            foreach (var department in departments)
            {
                var departmentmodel = new DepartmentModel(department, _repository);
                departmentmodel.LoadRelatedInfo();
                DepartmentList.Add(departmentmodel);
                await Task.Delay(100);
            }
        }

        private DepartmentNewModel _newDepartment;
        public DepartmentNewModel NewDepartment
        {
            get { return _newDepartment;}
            set
            {
                _newDepartment = value;
                RaisePropertyChanged(nameof(NewDepartment));
            }
        }

        public ICommand AddDepartmentCommand => new RelayCommand(AddDepartmentProc);

        private AddingDepartmentWindow _addDeptWindow;
        private void AddDepartmentProc()
        {
            NewDepartment?.Dispose();
            NewDepartment = new DepartmentNewModel();
            _addDeptWindow = new AddingDepartmentWindow {Owner = Application.Current.MainWindow};
            _addDeptWindow.ShowDialog();
        }

        public ICommand SaveDepartmentCommand => new RelayCommand(SaveDepartmentProc, SaveDepartmentCondition);
        
        private bool SaveDepartmentCondition()
        {
            return (NewDepartment != null) && NewDepartment.HasChanges && !NewDepartment.HasErrors;
        }

        private async Task SaveDepartmentProcAsync()
        {
            if (NewDepartment == null) return;
            if (!NewDepartment.HasChanges) return;
            try
            {
                var professor = await _repository.Professor.GetAsync(p => p.ProfessorId == NewDepartment.ProfessorId, CancellationToken.None);
                var professorModel = ViewModelLocatorStatic.Locator.ProfessorModule.ProfessorList.FirstOrDefault(p => p.Model.ProfessorId == professor.ProfessorId);
                ProfessorEditModel = new ProfessorEditModel(professor)
                {
                    DepartmentId = NewDepartment.ModelCopy.DepartmentId,
                    IsDepartmentHead = true,
                    IsSchoolHead = false
                };
                professorModel.Model = ProfessorEditModel.ModelCopy;
                await _repository.Professor.UpdateAsync(ProfessorEditModel.ModelCopy, CancellationToken.None);
                await _repository.Department.AddAsync(NewDepartment.ModelCopy, CancellationToken.None);
                DepartmentList.Add(new DepartmentModel(NewDepartment.ModelCopy, _repository));
                _addDeptWindow.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to Save!", "Add Deparmtent");
            }
        }

        private async void SaveDepartmentProc()
        {
            await SaveDepartmentProcAsync();
        }

        public ICommand DeleteDepartmentCommand => new RelayCommand(DeleteDepartmentProc, DeleteDepartmentCondition);

        private bool DeleteDepartmentCondition()
        {
            return (SelectedDepartment != null);
        }

        private async Task DeleteDepartmentProcAsync()
        {
            try
            {
                await _repository.Department.RemoveAsync(SelectedDepartment.Model, CancellationToken.None);
                DepartmentList.Remove(SelectedDepartment);
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to Delete!", "Delete Department", MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
            }
        }

        private async void DeleteDepartmentProc()
        {
            await DeleteDepartmentProcAsync();
        }

        public ICommand CancelDepartmentCommand => new RelayCommand(CancelDepartmentProc);

        private void CancelDepartmentProc()
        {
            NewDepartment?.Dispose();
            _addDeptWindow.Close();
        }
    }
}
