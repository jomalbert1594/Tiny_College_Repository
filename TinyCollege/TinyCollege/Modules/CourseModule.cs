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
using Nito.AsyncEx;
using TinyCollege.DataAccess;
using TinyCollege.Models.Course;
using TinyCollege.Models.Department;
using TinyCollege.Reports.Course;
using TinyCollege.Views.Course;

namespace TinyCollege.Modules
{
    public class CourseModule:ObservableObject
    {
        private IRepository _repository;

        public CourseModule(IRepository repository)
        {
            _repository = repository;

            CourseLoading = NotifyTaskCompletion.Create(() => LoadCoursesAsync());
        }

        public ObservableCollection<CourseModel> CourseList { get; } = new ObservableCollection<CourseModel>();
        private CourseModel _selectedCourse;

        public CourseModel SelecteCourse
        {
            get { return _selectedCourse; }
            set
            {
                _selectedCourse = value;
                if (value != null)
                {
                    _selectedCourse.LoadRelatedInfo();
                }
                RaisePropertyChanged(nameof(SelecteCourse));
            }
        }

        private async Task LoadCoursesAsync()
        {
            var courses = await Task.Run(() => _repository.Course.GetRangeAsync(CancellationToken.None));
            foreach (var course in courses)
            {
                var coursemodel = new CourseModel(course, _repository);
                coursemodel.LoadRelatedInfo();
                CourseList.Add(coursemodel);
                await Task.Delay(100);
            }
        }

        public INotifyTaskCompletion CourseLoading { get; set; }

        private CourseNewModel _newCourse;
        public CourseNewModel NewCourse
        {
            get { return _newCourse; }
            set
            {
                _newCourse = value;
                RaisePropertyChanged(nameof(NewCourse));
            }
        }

        public ICommand PrintCourseCommand => new RelayCommand(PrintCourseProc, PrintCourseCondition);

        private bool PrintCourseCondition()
        {
            return (SelecteCourse != null);
        }

        private CourseProfessorsReportWindow _courseProfessorsReportWindow;
        private void PrintCourseProc()
        {
            _courseProfessorsReportWindow = new CourseProfessorsReportWindow();
            _courseProfessorsReportWindow.Owner = Application.Current.MainWindow;
            _courseProfessorsReportWindow.Show();
        }

        public ICommand AddCourseCommand => new RelayCommand(AddCourseProc);


        private AddingCourseWindow _addingCourseWindow;
        private void AddCourseProc()
        {
            NewCourse?.Dispose();
            NewCourse = new CourseNewModel();
            _addingCourseWindow = new AddingCourseWindow {Owner = Application.Current.MainWindow};
            _addingCourseWindow.ShowDialog();
        }

        public ICommand SaveCourseCommand => new RelayCommand(SaveCourseProc, SaveCourseCondition);

        private bool SaveCourseCondition()
        {
            return (NewCourse != null) && NewCourse.HasChanges && !NewCourse.HasErrors;
        }

        private async Task SaveCourseProcAsync()
        {
            if (NewCourse == null) return;
            if (!NewCourse.HasChanges) return;
            try
            {
                await Task.Run(() => _repository.Course.AddAsync(NewCourse.ModelCopy, CancellationToken.None));
                var courseModel = new CourseModel(NewCourse.ModelCopy, _repository);
                courseModel.LoadRelatedInfo();
                CourseList.Add(courseModel);
                _addingCourseWindow.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to Save!", "Add Deparmtent");
            }
        }

        private void SaveCourseProc()
        {
            NotifyTaskCompletion.Create(() => SaveCourseProcAsync());

        }

        public ICommand CancelCourseCommand => new RelayCommand(CancelCourseProc);

        private void CancelCourseProc()
        {
            NewCourse?.Dispose();
            _addingCourseWindow.Close();
        }

        public ICommand DeleteCourseCommand => new RelayCommand(DeleteCourseProc, DeleteCourseCondition);

        private bool DeleteCourseCondition()
        {
            return (SelecteCourse != null);
        }

        private async Task DeleteCourseProcAsync()
        {
            try
            {
                await Task.Run(() => _repository.Course.RemoveAsync(SelecteCourse.Model, CancellationToken.None));
                CourseList.Remove(SelecteCourse);
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to Delete!", "Delete Course", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }

        private async void DeleteCourseProc()
        {
            NotifyTaskCompletion.Create(() => DeleteCourseProcAsync());

        }
    }
}
