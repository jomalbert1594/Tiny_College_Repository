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
using Nito.AsyncEx;
using TinyCollege.DataAccess;
using TinyCollege.Models.Class;
using TinyCollege.Models.Department;
using TinyCollege.Models.Professor;

namespace TinyCollege.Models.Course
{
    public class CourseModel:ModelBase<DataAccess.Ef.Course>, IEditable<DataAccess.Ef.Course>
    {
        public CourseModel(DataAccess.Ef.Course model, IRepository repository) : base(model, repository)
        {
        }

        public ObservableCollection<ProfessorModel> ProfessorList { get; } = new ObservableCollection<ProfessorModel>();
        
        private DepartmentModel _department;
        public DepartmentModel Department
        {
            get { return _department; }
            set
            {
                _department = value;
                RaisePropertyChanged(nameof(Department));
            }
        }

        private async Task LoadRelatedInfoAsync()
        {

            var department = await Task.Run(() => _Repository.Department.GetAsync(d => d.DepartmentId == Model.DepartmentId, CancellationToken.None));
            Department = new DepartmentModel(department, _Repository);

            var classes = await Task.Run(() => _Repository.Class.GetRangeAsync(c => c.CourseId == Model.CourseId, CancellationToken.None));
            ProfessorList.Clear();
            foreach (var item in classes)
            {
                if (item.ProfessorId == null) continue;
                var professor = await Task.Run(() => _Repository.Professor.GetAsync(p => p.ProfessorId == item.ProfessorId, CancellationToken.None));
                var professormodel = new ProfessorModel(professor, _Repository);
                if (ProfessorList.Contains(professormodel)) continue;
                var profdepartment =
                    await Task.Run(() => _Repository.Department.GetAsync(d => d.DepartmentId == professormodel.Model.DepartmentId, CancellationToken.None));
                professormodel.Model.Department = profdepartment;
                ProfessorList.Add(new ProfessorModel(professor, _Repository));
                await Task.Delay(100);
            }
        }
            
        public void LoadRelatedInfo()
        {
            NotifyTaskCompletion.Create(() => LoadRelatedInfoAsync());

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

        private EditModelBase<DataAccess.Ef.Course> _editModel;
        public EditModelBase<DataAccess.Ef.Course> EditModel
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
                await Task.Run(() => _Repository.Course.UpdateAsync(EditModel.ModelCopy));
                Model = EditModel.ModelCopy;
                LoadRelatedInfo();
                IsEditing = false;
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to Save!", "Student Update");
            }
        }

        private async void SaveProc()
        {
            NotifyTaskCompletion.Create(() => SaveProcAsync());

        }

        public ICommand EditCommand => new RelayCommand(EditProc);

        private void EditProc()
        {
            EditModel?.Dispose();
            EditModel = new CourseEditModel(Model);
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
