using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using TinyCollege.DataAccess;
using TinyCollege.Models.Department;
using TinyCollege.Models.Professor;
using TinyCollege.Models.Student;

namespace TinyCollege.Models.School
{
    public class SchoolModel:ModelBase<DataAccess.Ef.School>, IEditable<DataAccess.Ef.School>
    {
        public SchoolModel(DataAccess.Ef.School model, IRepository repository) : base(model, repository)
        {
        }

        public ObservableCollection<DepartmentModel> DepartmentList { get; } = new ObservableCollection<DepartmentModel>();

        private ProfessorModel _professor;
        public ProfessorModel Professor
        {
            get { return _professor; }
            set
            {
                _professor = value;
                RaisePropertyChanged(nameof(Professor));
            }
        }

        private async Task LoadRelatedInfoAsync()
        {
            var departments = await _Repository.Department.GetRangeAsync(d => d.SchoolId == Model.SchoolId, CancellationToken.None);
            DepartmentList.Clear();
            foreach (var department in departments)
            {
                var departmentmodel = new DepartmentModel(department, _Repository);
                departmentmodel.LoadRelatedInfo();
                DepartmentList.Add(departmentmodel);
                await Task.Delay(100);
            }

            var professor = await _Repository.Professor.GetAsync(p => p.ProfessorId == Model.ProfessorId, CancellationToken.None);
            Professor = new ProfessorModel(professor, _Repository);
        }

        public async void LoadRelatedInfo()
        {
            await LoadRelatedInfoAsync();
        }
        private bool _isEditing;
        public bool IsEditing
        {
            get { return _isEditing; }
            set
            {
                _isEditing = value;
                RaisePropertyChanged(nameof(IsEditing));
            }
        }

        private EditModelBase<DataAccess.Ef.School> _editModel;

        public EditModelBase<DataAccess.Ef.School> EditModel
        {
            get { return _editModel; }
            set
            {
                _editModel = value;
                RaisePropertyChanged(nameof(EditModel));
            }
        }
        public ICommand SaveCommand => new RelayCommand(SaveProc, SaveCondition);

        private bool SaveCondition()
        {
            return (EditModel != null) && EditModel.HasChanges && !EditModel.HasErrors;
        }

        private async Task SaveProcAsync()
        {
            if (EditModel == null) return;
            if (!EditModel.HasChanges) return;
            try
            {
                await _Repository.School.UpdateAsync(EditModel.ModelCopy, CancellationToken.None);
                Model = EditModel.ModelCopy;
                IsEditing = false;
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to Save!", "Student Update");
            }
        }

        private async void SaveProc()
        {
            await SaveProcAsync();
        }

        public ICommand EditCommand => new RelayCommand(EditProc);

        private void EditProc()
        {
            EditModel?.Dispose();
            EditModel = new SchoolEditModel(Model);
            IsEditing = true;
        }

        public ICommand CancelCommand => new RelayCommand(CancelProc);

        private void CancelProc()
        {
            EditModel?.Dispose();
            IsEditing = false;
        }
    }
}
