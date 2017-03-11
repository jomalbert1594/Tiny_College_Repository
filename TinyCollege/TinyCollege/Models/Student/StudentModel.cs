using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using TinyCollege.DataAccess;
using TinyCollege.Models.Class;
using TinyCollege.Models.Department;
using TinyCollege.Models.Enrollment;
using TinyCollege.Models.Grade;

namespace TinyCollege.Models.Student
{
    public class StudentModel : ModelBase<DataAccess.Ef.Student>, IEditable<DataAccess.Ef.Student>
    {
        public StudentModel(DataAccess.Ef.Student model, IRepository repository) : base(model, repository)
        {
        }

        // RelatedModels
        public ObservableCollection<EnrollmentModel> Enrollments { get; } = new ObservableCollection<EnrollmentModel>();
        public ObservableCollection<GradeModel> Grades { get; } = new ObservableCollection<GradeModel>(); 

        private EnrollmentModel _enrollment;

        public EnrollmentModel Enrollment
        {
            get { return _enrollment; }
            set
            {
                //_enrollment = value;
                RaisePropertyChanged(nameof(Enrollment));
            }
        }

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

        private GradeModel _grade;
        public GradeModel Grade
        {
            get { return _grade; }
            set
            {
                _grade = value;
                RaisePropertyChanged(nameof(Grade));
            }
        }

        private async Task LoadDepartmentAsync()
        {
            var department = await Task.Run(() => _Repository.Department.GetAsync(d => d.DepartmentId == Model.DepartmentId, CancellationToken.None));
            Department = new DepartmentModel(department, _Repository);
        }

        private async Task LoadRelatedInfoAsync()
        {
            Enrollments.Clear();
            Grades.Clear();
            var enrollments = await Task.Run(() => _Repository.Enrollment.GetRangeAsync(e => e.StudentId == Model.StudentId,CancellationToken.None));

            foreach (var enrollment in enrollments)
            {
                var grade = new DataAccess.Ef.Grade();
                try
                {
                    grade = await Task.Run(() => _Repository.Grade.GetAsync(g => g.EnrollmentId == enrollment.EnrollmentId, CancellationToken.None)); 
                }
                catch(Exception e) { }
                var enrollmentmodel = new EnrollmentModel(enrollment, _Repository);
                var grademodel = new GradeModel(grade, _Repository);
                grademodel.LoadRelatedInfo();
                enrollmentmodel.LoadRelatedInfo();
                Enrollments.Add(enrollmentmodel);
                Grades.Add(grademodel);
                await Task.Delay(100);
            }
        }

        public async void LoadDepartment()
        {
            await LoadDepartmentAsync();
        }

        public async void LoadRelatedInfo()
        {
            LoadDepartment();
            await LoadRelatedInfoAsync();
        }


        // Attributes and Methods
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

        private EditModelBase<DataAccess.Ef.Student> _editModel;

        public EditModelBase<DataAccess.Ef.Student> EditModel
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
                await _Repository.Student.UpdateAsync(EditModel.ModelCopy, CancellationToken.None);
                Model = EditModel.ModelCopy;
                LoadDepartment();
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
            EditModel = new StudentEditModel(Model);
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
