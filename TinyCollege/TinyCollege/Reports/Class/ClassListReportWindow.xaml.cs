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
using TinyCollege.DataAccess;
using TinyCollege.Models.Professor;
using TinyCollege.Modules;
using TinyCollege.ReportDataModel.Class;
using TinyCollege.ReportDataModel.Course;
using TinyCollege.ReportDataModel.Professor;

namespace TinyCollege.Reports.Class
{
    /// <summary>
    /// Interaction logic for ClassListReportWindow.xaml
    /// </summary>
    public partial class ClassListReportWindow : Window
    {

        private ReportViewBuilder _reportView;

        public ClassListReportWindow()
        {
            InitializeComponent();
            _reportView = new ReportViewBuilder("TinyCollege.Reports.Class.ClassListReportViewer.rdlc", UpdateDatasetSource());
            _reportView.RefreshDataSourceCallback = UpdateDatasetSource;
            ReportContainer.Content = _reportView.ReportContent;
        }

        public IReadOnlyCollection<DataSetValuePair> UpdateDatasetSource()
        {
            var sources = new List<DataSetValuePair>();
            var selectedclass = ViewModelLocatorStatic.Locator.ClassModule.SelectedModuleClass;
            var studentdataset = new ObservableCollection<ProfessorClassStudentListDataSetModel>();

            var classdataset = new ProfessorClassListDataSetModel
            {
                Professor = selectedclass.Professor?.Model?.ProfessorFirstName + " "
                    + selectedclass.Professor?.Model?.ProfessorMiddleName + " "
                    + selectedclass.Professor?.Model?.ProfessorFamilyName,
                Schedule = selectedclass.Model?.Time + selectedclass.Model?.Day,
                Room = selectedclass.Room?.Model?.RoomName,
                Units = selectedclass.Course?.Model?.CourseUnits,
                CourseName = selectedclass.Course?.Model?.CourseName,
                ClassCode = selectedclass.Model?.ClassId,
                ClassDescription = selectedclass.Model?.ClassName
            };
            foreach (var student in selectedclass.Students)
            {
                studentdataset.Add(new ProfessorClassStudentListDataSetModel
                {
                    Department = student.Department?.Model?.DepartmentName,
                    StudentId = student.Model.StudentId,
                    Name = student.Model?.StudentFirstName + " "
                        + student.Model?.StudentMiddleName + " "
                        + student.Model?.StudentFamilyName
                });
            }
            

            sources.Add(new DataSetValuePair("StudentListDataSet", studentdataset));
            sources.Add(new DataSetValuePair("ClassDataSet", classdataset));

            return sources;
        }
    }
}
