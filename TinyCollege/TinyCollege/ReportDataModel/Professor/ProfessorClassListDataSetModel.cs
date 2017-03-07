using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace TinyCollege.ReportDataModel.Professor
{
    public class ProfessorClassListDataSetModel:ObservableObject
    {
        public ProfessorClassListDataSetModel()
        {
            
        }


        private string _professor;
        public string Professor
        {
            get { return _professor; }
            set
            {
                _professor = value;
                RaisePropertyChanged(nameof(Professor));
            }
        }

        private string _classcode;

        public string ClassCode
        {
            get { return _classcode; }
            set
            {
                _classcode = value;
                RaisePropertyChanged(nameof(ClassCode));
            }
        }
        private string _classdescription;
        public string ClassDescription
        {
            get { return _classdescription; }
            set
            {
                _classdescription = value;
                RaisePropertyChanged(nameof(ClassDescription));
            }
        }
        private string _coursename;
        public string CourseName
        {
            get { return _coursename; }
            set
            {
                _coursename = value;
                RaisePropertyChanged(nameof(CourseName));
            }
        }
        private string _schedule;
        public string Schedule
        {
            get { return _schedule; }
            set
            {
                _schedule = value;
                RaisePropertyChanged(nameof(Schedule));
            }
        }
        private string _room;
        public string Room
        {
            get { return _room; }
            set
            {
                _room = value;
                RaisePropertyChanged(nameof(Room));
            }
        }
        private int? _units;
        public int? Units
        {
            get { return _units; }
            set
            {
                _units = value;
                RaisePropertyChanged(nameof(Units));
            }
        }
    }
}
