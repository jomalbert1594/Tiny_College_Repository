using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using TinyCollege.Models.Course;
using TinyCollege.Models.Department;

namespace TinyCollege.ReportDataModel.Course
{
    public class CourseDataSetModel:ObservableObject
    {
        private string _courseName;
        private int? _units;
        private string _department;
        private string _courseCode;

        public CourseDataSetModel(CourseModel course)
        {
            CourseName = course.Model?.CourseName;
            Units = course.Model?.CourseUnits;
            Department = course.Department?.Model?.DepartmentName;
            CourseCode = course.Model?.CourseId;
        }

        public string CourseCode
        {
            get { return _courseCode; }
            set
            {
                _courseCode = value; 
                RaisePropertyChanged(nameof(CourseCode));
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
