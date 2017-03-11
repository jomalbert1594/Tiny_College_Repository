using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Markup;
using TinyCollege.DataAccess;
using TinyCollege.Models.Department;

namespace TinyCollege.Models.Course
{
    public class CourseNewModel : CourseEditModel
    {
        public CourseNewModel() : base(new DataAccess.Ef.Course())
        {
        }
    }
    public class CourseEditModel:EditModelBase<DataAccess.Ef.Course>
    {
        public CourseEditModel(DataAccess.Ef.Course model) : base(model)
        {
            ModelCopy = CreateCopy(model);
            LoadRelatedInfo();
        }

        private DataAccess.Ef.Course CreateCopy(DataAccess.Ef.Course model)
        {
            var copy = new DataAccess.Ef.Course
            {
                CourseId = model.CourseId,
                CourseName = model.CourseName,
                CourseUnits = model.CourseUnits,
                DepartmentId = model.DepartmentId
            };

            return copy;
        }

        public string CourseId
        {
            get { return ModelCopy.CourseId; }
            set
            {
                ModelCopy.CourseId = value; 
                RaisePropertyChanged(nameof(CourseId));
            }
        }

        public string CourseName
        {
            get { return ModelCopy.CourseName; }
            set
            {
                ModelCopy.CourseName = value; 
                RaisePropertyChanged(nameof(CourseName));
            }
        }

        public int? CourseUnits
        {
            get { return ModelCopy.CourseUnits; }
            set
            {
                ModelCopy.CourseUnits = value; 
                RaisePropertyChanged(nameof(CourseUnits));
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

        private static readonly IRepository _Repository = new EfRepository();
        public ObservableCollection<DepartmentModel> DepartmentList { get; } = new ObservableCollection<DepartmentModel>();

        private DepartmentModel _department;
        public DepartmentModel Department
        {
            get { return _department; }
            set
            {
                _department = value;
                if (value != null)
                {
                    DepartmentId = Department.Model.DepartmentId;
                }
                RaisePropertyChanged(nameof(Department));
            }
        }

        private async Task LoadRelatedInfoAsync()
        {
            var departments = await Task.Run(() => _Repository.Department.GetRangeAsync(CancellationToken.None));
            foreach (var department in departments)
            {
                DepartmentList.Add(new DepartmentModel(department, _Repository));
                await Task.Delay(100);
            }
        }

        private async void LoadRelatedInfo()
        {
            await LoadRelatedInfoAsync();
        }

    }
}
