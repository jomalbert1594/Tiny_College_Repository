using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace TinyCollege.ReportDataModel.Professor
{
    public class ProfessorClassStudentListDataSetModel:ObservableObject
    {
        public ProfessorClassStudentListDataSetModel()
        {
            
        }

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
        private double? _prelim;
        public double? Prelim
        {
            get { return _prelim; }
            set
            {
                _prelim = value;
                RaisePropertyChanged(nameof(Prelim));
            }
        }
        private double? _midterm;
        public double? Midterm
        {
            get { return _midterm; }
            set
            {
                _midterm = value;
                RaisePropertyChanged(nameof(Midterm));
            }
        }
        private double? _prefinal;
        public double? Prefinal
        {
            get { return _prefinal; }
            set
            {
                _prefinal = value;
                RaisePropertyChanged(nameof(Prefinal));
            }
        }
        private double? _final;
        public double? Final
        {
            get { return _final; }
            set
            {
                _final = value;
                RaisePropertyChanged(nameof(Final));
            }
        }
    }
}
