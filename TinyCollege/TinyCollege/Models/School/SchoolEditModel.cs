using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TinyCollege.DataAccess;
using TinyCollege.Models.Professor;

namespace TinyCollege.Models.School
{
    public class SchoolNewModel : SchoolEditModel
    {
        public SchoolNewModel() : base(new DataAccess.Ef.School())
        {
        }
    }
    public class SchoolEditModel:EditModelBase<DataAccess.Ef.School>
    {
        public SchoolEditModel(DataAccess.Ef.School model) : base(model)
        {
            ModelCopy = CreateCopy(model);
            LoadRelatedInfo();
        }

        private DataAccess.Ef.School CreateCopy(DataAccess.Ef.School model)
        {
            var copy = new DataAccess.Ef.School
            {
                SchoolId = model.SchoolId,
                ProfessorId = model.ProfessorId,
                SchoolName = model.SchoolName,
                SchoolAddress = model.SchoolAddress,           
            };

            return copy;
        }

        public int SchoolId
        {
            get { return ModelCopy.SchoolId; }
            set
            {
                ModelCopy.SchoolId = value; 
                RaisePropertyChanged(nameof(SchoolId));
            }
        }

        public string SchoolName
        {
            get { return ModelCopy.SchoolName; }
            set
            {
                ModelCopy.SchoolName = value; 
                RaisePropertyChanged(nameof(SchoolName));
            }
        }

        public string Address
        {
            get { return ModelCopy.SchoolAddress; }
            set
            {
                ModelCopy.SchoolAddress = value; 
                RaisePropertyChanged(nameof(Address));
            }
        }

        public int? ProfessorId
        {
            get { return ModelCopy.ProfessorId; }
            set
            {
                ModelCopy.ProfessorId = value; 
                RaisePropertyChanged(nameof(Professor));
            }
        }

        private static readonly IRepository _Repository = new EfRepository();

        private async Task LoadRelatedInfoAsync()
        {
            var departments = await Task.Run(() => _Repository.Department.GetRangeAsync(d => d.SchoolId == ModelCopy.SchoolId, CancellationToken.None));
            ProfessorList.Clear();
            foreach (var department in departments)
            {
                var professors = await Task.Run(() => _Repository.Professor.GetRangeAsync(p => p.DepartmentId == department.DepartmentId, CancellationToken.None));
                foreach (var professor in professors.Where(p => p.IsSchoolHead == false))
                {
                    var professormodel = new ProfessorModel(professor, _Repository);
                    professormodel.LoadRelatedInfo();
                    ProfessorList.Add(professormodel);
                }

                await Task.Delay(100);
            }
        }

        private async void LoadRelatedInfo()
        {
            await LoadRelatedInfoAsync();
        }

        public ObservableCollection<ProfessorModel> ProfessorList { get; } = new ObservableCollection<ProfessorModel>();

        private ProfessorModel _professor;

        public ProfessorModel Professor
        {
            get { return _professor; }
            set
            {
                _professor = value;
                if (value != null)
                {
                    ProfessorId = Professor.Model.ProfessorId;
                }
                RaisePropertyChanged(nameof(Professor));
            }
        }

    }
}
