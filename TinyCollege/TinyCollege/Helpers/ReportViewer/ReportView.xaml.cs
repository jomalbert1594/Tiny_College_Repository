using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Reporting.WinForms;
using UserControl = System.Windows.Controls.UserControl;

namespace NewGoodReading.Helpers.ReportViewer
{
    /// <summary>
    /// Interaction logic for ReportView.xaml
    /// </summary>
    public partial class ReportView : UserControl
    {
        /// <summary>
        /// Initializes an instance of a ReportView
        /// </summary>
        /// <param name="reportSource"></param> The source for the embedded resource of the ReportViewer
        /// <param name="intialDataSource"></param> The data source represented by a collection of a DatasetValuePair
        public ReportView(string reportSource, IReadOnlyCollection<DataSetValuePair> intialDataSource )
        {
            InitializeComponent();

            ReportSource = reportSource;
            _initialDataSource = intialDataSource;
            Viewer.LocalReport.ReportEmbeddedResource = reportSource;
        }

        private void ReportView_OnLoaded(object sender, RoutedEventArgs e)
        {
            Viewer.SetDisplayMode(DisplayMode.PrintLayout);
            Viewer.ZoomPercent = 100;
            Viewer.ZoomMode = ZoomMode.Percent;

            UpdateDataSource(_initialDataSource);
        }

        public void UpdateDataSource(IReadOnlyCollection<DataSetValuePair> sources)
        {
            Viewer.LocalReport.DataSources.Clear();

            foreach (var datasetSource in sources )
            {
                Viewer.LocalReport.DataSources.Add(CreateDataSource(datasetSource.DatasetName, datasetSource.DataSource));
                
            }
            Viewer.RefreshReport();
        }

        public ReportDataSource CreateDataSource(string sourceName, object datasetValue)
        {
            var dataSource = new ReportDataSource();
            var dataset = new BindingSource();
            dataset.DataSource = datasetValue;

            dataSource.Name = sourceName;
            dataSource.Value = dataset;
            return dataSource;
        }

        public string ReportSource { get; private set; }
        private readonly IReadOnlyCollection<DataSetValuePair> _initialDataSource;
    }
}
