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
using Microsoft.Reporting.WebForms;
using TinyCollege.DataAccess;
using TinyCollege.Models.Course;
using TinyCollege.Models.Enrollment;
using TinyCollege.Models.Grade;
using TinyCollege.Models.Professor;
using TinyCollege.Models.Room;
using TinyCollege.Models.Student;

namespace TinyCollege.Models.Class
{
    public class ClassModel : ModelBase<DataAccess.Ef.Class>, IEditable<DataAccess.Ef.Class>
    {
        public ClassModel(DataAccess.Ef.Class model, IRepository repository) : base(model, repository)
        {

        }

        public ObservableCollection<EnrollmentModel> Enrollments { get; } = new ObservableCollection<EnrollmentModel>();
        public ObservableCollection<StudentModel> Students { get; } = new ObservableCollection<StudentModel>();
        public ObservableCollection<GradeEditModel> EditClassesGrades { get; } = new ObservableCollection<GradeEditModel>();

        // Related Models
        private ProfessorModel _professor;
        private RoomModel _room;
        private CourseModel _course;
        private StudentModel _selectedStudent;


        private bool _isGradeEditing;

        public bool IsGradeEditing
        {
            get { return _isGradeEditing; }
            set
            {
                _isGradeEditing = value;
                RaisePropertyChanged(nameof(IsGradeEditing));
            }
        }

        public StudentModel SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
                RaisePropertyChanged(nameof(SelectedStudent));
            }
        }

        public ProfessorModel Professor
        {
            get { return _professor; }
            set
            {
                _professor = value;
                RaisePropertyChanged(nameof(Professor));
            }
        }

        public RoomModel Room
        {
            get { return _room; }
            set
            {
                _room = value;
                RaisePropertyChanged(nameof(Room));
            }
        }

        public CourseModel Course
        {
            get { return _course; }
            set
            {
                _course = value;
                RaisePropertyChanged(nameof(Course));
            }
        }

        private async Task LoadrelatedInfoAsync()
        {
            var professor = await Task.Run(() => _Repository.Professor.GetAsync(p => p.ProfessorId == Model.ProfessorId, CancellationToken.None));
            Professor = new ProfessorModel(professor, _Repository);

            var room = await Task.Run(() => _Repository.Room.GetAsync(r => r.RoomId == Model.RoomId, CancellationToken.None)); 
            Room = new RoomModel(room, _Repository);

            var course = await Task.Run(() => _Repository.Course.GetAsync(c => c.CourseId == Model.CourseId, CancellationToken.None));
            Course = new CourseModel(course, _Repository);
            Course.LoadRelatedInfo();

            var enrollments = await Task.Run(() => _Repository.Enrollment.GetRangeAsync(e => e.ClassId == Model.ClassId, CancellationToken.None));
            Enrollments.Clear();

            var classEnrollments = await Task.Run(() => _Repository.Enrollment.GetRangeAsync(c => c.ClassId == Model.ClassId, CancellationToken.None));
            // Gets all class Enrollments involving a class
            Students.Clear();
            foreach (var enrollment in classEnrollments) // Gets all the students involving a class
            {
                var student = await Task.Run(() => _Repository.Student.GetAsync(s => s.StudentId == enrollment.StudentId, CancellationToken.None));
                var studentModel = new StudentModel(student, _Repository);
                studentModel.LoadDepartment();
                var grade = await Task.Run(() => _Repository.Grade.GetAsync(g => g.EnrollmentId == enrollment.EnrollmentId, CancellationToken.None));
                studentModel.Grade = new GradeModel(grade, _Repository); // Load the grade of the student
                studentModel.Enrollment = new EnrollmentModel(enrollment, _Repository);
                Students.Add(studentModel);
                await Task.Delay(100);
            }

            foreach (var enrollment in enrollments)
            {
                Enrollments.Add(new EnrollmentModel(enrollment, _Repository));
                await Task.Delay(100);
            }

        }

        public async void LoadRelatedInfo()
        {
            await LoadrelatedInfoAsync();
        }

        // Attributes
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


        private EditModelBase<DataAccess.Ef.Class> _editModel;

        public EditModelBase<DataAccess.Ef.Class> EditModel
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
                await _Repository.Class.UpdateAsync(EditModel.ModelCopy, CancellationToken.None);
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
            await SaveProcAsync();
        }

        public ICommand EditCommand => new RelayCommand(EditProc);

        private void EditProc()
        {
            EditModel?.Dispose();
            EditModel = new ClassEditModel(Model);
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
