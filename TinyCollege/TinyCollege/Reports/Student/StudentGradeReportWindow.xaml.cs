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
using TinyCollege.Modules;
using TinyCollege.ReportDataModel.Student;

namespace TinyCollege.Reports.Student
{
    /// <summary>
    /// Interaction logic for StudentGradeReportWindow.xaml
    /// </summary>
    public partial class StudentGradeReportWindow : Window
    {
        private string _titleFilter;
        private ReportViewBuilder _reportView;

        public StudentGradeReportWindow()
        {
            InitializeComponent();
            _reportView = new ReportViewBuilder("TinyCollege.Reports.Student.StudentGradeReportViewer.rdlc", UpdateDatasetSource());
            _reportView.RefreshDataSourceCallback = UpdateDatasetSource;
            ReportContainer.Content = _reportView.ReportContent;
        }

        public IReadOnlyCollection<DataSetValuePair> UpdateDatasetSource()
        {
            var sources = new List<DataSetValuePair>();
            var selectedStudent = ViewModelLocatorStatic.Locator.EnrollmentModule.SelectedStudent;

            var grades = new ObservableCollection<StudentGradeDataSetModel>();
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
                grades.Add(new StudentGradeDataSetModel
                {
                    Prelim = enrollment?.Grade?.Model?.Prelim,
                    ClassCode = enrollment?.Class?.Model?.ClassId,
                    Final = enrollment?.Grade?.Model?.Final,
                    Midterm = enrollment?.Grade?.Model?.Midterm,
                    CourseName = enrollment?.Class?.Course?.Model?.CourseName,
                    ClassDescription = enrollment?.Class?.Model?.ClassName,
                    Instructor = enrollment?.Class?.Professor?.Model?.ProfessorFirstName + " "
                                + enrollment?.Class?.Professor?.Model?.ProfessorMiddleName[0] + " "
                                + enrollment?.Class?.Professor?.Model?.ProfessorFamilyName,
                    PreFinal = enrollment?.Grade?.Model?.Prefinal

                });
            }



            sources.Add(new DataSetValuePair("StudentDataSet", studentdataset));
            sources.Add(new DataSetValuePair("StudentGradeDataSet", grades));

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
