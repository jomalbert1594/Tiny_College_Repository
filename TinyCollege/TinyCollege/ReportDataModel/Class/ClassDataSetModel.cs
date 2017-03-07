using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace TinyCollege.ReportDataModel.Class
{
    public class ClassDataSetModel:ObservableObject
    {

        private int _studentid;
        public int StudentId
        {
            get { return _studentid; }
            set
            {
                _studentid = value;
                RaisePropertyChanged(nameof(StudentId));
            }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }
        private string _department;
        public string Department
        {
            get { return _department; }
            set
            {
                _department = value;
                RaisePropertyChanged(nameof(Department));
            }
        }
    }
}
