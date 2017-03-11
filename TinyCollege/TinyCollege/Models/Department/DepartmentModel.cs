using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using Nito.AsyncEx;
using TinyCollege.DataAccess;
using TinyCollege.Models.Enrollment;
using TinyCollege.Models.Professor;
using TinyCollege.Models.School;
using TinyCollege.Models.Student;
using TinyCollege.Modules;

namespace TinyCollege.Models.Department
{
    public class DepartmentModel:ModelBase<DataAccess.Ef.Department>, IEditable<DataAccess.Ef.Department>
    {

        public DepartmentModel(DataAccess.Ef.Department model, IRepository repository) : base(model, repository)
        {
        }


        public ObservableCollection<StudentModel> Students { get; } = new ObservableCollection<StudentModel>();
        public ObservableCollection<ProfessorModel> Professors { get; } = new ObservableCollection<ProfessorModel>();

        private ProfessorModel _departmentHead;
        public ProfessorModel DepartmentHead
        {
            get { return _departmentHead; }
            set
            {
                _departmentHead = value;
                RaisePropertyChanged(nameof(DepartmentHead));
            }
        }

        private SchoolModel _school;
        public SchoolModel School
        {
            get { return _school; }
            set
            {
                _school = value;
                RaisePropertyChanged(nameof(School));
            }
        }

        private async Task LoadRelatedInfoAsync()
        {
            var school = await Task.Run(() => _Repository.School.GetAsync(s => s.SchoolId == Model.SchoolId, CancellationToken.None));
            School = new SchoolModel(school, _Repository);

            var departmenthead = await Task.Run(() => _Repository.Professor.GetAsync(p => p.DepartmentId == Model.DepartmentId && p.IsDepartmentHead, CancellationToken.None));
            DepartmentHead = new ProfessorModel(departmenthead, _Repository);

            var professors =
                await Task.Run(() => _Repository.Professor.GetRangeAsync(p => p.DepartmentId == Model.DepartmentId && !p.IsDepartmentHead, CancellationToken.None));
            Professors.Clear();
            foreach (var professor in professors)
            {
                Professors.Add(new ProfessorModel(professor, _Repository));
                await Task.Delay(100);
            }

            var students = await Task.Run(() => _Repository.Student.GetRangeAsync(s => s.DepartmentId == Model.DepartmentId, CancellationToken.None));
            Students.Clear();
            foreach (var student in students)
            {
                Students.Add(new StudentModel(student, _Repository));
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

        private ProfessorEditModel _professorEditModel;
        public ProfessorEditModel ProfessorEditModel
        {
            get { return _professorEditModel;}
            set
            {
                _professorEditModel = value;
                RaisePropertyChanged(nameof(ProfessorEditModel));
            }
        }

        private EditModelBase<DataAccess.Ef.Department> _editModel;

        public EditModelBase<DataAccess.Ef.Department> EditModel
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

                if (Model.ProfessorId != null)
                {
                    var previousHead = await Task.Run(() => _Repository.Professor.GetAsync(p => p.ProfessorId == Model.ProfessorId, CancellationToken.None));
                    var previousHeadModel =
                        ViewModelLocatorStatic.Locator.ProfessorModule.ProfessorList.FirstOrDefault(
                            p => p.Model.ProfessorId == Model.ProfessorId);
                    var previousHeadEditModel = new ProfessorEditModel(previousHead)
                    {
                        IsDepartmentHead = false,
                        IsSchoolHead = false
                    };

                    await Task.Run(() => _Repository.Professor.UpdateAsync(previousHeadEditModel.ModelCopy, CancellationToken.None)); 
                    previousHeadModel.Model = previousHeadEditModel.ModelCopy;

                }

                try
                {
                    var professor = await Task.Run(() => _Repository.Professor.GetAsync(p => p.ProfessorId == EditModel.ModelCopy.ProfessorId, CancellationToken.None));
                    var headModel = ViewModelLocatorStatic.Locator.ProfessorModule.ProfessorList.FirstOrDefault(p => p.Model.ProfessorId == professor.ProfessorId);
                    ProfessorEditModel = new ProfessorEditModel(professor)
                    {
                        DepartmentId = Model.DepartmentId,
                        IsSchoolHead = false,
                        IsDepartmentHead = true
                    };
                    headModel.Model = ProfessorEditModel.ModelCopy;
                    await Task.Run(() => _Repository.Professor.UpdateAsync(headModel.Model, CancellationToken.None));
                }
                catch (Exception e) { }


                await Task.Run(() => _Repository.Department.UpdateAsync(EditModel.ModelCopy, CancellationToken.None));
                Model = EditModel.ModelCopy;
                LoadRelatedInfo();
                IsEditing = false;
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to Save!", "Student Update");
            }
        }
        
        private void SaveProc()
        {
            NotifyTaskCompletion.Create(() => SaveProcAsync());

        }

        public ICommand EditCommand => new RelayCommand(EditProc);

        private void EditProc()
        {
            EditModel?.Dispose();
            EditModel = new DepartmentEditModel(Model);
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
