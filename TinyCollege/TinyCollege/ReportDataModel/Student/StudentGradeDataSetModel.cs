using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace TinyCollege.ReportDataModel.Student
{
    public class StudentGradeDataSetModel:ObservableObject
    {
        public StudentGradeDataSetModel()
        {
            
        }

        private string _classCode;

        public string ClassCode
        {
            get { return _classCode; }
            set
            {
                _classCode = value; 
                RaisePropertyChanged(nameof(ClassCode));
            }
        }

        private string _classDescription;
        public string ClassDescription
        {
            get { return _classDescription; }
            set
            {
                _classDescription = value;
                RaisePropertyChanged(nameof(ClassDescription));
            }
        }
        
        private string _courseName;
        public string CourseName
        {
            get { return _courseName; }
            set
            {
                _courseName = value;
                RaisePropertyChanged(nameof(CourseName));
            }
        }

        private string _instructor;
        public string Instructor
        {
            get { return _instructor; }
            set
            {
                _instructor = value;
                RaisePropertyChanged(nameof(Instructor));
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
        public double? PreFinal
        {
            get { return _prefinal; }
            set
            {
                _prefinal = value;
                RaisePropertyChanged(nameof(PreFinal));
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
