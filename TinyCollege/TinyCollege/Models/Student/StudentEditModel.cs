using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using Nito.AsyncEx;
using TinyCollege.DataAccess;
using TinyCollege.Models.Department;

namespace TinyCollege.Models.Student
{
    public class StudentNewModel : StudentEditModel
    {
        public StudentNewModel() : base(new DataAccess.Ef.Student())
        {
        }
    }
    public class StudentEditModel:EditModelBase<DataAccess.Ef.Student>
    {
        private static readonly IRepository _Repository = new EfRepository();
        public StudentEditModel(DataAccess.Ef.Student model) : base(model)
        {
            ModelCopy = CreateCopy(model);
            LoadDepartment();
        }

        private DataAccess.Ef.Student CreateCopy(DataAccess.Ef.Student model)
        {
            var copy = new DataAccess.Ef.Student
            {
                StudentMiddleName = model.StudentMiddleName,
                StudentStatus = model.StudentStatus,
                StudentAddress = model.StudentAddress,
                StudentId = model.StudentId,
                ProfessorId = model.ProfessorId,
                StudentContactNumber = model.StudentContactNumber,
                StudentDateOfBirth = model.StudentDateOfBirth,
                StudentFirstName = model.StudentFirstName,
                StudentFamilyName = model.StudentFamilyName,
                DepartmentId = model.DepartmentId,
                StudentUnitsTaken = model.StudentUnitsTaken,
                NoOfSubjects = model.NoOfSubjects
            };
            return copy;
        }

        public int? NoOfSubjects
        {
            get { return ModelCopy.NoOfSubjects; }
            set
            {
                ModelCopy.NoOfSubjects = value;
                RaisePropertyChanged(nameof(NoOfSubjects));
            }
        }

        public int StudentId
        {
            get { return ModelCopy.StudentId; }
            set
            {
                ModelCopy.StudentId = value;
                RaisePropertyChanged(nameof(StudentId));
            }
        }

        public string FamilyName
        {
            get { return ModelCopy.StudentFamilyName; }
            set
            {
                ModelCopy.StudentFamilyName = value; 
                RaisePropertyChanged(nameof(FamilyName));

            }
        }

        public string FirstName
        {
            get { return ModelCopy.StudentFirstName; }
            set
            {
                ModelCopy.StudentFirstName = value;
                RaisePropertyChanged(nameof(FirstName));

            }
        }

        public string MiddleName
        {
            get { return ModelCopy.StudentMiddleName; }
            set
            {
                ModelCopy.StudentMiddleName = value; 
                RaisePropertyChanged(nameof(MiddleName));

            }
        }

        public string Address
        {
            get { return ModelCopy.StudentAddress; }
            set
            {
                ModelCopy.StudentAddress = value; 
                RaisePropertyChanged(nameof(Address));

            }
        }

        public string ContactNo
        {
            get { return ModelCopy.StudentContactNumber; }
            set
            {
                ModelCopy.StudentContactNumber = value; 
                RaisePropertyChanged(nameof(ContactNo));

            }
        }

        public DateTime? BirthDate
        {
            get { return ModelCopy.StudentDateOfBirth; }
            set
            {
                ModelCopy.StudentDateOfBirth = value;
                RaisePropertyChanged(nameof(BirthDate));

            }
        }

        public string Status
        {
            get { return ModelCopy.StudentStatus; }
            set
            {
                ModelCopy.StudentStatus = value; 
                RaisePropertyChanged(nameof(Status));

            }
        }

        public int? Units
        {
            get { return ModelCopy.StudentUnitsTaken; }
            set
            {
                ModelCopy.StudentUnitsTaken = value; 
                RaisePropertyChanged(nameof(Units));

            }
        }

        public int? DepartMentId
        {
            get { return ModelCopy.DepartmentId; }
            set
            {
                ModelCopy.DepartmentId = value;
                RaisePropertyChanged(nameof(DepartMentId));

            }
        }

        public int? ProfessorId
        {
            get { return ModelCopy.ProfessorId; }
            set
            {
                ModelCopy.ProfessorId = value; 
                RaisePropertyChanged(nameof(ProfessorId));

            }
        }

        private DepartmentModel _department;

        public DepartmentModel Department
        {
            get { return _department; }
            set
            {
                _department = value;
                if (value != null)
                {
                    ModelCopy.DepartmentId = Department.Model.DepartmentId;
                }
                RaisePropertyChanged(nameof(Department));
            }
        }

        public ObservableCollection<string> StatusList { get; } = new ObservableCollection<string> {"Regular", "Irregular"};
        public ObservableCollection<DepartmentModel> DepartmentList { get; } = new ObservableCollection<DepartmentModel>();


        private async Task LoadDepartmentAsync()
        {
            var departments = await Task.Run(() => _Repository.Department.GetRangeAsync(CancellationToken.None)); 

            foreach (var department in departments)
            {
                DepartmentList.Add(new DepartmentModel(department, _Repository));
                await Task.Delay(100);
            }
        }

        private async void LoadDepartment()
        {
            NotifyTaskCompletion.Create(() => LoadDepartmentAsync());

        }
    }
}
