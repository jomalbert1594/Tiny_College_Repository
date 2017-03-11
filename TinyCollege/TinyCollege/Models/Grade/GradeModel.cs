using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using TinyCollege.DataAccess;
using TinyCollege.Models.Class;
using TinyCollege.Models.Course;
using TinyCollege.Models.Enrollment;
using TinyCollege.Models.Room;
using TinyCollege.Models.Student;
using MessageBox = System.Windows.Forms.MessageBox;

namespace TinyCollege.Models.Grade
{
    public class GradeModel:ModelBase<DataAccess.Ef.Grade>, IEditable<DataAccess.Ef.Grade>
    {
        public GradeModel(DataAccess.Ef.Grade model, IRepository repository) : base(model, repository)
        {
        }

        private StudentModel _student;

        public StudentModel Student
        {
            get { return _student;}
            set
            {
                _student = value;
                RaisePropertyChanged(nameof(Student));
            }
        }

        private ClassModel _class;

        public ClassModel Class
        {
            get { return _class; }
            set
            {
                _class = value;
                RaisePropertyChanged(nameof(Class));
            }
        }

        public async Task LoadRelatedInfoAsync()
        {
            var enrollment = await Task.Run(() => _Repository.Enrollment.GetAsync(e => e.EnrollmentId == Model.EnrollmentId, CancellationToken.None));
            var classobj = await Task.Run(() => _Repository.Class.GetAsync(c => c.ClassId == enrollment.ClassId, CancellationToken.None));
            var student = await Task.Run(() => _Repository.Student.GetAsync(s => s.StudentId == enrollment.StudentId, CancellationToken.None));
            Student = new StudentModel(student, _Repository);
            Class = new ClassModel(classobj, _Repository);
            Class.LoadRelatedInfo();
        }

        public async void LoadRelatedInfo()
        {
            await LoadRelatedInfoAsync();
        }

        private bool _isEditing;

        public bool IsEditing
        {
            get { return _isEditing; }
            set
            {
                _isEditing = value;
                RaisePropertyChanged(nameof(IsEditing));
            }
        }

        private EditModelBase<DataAccess.Ef.Grade> _editModel;

        public EditModelBase<DataAccess.Ef.Grade> EditModel
        {
            get { return _editModel; }
            set
            {
                _editModel = value;
                RaisePropertyChanged(nameof(EditModel));
            }
        }
        public ICommand SaveCommand => new RelayCommand(SaveProc, SaveCondition);

        private bool SaveCondition()
        {
            return (EditModel != null);
        }

        private void SaveProc()
        {
            if (EditModel == null) return;

            try
            {
                _Repository.Grade.UpdateAsync(EditModel.ModelCopy, CancellationToken.None);
                Model = EditModel.ModelCopy;
                _isEditing = false;
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable To Save!", "Edit Grade", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public ICommand EditCommand => new RelayCommand(EditProc);

        private void EditProc()
        {   
            EditModel?.Dispose();
            EditModel = new GradeEditModel(Model);
            _isEditing = true;
        }

        public ICommand CancelCommand => new RelayCommand(CancelProc);

        private void CancelProc()
        {
            EditModel?.Dispose();
            _isEditing = false;
        }
    }
}
