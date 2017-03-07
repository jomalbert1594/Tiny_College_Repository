﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewGoodReading.Helpers.ReportViewer
{
    public class DataSetValuePair
    {
        public DataSetValuePair(string datasetName, object dataSource)
        {
            DatasetName = datasetName;
            DataSource = dataSource;
        }
        public string DatasetName { get;private set; }
        public object DataSource { get;private set; }
    }
}
