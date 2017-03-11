using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinyCollege.DataAccess;
using TinyCollege.Models.Student;

namespace TinyCollege.Models.Grade
{
    public class GradeNewModel : GradeEditModel
    {
        public GradeNewModel() : base(new DataAccess.Ef.Grade())
        {
        }
    }
    public class GradeEditModel : EditModelBase<DataAccess.Ef.Grade>
    {
        public GradeEditModel(DataAccess.Ef.Grade model) : base(model)
        {
            ModelCopy = CreateCopy(model);
            LoadRelatedInfo();
        }

        private DataAccess.Ef.Grade CreateCopy(DataAccess.Ef.Grade model)
        {
            var copy = new DataAccess.Ef.Grade
            {
                Prelim = model.Prelim,
                EnrollmentId = model.EnrollmentId,
                Final = model.Final,
                GradeId = model.GradeId,
                Midterm = model.Midterm,
                Prefinal = model.Prefinal
            };

            return copy;
        }

        // Display Purposes

        private static readonly  IRepository _Repository = new EfRepository();

        private StudentModel _student;
        public StudentModel Student
        {
            get { return _student; }
            set
            {
                _student = value;
                RaisePropertyChanged(nameof(Student));
            }
        }

        private async Task LoadRelatedInfoAsync()
        {
            var enrollment = await Task.Run(() => _Repository.Enrollment.GetAsync(e => e.EnrollmentId == EnrollmentId, CancellationToken.None));
            var student =
                await Task.Run(() => _Repository.Student.GetAsync(s => enrollment.StudentId == s.StudentId, CancellationToken.None));

            Student = new StudentModel(student, _Repository);
        }

        private async void LoadRelatedInfo()
        {
            await LoadRelatedInfoAsync();
        }
              

        // Editing Purposes
        public int GradeId
        {
            get { return ModelCopy.GradeId; }
            set
            {
                ModelCopy.GradeId = value;
                RaisePropertyChanged(nameof(GradeId));
            }
        }

        public int? EnrollmentId
        {
            get { return ModelCopy.EnrollmentId; }
            set
            {
                ModelCopy.EnrollmentId = value;
                RaisePropertyChanged(nameof(EnrollmentId));
            }
        }

        public double? Prelim
        {
            get { return ModelCopy.Prelim; }
            set
            {
                ModelCopy.Prelim = value;
                RaisePropertyChanged(nameof(Prelim));
            }
        }

        public double? Midterm
        {
            get { return ModelCopy.Midterm; }
            set
            {
                ModelCopy.Midterm = value;
                RaisePropertyChanged(nameof(Midterm));
            }
        }

        public double? Prefinal
        {
            get { return ModelCopy.Prefinal; }
            set
            {
                ModelCopy.Prefinal = value;
                RaisePropertyChanged(nameof(Prefinal));
            }
        }

        public double? Final
        {
            get { return ModelCopy.Final; }
            set
            {
                ModelCopy.Final = value;
                RaisePropertyChanged(nameof(Final));
            }
        }

    }
}
