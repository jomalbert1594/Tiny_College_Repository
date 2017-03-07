using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TinyCollege.Models.Enrollment
{
    public class EnrollmentNewModel : EnrollmentEditModel
    {
        public EnrollmentNewModel() : base(new DataAccess.Ef.Enrollment())
        {
        }
    }
    public class EnrollmentEditModel:EditModelBase<DataAccess.Ef.Enrollment>
    {
        public EnrollmentEditModel(DataAccess.Ef.Enrollment model) : base(model)
        {
            ModelCopy = CreateCopy(model);
        }

        private DataAccess.Ef.Enrollment CreateCopy(DataAccess.Ef.Enrollment model)
        {
            var copy = new DataAccess.Ef.Enrollment
            {
                EnrollmentDate = model.EnrollmentDate,
                ClassId = model.ClassId,
                EnrollmentGrade = model.EnrollmentGrade,
                EnrollmentId = model.EnrollmentId,
                StudentId = model.StudentId
            };
            return copy;
        }
        public int EnrollmentId
        {
            get { return ModelCopy.EnrollmentId; }
            set
            {
                ModelCopy.EnrollmentId = value; 
                RaisePropertyChanged(nameof(EnrollmentId));
            }
        }

        public DateTime? EnrollmentDate
        {
            get { return ModelCopy.EnrollmentDate; }
            set
            {
                ModelCopy.EnrollmentDate = value;
                RaisePropertyChanged(nameof(EnrollmentDate));
            }
        }

        public string EnrollmentGrade
        {
            get { return ModelCopy.EnrollmentGrade; }
            set
            {
                ModelCopy.EnrollmentGrade = value;
                RaisePropertyChanged(nameof(EnrollmentGrade));
            }
        }

        public int? StudentId
        {
            get { return ModelCopy.StudentId; }
            set
            {
                ModelCopy.StudentId = value;
                RaisePropertyChanged(nameof(StudentId));
            }
        }

        public string ClassId
        {
            get { return ModelCopy.ClassId; }
            set
            {
                ModelCopy.ClassId = value;
                RaisePropertyChanged(nameof(ClassId));
            }
        }
    }
}