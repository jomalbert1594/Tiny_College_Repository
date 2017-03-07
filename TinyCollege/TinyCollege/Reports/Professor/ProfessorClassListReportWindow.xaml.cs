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
using TinyCollege.ReportDataModel.Professor;
using TinyCollege.ReportDataModel.Student;

namespace TinyCollege.Reports.Professor
{
    /// <summary>
    /// Interaction logic for ProfessorClassListReportWindow.xaml
    /// </summary>
    public partial class ProfessorClassListReportWindow : Window
    {
        
        private ReportViewBuilder _reportView;

        public ProfessorClassListReportWindow()
        {
            InitializeComponent();
            _reportView = new ReportViewBuilder("TinyCollege.Reports.Professor.ProfessorClassListReportViewer.rdlc", UpdateDatasetSource());
            _reportView.RefreshDataSourceCallback = UpdateDatasetSource;
            ReportContainer.Content = _reportView.ReportContent;
        }

        public IReadOnlyCollection<DataSetValuePair> UpdateDatasetSource()
        {
            var sources = new List<DataSetValuePair>();
            var selectedprofessor = ViewModelLocatorStatic.Locator.ClassModule.SelectedProfessor;
            var selectedclass = ViewModelLocatorStatic.Locator.ClassModule.SelectedClass;

            var classdataset = new ProfessorClassListDataSetModel
            {
                Schedule = selectedclass?.Model?.Time + " "
                           + selectedclass?.Model?.Day, 
                Units = selectedclass?.Course?.Model?.CourseUnits,
                Room = selectedclass?.Room?.Model?.RoomName,
                ClassCode = selectedclass?.Model?.ClassId,
                CourseName = selectedclass?.Course?.Model?.CourseName,
                ClassDescription = selectedclass?.Model?.ClassName,
                Professor = selectedclass?.Professor?.Model?.ProfessorFirstName + " "
                        + selectedclass?.Professor?.Model?.ProfessorMiddleName + " "
                        + selectedclass?.Professor?.Model?.ProfessorFamilyName         
            };

            var studentlist = new ObservableCollection<ProfessorClassStudentListDataSetModel>();

            try
            {
                foreach (var student in selectedclass?.Students)
                {
                    studentlist.Add(new ProfessorClassStudentListDataSetModel
                    {
                        Department = student?.Department?.Model?.DepartmentName,
                        StudentId = student.Model.StudentId,
                        Final = student?.Grade?.Model?.Final,
                        Prefinal = student?.Grade?.Model?.Prefinal,
                        Prelim = student?.Grade?.Model?.Prelim,
                        Midterm = student?.Grade?.Model?.Midterm,
                        Name = student?.Model?.StudentFirstName + " "
                            + student?.Model?.StudentMiddleName + " "
                            + student?.Model?.StudentFamilyName + " ",
                    });
                }
            }
            catch(Exception e) { }

            sources.Add(new DataSetValuePair("ProfessorClassDataSet", classdataset));
            sources.Add(new DataSetValuePair("ProfessorClassStudentDataSet", studentlist));

            return sources;
        }
    }
}
