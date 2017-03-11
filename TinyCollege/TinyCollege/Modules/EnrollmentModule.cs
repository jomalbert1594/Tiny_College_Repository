using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Nito.AsyncEx;
using TinyCollege.DataAccess;
using TinyCollege.DataAccess.Ef;
using TinyCollege.Models;
using TinyCollege.Models.Class;
using TinyCollege.Models.Enrollment;
using TinyCollege.Models.Grade;
using TinyCollege.Models.Student;
using TinyCollege.Reports.Student;
using TinyCollege.Views.Student;

namespace TinyCollege.Modules
{
    public class EnrollmentModule : ObservableObject
    {
        private IRepository _repository;

        public EnrollmentModule(IRepository repository)
        {
            _repository = repository;
            EnrollmentLoading = NotifyTaskCompletion.Create(() => LoadEnrollments());
        }

        public ObservableCollection<EnrollmentModel> EnrollmentList { get; } =
            new ObservableCollection<EnrollmentModel>();

        private EnrollmentModel _selectedEnrollment;
        public EnrollmentModel SelectedEnrollment
        {
            get { return _selectedEnrollment; }
            set
            {
                _selectedEnrollment = value;
                RaisePropertyChanged(nameof(SelectedEnrollment));
            }
        }

        private EnrollmentNewModel _newEnrollment;
        public EnrollmentNewModel NewEnrollment
        {
            get { return _newEnrollment; }
            set
            {
                _newEnrollment = value;
                RaisePropertyChanged(nameof(NewEnrollment));
            }
        }

        private StudentEditModel _studentEditmodel;
        public StudentEditModel StudentEditModel
        {
            get { return _studentEditmodel; }
            set
            {
                _studentEditmodel = value;
                RaisePropertyChanged(nameof(StudentEditModel));
            }
        }

