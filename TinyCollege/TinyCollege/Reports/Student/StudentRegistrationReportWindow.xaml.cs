using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using NewGoodReading.Helpers.ReportViewer;
using TinyCollege.DataAccess.Ef;
using TinyCollege.Modules;
using TinyCollege.ReportDataModel.Student;

namespace TinyCollege.Reports.Student
{
    /// <summary>
    /// Interaction logic for StudentRegistrationReportWindow.xaml
    /// </summary>
    public partial class StudentRegistrationReportWindow : Window
    {
        private string _titleFilter;
        private ReportViewBuilder _reportView;

        public StudentRegistrationReportWindow()
        {
            InitializeComponent();
            _reportView = new ReportViewBuilder("TinyCollege.Reports.Student.StudentRegistrationReportViewer.rdlc", UpdateDatasetSource());
            _reportView.RefreshDataSourceCallback = UpdateDatasetSource;
            ReportContainer.Content = _reportView.ReportContent;
        }

        public IReadOnlyCollection<DataSetValuePair> UpdateDatasetSource()
        {
            var sources = new List<DataSetValuePair>();
            var selectedStudent = ViewModelLocatorStatic.Locator.EnrollmentModule.SelectedStudent;

            var registrations = new ObservableCollection<StudentRegistrationModel>();
            var studentdataset = new StudentDataSetModel
            {
                NoOfSubjects = selectedStudent.Model.NoOfSubjects,
                Units = selectedStudent.Model.StudentUnitsTaken,
                StudentId = selectedStudent.Model.StudentId,
                Status = selectedStudent.Model.StudentStatus,
                FirstName = selectedStudent.Model.StudentFirstName,
                FamilyName = selectedStudent.Model.StudentFamilyName,
                MiddleName = selectedStudent.Model.StudentMiddleName,
                Address = selectedStudent.Model.StudentAddress,
                BirthDate = selectedStudent.Model.StudentDateOfBirth?.ToString("MMMM dd, yyy"),
                ContactNo = selectedStudent.Model.StudentContactNumber,
                DepartmentNames = selectedStudent.Department.Model.DepartmentName
            };
           
            foreach (var enrollment in selectedStudent.Enrollments)
            {
                registrations.Add(new StudentRegistrationModel
                {
                    Department = enrollment?.Class?.Course?.Department?.Model?.DepartmentName,
                    Professor = enrollment?.Class?.Professor?.Model?.ProfessorFamilyName + " "
                                + enrollment?.Class?.Professor?.Model?.ProfessorMiddleName + " "
                                + enrollment?.Class?.Professor?.Model?.ProfessorFamilyName[0] + ".",
                    Day = enrollment?.Class?.Model?.Day,
                    Units = enrollment?.Class?.Course?.Model?.CourseUnits,
                    Room = enrollment?.Class?.Room?.Model?.RoomName,
                    Time = enrollment?.Class?.Model?.Time,
                    CourseDescription = enrollment?.Class?.Course?.Model?.CourseId,
                    ClassCode = enrollment?.Class?.Model?.ClassId,
                    CourseName = enrollment?.Class?.Course?.Model?.CourseName,
                    DateEnrolled = enrollment?.Model?.EnrollmentDate
                });
            }

            sources.Add(new DataSetValuePair("StudentDataSet", studentdataset));
            sources.Add(new DataSetValuePair("RegistrationDataSet", registrations));
           
            return sources;
        }

        public string TutleFilter
        {
            get { return _titleFilter; }
            set
            {
                _titleFilter = value;
                _reportView.ReportContent.UpdateDataSource(UpdateDatasetSource());
            }
        }
    }
}
