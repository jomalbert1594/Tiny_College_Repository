using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using TinyCollege.Models.Professor;

namespace TinyCollege.ReportDataModel.Course
{
    public class ClassProfessorDataSetModel:ObservableObject
    {
        private int _no;
        private string _name;
        private string _status;
        private string _department;

        public ClassProfessorDataSetModel(ProfessorModel professor)
        {
            No = professor.Model.ProfessorId;
            Name = professor.Model?.ProfessorFirstName + " "
                   + professor.Model?.ProfessorMiddleName + " "
                   + professor.Model?.ProfessorFamilyName;
            Status = professor.Model?.ProfessorStatus;
            Department = professor.Department?.Model?.DepartmentName;
        }

        public int No
        {
            get { return _no; }
            set
            {
                _no = value; 
                RaisePropertyChanged(nameof(No));
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value; 
                RaisePropertyChanged(nameof(Name));
            }
        }

        public string Status
        {
            get { return _status; }
            set
            {
                _status = value; 
                RaisePropertyChanged(nameof(Status));
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
