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
using TinyCollege.ReportDataModel.Course;
using TinyCollege.ReportDataModel.Professor;

namespace TinyCollege.Reports.Course
{
    /// <summary>
    /// Interaction logic for CourseProfessorsReportWindow.xaml
    /// </summary>
    public partial class CourseProfessorsReportWindow : Window
    {
        private ReportViewBuilder _reportView;
        private static readonly IRepository _Repository = new EfRepository();
        public CourseProfessorsReportWindow()
        {
            InitializeComponent();
            _reportView = new ReportViewBuilder("TinyCollege.Reports.Course.ClassProfessorsReportViewer.rdlc", UpdateDatasetSource());
            _reportView.RefreshDataSourceCallback = UpdateDatasetSource;
            ReportContainer.Content = _reportView.ReportContent;
        }

        public IReadOnlyCollection<DataSetValuePair> UpdateDatasetSource()
        {
            var sources = new List<DataSetValuePair>();
            var selectedcourse = ViewModelLocatorStatic.Locator.CourseModule.SelecteCourse;
            var professordataset = new ObservableCollection<ClassProfessorDataSetModel>();

            var coursedataset = new CourseDataSetModel(selectedcourse);

            foreach (var professor in selectedcourse.ProfessorList)
            {
                var professormodel = new ProfessorModel(professor.Model, _Repository);
                professordataset.Add(new ClassProfessorDataSetModel(professormodel));
            }

            sources.Add(new DataSetValuePair("ClassProfessorDataSet", professordataset));
            sources.Add(new DataSetValuePair("CourseDataSet", coursedataset));

            return sources;
        }
    }
}