        private StudentModel _selectedStudent;
        public StudentModel SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
                if (value != null)
                {
                    _selectedStudent.LoadRelatedInfo();
                }
                RaisePropertyChanged(nameof(SelectedStudent));
            }
        }

        private ClassModel _selectedClass;
        public ClassModel SelectedClass
        {
            get { return _selectedClass;}
            set
            {
                _selectedClass = value;
                if (value != null)
                {
                    _selectedClass.LoadRelatedInfo();
                    NewEnrollment.ClassId = SelectedClass.Model.ClassId;
                    NewEnrollment.StudentId = SelectedStudent.Model.StudentId;
                }
                RaisePropertyChanged(nameof(SelectedClass));
            }
        }

        public ICommand AddStudentEnrollmentCommand => new RelayCommand(AddStudentEnrollmentProc);

        private EnrollmentAddingWindow _enrollmentAddingWindow;
        private void AddStudentEnrollmentProc()
        {
            NewEnrollment?.Dispose();
            NewEnrollment = new EnrollmentNewModel
            {
                EnrollmentDate = DateTime.Now,         
            };
            _enrollmentAddingWindow = new EnrollmentAddingWindow {Owner = Application.Current.MainWindow};
            _enrollmentAddingWindow.ShowDialog();

        }

        public ICommand DeleteStudentCommand => new RelayCommand(DeleteStudentProc, DeleteCondition);

        private bool DeleteCondition()
        {
            return (SelectedStudent != null);
        }

        private async Task DeleteStudentProcAsync()
        {
            if (SelectedStudent == null) return;
                try
                {
                    await Task.Run(() => _repository.Student.RemoveAsync(SelectedStudent.Model, CancellationToken.None));
                ViewModelLocatorStatic.Locator.StudentModule.StudentList.Remove(SelectedStudent);
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to Delete", "Delete Studient", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }

        private async void DeleteStudentProc()
        {
            await DeleteStudentProcAsync();
        }

        public ICommand SaveStudentEnrollmentCommand => new RelayCommand(SaveStudentEnrollmentProc, SaveStudentEnrollmentCondition);

        private bool SaveStudentEnrollmentCondition()
        {
            return (SelectedClass != null);
        }

        private async Task SaveStudentEnrollmentProcAsync()
        {
            if (NewEnrollment == null) return;
            if (!NewEnrollment.HasChanges) return;

            var existingModel = SelectedStudent.Enrollments.FirstOrDefault(e => e.Model.ClassId == SelectedClass.Model.ClassId);
            var existingCourse =
                SelectedStudent.Enrollments.FirstOrDefault(c => c.Class.Model.CourseId == SelectedClass.Model.CourseId);

            if (existingModel != null || existingCourse != null)
            {
                MessageBox.Show("Already Enrolled!", "Add Enrollment", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (IsThereAlreadyAMajorSubject()) return;

            try
            {
                if (IsThereAConflict()) return;
                StudentEditModel = new StudentEditModel(SelectedStudent.Model);

                StudentEditModel.NoOfSubjects = StudentEditModel.NoOfSubjects + 1;
                if (StudentEditModel.NoOfSubjects > 6)
                {
                    StudentEditModel.NoOfSubjects = StudentEditModel.NoOfSubjects - 1;
                    MessageBox.Show("No. of subjects exceeds the limit!", "Add Enrollment", MessageBoxButton.OK,
                        MessageBoxImage.Exclamation);

                    return;
                }

                var enrollment = new EnrollmentModel(NewEnrollment.ModelCopy, _repository);
                enrollment.LoadRelatedInfo();

                EnrollmentList.Add(enrollment);

                SelectedStudent.Enrollments.Add(enrollment);

                if (StudentEditModel.Units == null)
                {
                    StudentEditModel.Units = 0;
                }
                StudentEditModel.Units = StudentEditModel.Units + SelectedClass.Course.Model.CourseUnits;
                enrollment.LoadRelatedInfo();

                await
                    Task.Run(() => _repository.Student.UpdateAsync(StudentEditModel.ModelCopy, CancellationToken.None));
                SelectedStudent.Model = StudentEditModel.ModelCopy;
                await Task.Run(() => _repository.Enrollment.AddAsync(NewEnrollment.ModelCopy, CancellationToken.None));
                var newgrademodel = new GradeNewModel {EnrollmentId = NewEnrollment.ModelCopy.EnrollmentId};
                await Task.Run(() => _repository.Grade.AddAsync(newgrademodel.ModelCopy, CancellationToken.None));
                var grademodel = new GradeModel(newgrademodel.ModelCopy, _repository);
                grademodel.LoadRelatedInfo();
                SelectedStudent.Grades.Add(grademodel);
                _enrollmentAddingWindow.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to Save!", "Add Enrollment", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }


        }

        private async void SaveStudentEnrollmentProc()
        {
            await SaveStudentEnrollmentProcAsync();
        }

        private bool IsThereAlreadyAMajorSubject()
        {
            var enrollments = new ObservableCollection<EnrollmentModel>();
            foreach (var enrollment in SelectedStudent.Enrollments)
            {
                enrollments.Add(enrollment);
            }

            var major =
                enrollments.FirstOrDefault(m => m.Class.Course.Model.DepartmentId == SelectedClass.Course.Model.DepartmentId);

            if (major == null) return false;
            var warning = "Current Major Subject: " + major.Class.Course.Model.CourseName + '\n' + "Status: Conflict";
            MessageBox.Show(warning, "Save Enrollment", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            return true;
        }
      
        private bool IsThereAConflict()
        {
            var filteredclassesbyrooms = new ObservableCollection<ClassModel>();
            var enrollments =
                SelectedStudent.Enrollments;
            var enrollmentcollection = new ObservableCollection<EnrollmentModel>();
            foreach (var item in enrollments)
            {
                enrollmentcollection.Add(item);
            }
            
            foreach (var item in enrollmentcollection)
            {
                var classroom = _repository.Class.Get(c => c.ClassId == item.Class.Model.ClassId);
                filteredclassesbyrooms.Add(new ClassModel(classroom, _repository));
            }

            var days = SelectedClass.Model.Day.Split('\n').ToList();
            days.Remove("");
            var filteredclassesbydays = new ObservableCollection<ClassModel>();
            foreach (var day in days)
            {
                foreach (var item in filteredclassesbyrooms.Where(c => c.Model.Day.Contains(day)))
                {
                    filteredclassesbydays.Add(item);
                }
            }

            var timeintervals = SelectedClass.Model.Time.Split('\n').ToList();
            timeintervals.Remove("");
            var daytimeindex = 0;
            var countconflicts = 0;
             
            foreach (var time in timeintervals)
            {
                foreach (var time2 in filteredclassesbydays)
                {
                    var timeintervalscomparedto = time2.Model.Time.Split('\n').ToList();
                    var dayscomparedto = time2.Model.Day.Split('\n').ToList();
                    dayscomparedto.Remove("");
                    timeintervalscomparedto.Remove("");
                    foreach (var time3 in timeintervalscomparedto)
                    {
                        try
                        {
                            if (!IsTimeInBetween(time.Trim(), time3.Trim()))
                                continue;

                            countconflicts++;
                            break;
                        }
                        catch (Exception e) { }
                    }

                    daytimeindex = 0;
                }
            }

            if (countconflicts > 0)
            {
                MessageBox.Show("Schedule Conflicts with the other Subjects!", "Add Schedule", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return true;
            }

            return false;
        }

        private bool IsTimeInBetween(string interval, string intervalcomparedto)
        {
            var times = interval.Split('-').ToList();
            times.Remove("");
            var timesobservable = new ObservableCollection<string>();
            foreach (var item in times)
            {
                timesobservable.Add(item.Trim());
            }

            var timescomparedto = intervalcomparedto.Split('-').ToList();
            timescomparedto.Remove("");
            var timescomparedtoobservable = new ObservableCollection<string>();
            foreach (var item in timescomparedto)
            {
                timescomparedtoobservable.Add(item.Trim());
            }

            if ((TimeSpan.Parse(timesobservable[0]) >= TimeSpan.Parse(timescomparedtoobservable[0])
                 && (TimeSpan.Parse(timesobservable[1]) >= TimeSpan.Parse(timescomparedtoobservable[0])
                 && TimeSpan.Parse(timesobservable[1]) <= TimeSpan.Parse(timescomparedtoobservable[1]))

                || (TimeSpan.Parse(timesobservable[0]) >= TimeSpan.Parse(timescomparedtoobservable[0])
                 && TimeSpan.Parse(timesobservable[0]) <= TimeSpan.Parse(timescomparedtoobservable[1])
                 && TimeSpan.Parse(timesobservable[1]) >= TimeSpan.Parse(timescomparedtoobservable[1]))

                || (TimeSpan.Parse(timesobservable[0]) <= TimeSpan.Parse(timescomparedtoobservable[0])
                 && TimeSpan.Parse(timesobservable[1]) >= TimeSpan.Parse(timescomparedtoobservable[0])
                 && TimeSpan.Parse(timesobservable[1]) <= TimeSpan.Parse(timescomparedtoobservable[1]))))

                return true;
            return false;
        }

        public ICommand DeleteStudentEnrollmentCommand => new RelayCommand(DeleteEnrollmentProc, DeleteEnrollmentCondition);

        private bool DeleteEnrollmentCondition()
        {
            return (SelectedEnrollment != null);
        }

        private async Task DeleteEnrollmentProcAsync()
        {
            StudentEditModel = new StudentEditModel(SelectedStudent.Model);
            StudentEditModel.NoOfSubjects = StudentEditModel.NoOfSubjects - 1;
            var grademodel = SelectedStudent.Grades.FirstOrDefault(g => g.Model.EnrollmentId == SelectedEnrollment.Model.EnrollmentId);
            SelectedStudent.Grades.Remove(grademodel);
            StudentEditModel.Units = StudentEditModel.Units - SelectedEnrollment.Class.Course.Model.CourseUnits;
            await Task.Run(() => _repository.Student.UpdateAsync(StudentEditModel.ModelCopy, CancellationToken.None));
            SelectedStudent.Model = StudentEditModel.ModelCopy;
            await Task.Run(() => _repository.Grade.RemoveAsync(grademodel.Model, CancellationToken.None));
            await Task.Run(() => _repository.Enrollment.RemoveAsync(SelectedEnrollment.Model, CancellationToken.None));
            EnrollmentList.Remove(SelectedEnrollment);
            SelectedStudent.Enrollments.Remove(SelectedEnrollment);
        }

        private async void DeleteEnrollmentProc()
        {
            await DeleteEnrollmentProcAsync();
        }

        public ICommand CancelSaveEnrollmentCommand => new RelayCommand(CancelSaveEnrollmenetProc);

        private void CancelSaveEnrollmenetProc()
        {
            NewEnrollment?.Dispose();
            _enrollmentAddingWindow.Close();
        }


        public ICommand PrintStudentEnrollmentReport => new RelayCommand(PrintStudentProc, PrintStudentCondition );
        private StudentRegistrationReportWindow _registrationReportWindow;
        private bool PrintStudentCondition()
        {
            return (SelectedStudent != null);
        }

        private void PrintStudentProc()
        {
            if (SelectedStudent == null) return;

            try
            {
                _registrationReportWindow = new StudentRegistrationReportWindow { Owner = Application.Current.MainWindow };
                _registrationReportWindow.Show();
            }
            catch(Exception e) { }

        }


        public ICommand PrintStudentGradeReport => new RelayCommand(PrintGradeProc, PrintGradeCondition);

        private StudentGradeReportWindow _studentGradeReportWindow;
        private bool PrintGradeCondition()
        {
            return (SelectedStudent != null);
        }

        private void PrintGradeProc()
        {
            if (SelectedStudent == null) return;

            _studentGradeReportWindow = new StudentGradeReportWindow { Owner = Application.Current.MainWindow };
            _studentGradeReportWindow.Show();

            try
            {

            }
            catch (Exception e){}
        }

        public INotifyTaskCompletion EnrollmentLoading { get; set; } 

        private async Task LoadEnrollments()
        {
            var enrollments = await Task.Run(() => _repository.Enrollment.GetRangeAsync(CancellationToken.None));
            foreach (var enrollment in enrollments )
            {
                var enrollmentmodel = new EnrollmentModel(enrollment, _repository);
                enrollmentmodel.LoadRelatedInfo();
                EnrollmentList.Add(enrollmentmodel);
                await Task.Delay(100);
            }
        }
    }
}
