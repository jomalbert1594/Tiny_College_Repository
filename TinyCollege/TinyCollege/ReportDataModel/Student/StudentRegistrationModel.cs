using System;
using GalaSoft.MvvmLight;

namespace TinyCollege.ReportDataModel.Student
{
    public class StudentRegistrationModel:ObservableObject
    {
        public StudentRegistrationModel()
        {
            
        }

        private string _classCode;
        private string _courseDescription;
        private string _courseName;

        public string ClassCode
        {
            get { return _classCode; }
            set
            {
                _classCode = value;
                RaisePropertyChanged(nameof(ClassCode));
            }
        }

        public string CourseDescription
        {
            get { return _courseDescription; }
            set
            {
                _courseDescription = value;
                RaisePropertyChanged(nameof(CourseDescription));
            }
        }

        public string CourseName
        {
            get { return _courseName; }
            set
            {
                _courseName = value;
                RaisePropertyChanged(nameof(CourseName));
            }
        }

        private DateTime? _dateEnrolled;
        private string _time;
        private string _day;

        public DateTime? DateEnrolled
        {
            get { return _dateEnrolled; }
            set
            {
                _dateEnrolled = value;
                RaisePropertyChanged(nameof(DateEnrolled));
            }
        }

        public string Time
        {
            get { return _time; }
            set
            {
                _time = value;
                RaisePropertyChanged(nameof(Time));
            }
        }

        public string Day
        {
            get { return _day; }
            set
            {
                _day = value;
                RaisePropertyChanged(nameof(Day));
            }
        }

        private string _professor;
        private string _room;
        private int? _units;
        private string _department;

        public string Professor
        {
            get { return _professor; }
            set
            {
                _professor = value;
                RaisePropertyChanged(nameof(Professor));
            }
        }

        public string Room
        {
            get { return _room; }
            set
            {
                _room = value;
                RaisePropertyChanged(nameof(Room));
            }
        }

        public int? Units
        {
            get { return _units; }
            set
            {
                _units = value;
                RaisePropertyChanged(nameof(Units));
            }
        }

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
