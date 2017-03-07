using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewGoodReading.Helpers.ReportViewer
{
    public class ReportViewBuilder:IDisposable
    {
        public ReportViewBuilder(string source, IReadOnlyCollection<DataSetValuePair> intialDataSource )
        {
            ReportContent = new ReportView(source, intialDataSource);
            ReportContent.Viewer.ReportRefresh += RptViewerOnReportRefresh;
        }

       


        private void RptViewerOnReportRefresh(object sender, CancelEventArgs e)
        {
            if (RefreshDataSourceCallback == null)
            {
                throw new InvalidOperationException("Unable to locate the method theat updates this report's data source .\n" +
                    "Use RefresDataSourceCallback to point to your refresh data source method.");
            }
            ReportContent.UpdateDataSource(RefreshDataSourceCallback());
        }

        public ReportView ReportContent { get; }
        public Func<IReadOnlyCollection<DataSetValuePair>> RefreshDataSourceCallback { private get; set; } 

        public void Dispose()
        {
            ReportContent.Viewer.ReportRefresh -= RptViewerOnReportRefresh;
        }
    }
}
