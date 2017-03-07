using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TinyCollege.DataAccess;
using TinyCollege.Models.Professor;
using TinyCollege.Models.School;

namespace TinyCollege.Models.Department
{
    public class DepartmentNewModel : DepartmentEditModel
    {
        public DepartmentNewModel() : base(new DataAccess.Ef.Department())
        {
        }
    }
    public class DepartmentEditModel:EditModelBase<DataAccess.Ef.Department>
    {
        public DepartmentEditModel(DataAccess.Ef.Department model) : base(model)
        {
            ModelCopy = CreateCopy(model);
            LoadRelatedInfo();
        }

        private DataAccess.Ef.Department CreateCopy(DataAccess.Ef.Department model)
        {
            var copy = new DataAccess.Ef.Department
            {
                SchoolId = model.SchoolId,
                DepartmentId = model.DepartmentId,
                DepartmentName = model.DepartmentName,
                ProfessorId = model.ProfessorId
            };

            return copy;
        }

        public int DepartmentId
        {
            get { return ModelCopy.DepartmentId; }
            set
            {
                ModelCopy.DepartmentId = value; 
                RaisePropertyChanged(nameof(DepartmentId));
            }
        }

        public string DepartmentName
        {
            get { return ModelCopy.DepartmentName; }
            set
            {
                ModelCopy.DepartmentName = value;
                RaisePropertyChanged(nameof(DepartmentName));
            }
        }

        public int? SchoolId
        {
            get { return ModelCopy.SchoolId; }
            set
            {
                ModelCopy.SchoolId = value;
                RaisePropertyChanged(nameof(SchoolId));
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

        private static readonly IRepository _Repository = new EfRepository();

        public ObservableCollection<SchoolModel> SchoolList { get; } = new ObservableCollection<SchoolModel>();
        public ObservableCollection<ProfessorModel> ProfessorList { get; } = new ObservableCollection<ProfessorModel>();

        private async Task LoadRelatedInfoAsync()
        {
            var schools = await _Repository.School.GetRangeAsync(CancellationToken.None);
            foreach (var school in schools)
            {
                var schoolmodel = new SchoolModel(school, _Repository);
                SchoolList.Add(schoolmodel);
                await Task.Delay(100);
            }

            var professors = await _Repository.Professor.GetRangeAsync(p => p.DepartmentId == ModelCopy.DepartmentId, CancellationToken.None); // Load the professors in that particular department
            foreach (var professor in professors.Where(p => p.IsDepartmentHead == false))
            {
                var professormodel = new ProfessorModel(professor, _Repository);
                professormodel.LoadRelatedInfo();
                ProfessorList.Add(professormodel);
                await Task.Delay(100);
            }
        }

        private async void LoadRelatedInfo()
        {
            await LoadRelatedInfoAsync();
        }

        private SchoolModel _school;

        public SchoolModel School
        {
            get { return _school; }
            set
            {
                _school = value;
                if (value != null)
                {
                    SchoolId = _school.Model.SchoolId;
                }
                RaisePropertyChanged(nameof(School));
            }
        }

        private ProfessorModel _professor;

        public ProfessorModel Professor
        {
            get { return _professor; }
            set
            {
                _professor = value;
                if (value != null)
                {
                    ProfessorId = _professor.Model.ProfessorId;
                }
                RaisePropertyChanged(nameof(Professor));
            }
        }
    }
}
