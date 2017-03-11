using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Nito.AsyncEx;
using TinyCollege.DataAccess;
using TinyCollege.DataAccess.Ef;
using TinyCollege.Models.Student;
using TinyCollege.Views.Student;

namespace TinyCollege.Modules
{
    public class StudentModule:ObservableObject
    {
        private IRepository _repository;

        public StudentModule(IRepository repository)
        {
            _repository = repository;
            StudentLoading = NotifyTaskCompletion.Create(() => LoadStudentAsync());
        } 
        
        public ObservableCollection<StudentModel> StudentList { get; } = new ObservableCollection<StudentModel>();

        public INotifyTaskCompletion StudentLoading { get; private set; }

        private async Task LoadStudentAsync()
        {
            var students = await Task.Run(() => _repository.Student.GetRangeAsync());
            foreach (var student in students)
            {
                var studentmodel = new StudentModel(student, _repository);
                studentmodel.LoadRelatedInfo();
                StudentList.Add(studentmodel);
                await Task.Delay(100);
            }
        }

        private StudentNewModel _newStudent;
        public StudentNewModel NewStudent
        {
            get { return _newStudent; }
            set
            {
                _newStudent = value;
                RaisePropertyChanged(nameof(NewStudent));
            }
        }


        public ICommand AddStudentCommand => new RelayCommand(AddStudenProc);
        private StudentAddingWindow _studentAddingWindow;
        private void AddStudenProc()
        {
            NewStudent?.Dispose();
            NewStudent = new StudentNewModel();
            _studentAddingWindow = new StudentAddingWindow {Owner = Application.Current.MainWindow};
            _studentAddingWindow.ShowDialog();
        }
        public ICommand SaveStudentCommandAsync => new RelayCommand(SaveStudentProc, SaveStudentCondition);

        private bool SaveStudentCondition()
        {
            return (NewStudent != null) && NewStudent.HasChanges && !NewStudent.HasErrors;
        }

        private async Task SaveStudentAsync()
        {
            if (NewStudent == null) return;
            if (!NewStudent.HasChanges) return;

            if (NewStudent.ModelCopy.DepartmentId == null)
            {
                MessageBox.Show("Department is a required field!", "Add Student", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            try
            {
                NewStudent.Units = 0;
                NewStudent.NoOfSubjects = 0;
                await Task.Run(() => _repository.Student.AddAsync(NewStudent.ModelCopy, CancellationToken.None));
                StudentList.Add(new StudentModel(NewStudent.ModelCopy, _repository));
                _studentAddingWindow.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to Save", "Add Student", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveStudentProc()
        {
            NotifyTaskCompletion.Create(() => SaveStudentAsync());

        }
        public ICommand CanceStudentCommand => new RelayCommand(CancelStudentProc);

        private void CancelStudentProc()
        {
            NewStudent?.Dispose();
            _studentAddingWindow.Close();
        }

        private string _searchLastName;
        public string SearchLastName
        {
            get { return _searchLastName; }
            set
            {
                _searchLastName = value;
                RaisePropertyChanged(nameof(SearchLastName));
                var viewNameList = CollectionViewSource.GetDefaultView(StudentList);
                if (string.IsNullOrWhiteSpace(SearchLastName))
                {
                    viewNameList.Filter = null;
                }
                else
                {
                    viewNameList.Filter =
                        obj => ((StudentModel)obj).Model.StudentFamilyName.ToLower().Contains(SearchLastName.ToLower());
                }
            }
        }
    }
}
