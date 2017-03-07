using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using TinyCollege.Models.Department;

namespace TinyCollege.ReportDataModel.Student
{
    public class StudentDataSetModel:ObservableObject
    {
        private int? _noOfSubjects;
        public int? NoOfSubjects
        {
            get { return _noOfSubjects; }
            set
            {
                _noOfSubjects = value;
                RaisePropertyChanged(nameof(NoOfSubjects));
            }
        }

        private int _studentId;
        public int StudentId
        {
            get { return _studentId; }
            set
            {
                _studentId = value;
                RaisePropertyChanged(nameof(StudentId));
            }
        }


        private string _familyName;
        public string FamilyName
        {
            get { return _familyName; }
            set
            {
                _familyName = value;
                RaisePropertyChanged(nameof(FamilyName));

            }
        }


        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                RaisePropertyChanged(nameof(FirstName));

            }
        }

        private string _middleName;
        public string MiddleName
        {
            get { return _middleName; }
            set
            {
                _middleName = value;
                RaisePropertyChanged(nameof(MiddleName));

            }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                RaisePropertyChanged(nameof(Address));

            }
        }


        private string _contactNo;
        public string ContactNo
        {
            get { return _contactNo; }
            set
            {
                _contactNo = value;
                RaisePropertyChanged(nameof(ContactNo));

            }
        }

        private string _birthDate;
        public string BirthDate
        {
            get { return _birthDate; }
            set
            {
                _birthDate = value;
                RaisePropertyChanged(nameof(BirthDate));

            }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                RaisePropertyChanged(nameof(Status));

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

        private string _departmentName;
        public string DepartmentNames
        {
            get { return _departmentName; }
            set
            {
                _departmentName = value;
                RaisePropertyChanged(nameof(DepartmentNames));
            }
        }
    }
}
