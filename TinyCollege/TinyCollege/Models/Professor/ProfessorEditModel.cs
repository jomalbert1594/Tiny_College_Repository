using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TinyCollege.DataAccess;
using TinyCollege.Models.Department;

namespace TinyCollege.Models.Professor
{
    public class ProfessorNewModel : ProfessorEditModel
    {
        public ProfessorNewModel() : base(new DataAccess.Ef.Professor())
        {

        }
    }
    public class ProfessorEditModel:EditModelBase<DataAccess.Ef.Professor>
    {
        
        public ProfessorEditModel(DataAccess.Ef.Professor model) : base(model)
        {
            ModelCopy = CreateCopy(model);
            LoadDepartments();
        }

        private DataAccess.Ef.Professor CreateCopy(DataAccess.Ef.Professor model)
        {
            var copy = new DataAccess.Ef.Professor
            {
                ProfessorId = model.ProfessorId,
                DepartmentId = model.DepartmentId,
                ProfessorMiddleName = model.ProfessorMiddleName,
                ProfessorDateOfBirth = model.ProfessorDateOfBirth,
                ProfessorAddress = model.ProfessorAddress,
                ProfessorStatus = model.ProfessorStatus,
                ProfessorFirstName = model.ProfessorFirstName,
                ProfessorContactNumber = model.ProfessorContactNumber,
                ProfessorFamilyName = model.ProfessorFamilyName,
                CreditUnits = model.CreditUnits,
                NoOfSubjects = model.NoOfSubjects,
                IsDepartmentHead = model.IsDepartmentHead,
                IsSchoolHead = model.IsSchoolHead

            };
            return copy;
        }

        public bool IsSchoolHead
        {
            get { return ModelCopy.IsSchoolHead; }
            set
            {
                ModelCopy.IsSchoolHead = value;
                RaisePropertyChanged(nameof(IsSchoolHead));
            }
        }

        public bool IsDepartmentHead
        {
            get { return ModelCopy.IsDepartmentHead; }
            set
            {
                ModelCopy.IsDepartmentHead = value;
                RaisePropertyChanged(nameof(IsDepartmentHead));
            }
        }

        public int? CurrentUnits
        {
            get { return ModelCopy.CreditUnits; }
            set
            {
                ModelCopy.CreditUnits = value;
                RaisePropertyChanged(nameof(CurrentUnits));
            }
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
        public int ProfessorId
        {
            get { return ModelCopy.ProfessorId; }
            set
            {
                ModelCopy.ProfessorId = value; 
                RaisePropertyChanged(nameof(ProfessorId));
            }
        }

        public string FamilyName
        {
            get { return ModelCopy.ProfessorFamilyName; }
            set
            {
                ModelCopy.ProfessorFamilyName = value; 
                RaisePropertyChanged(nameof(FamilyName));

            }
        }

        public string FirstName
        {
            get { return ModelCopy.ProfessorFirstName; }
            set
            {
                ModelCopy.ProfessorFirstName = value; 
                RaisePropertyChanged(nameof(FirstName));

            }
        }

        public string MiddleName
        {
            get { return ModelCopy.ProfessorMiddleName; }
            set
            {
                ModelCopy.ProfessorMiddleName = value; 
                RaisePropertyChanged(nameof(MiddleName));

            }
        }

        public string Address
        {
            get { return ModelCopy.ProfessorAddress; }
            set
            {
                ModelCopy.ProfessorAddress = value; 
                RaisePropertyChanged(nameof(Address));

            }
        }

        public string ContactNo
        {
            get { return ModelCopy.ProfessorContactNumber; }
            set
            {
                ModelCopy.ProfessorContactNumber = value; 
                RaisePropertyChanged(nameof(ContactNo));

            }
        }

        public DateTime? Birthdate
        {
            get { return ModelCopy.ProfessorDateOfBirth; }
            set
            {
                ModelCopy.ProfessorDateOfBirth = value;
                RaisePropertyChanged(nameof(Birthdate));
            }
        }

        public string Status
        {
            get { return ModelCopy.ProfessorStatus; }
            set
            {
                ModelCopy.ProfessorStatus = value; 
                RaisePropertyChanged(nameof(Status));

            }
        }

        public int? DepartmentId
        {
            get { return ModelCopy.DepartmentId; }
            set
            {
                ModelCopy.DepartmentId = value; 
                RaisePropertyChanged(nameof(DepartmentId));

            }
        }

        public ObservableCollection<string> StatusList { get; } = new ObservableCollection<string> {"Full-Time", "Part-Time"};
        public ObservableCollection<DepartmentModel> DepartmentList { get; } = new ObservableCollection<DepartmentModel>();
        private static readonly IRepository _Repository = new EfRepository();

        private async Task LoadDepartmentsAsync()
        {
            var departments = await _Repository.Department.GetRangeAsync(CancellationToken.None);
            foreach (var department in departments)
            {
                DepartmentList.Add(new DepartmentModel(department, _Repository));
                await Task.Delay(100);
            }
        }

        private async void LoadDepartments()
        {
            await LoadDepartmentsAsync();
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
    }
}
