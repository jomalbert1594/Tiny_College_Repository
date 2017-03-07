using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using TinyCollege.DataAccess;
using TinyCollege.Models.Class;
using TinyCollege.Models.Grade;
using TinyCollege.Models.Professor;
using TinyCollege.Models.Room;
using TinyCollege.Models.Student;

namespace TinyCollege.Models.Enrollment
{
    public class EnrollmentModel:ModelBase<DataAccess.Ef.Enrollment>, IEditable<DataAccess.Ef.Enrollment>
    {
        public EnrollmentModel(DataAccess.Ef.Enrollment model, IRepository repository) : base(model, repository)
        {}

        // Related Models

        private GradeModel _grade;

        public GradeModel Grade
        {
            get { return _grade; }
            set
            {
                _grade = value;
                RaisePropertyChanged(nameof(Grade));
            }
        }

        private ClassModel _class;
        public ClassModel Class
        {
            get { return _class; }
            set
            {
                _class = value;
                if (value != null)
                {
                    _class.LoadRelatedInfo();
                }
                RaisePropertyChanged(nameof(Class));
            }
        }

        private async Task LoadRelatedInfoAsync()
        {
            var classvar = await _Repository.Class.GetAsync(c => c.ClassId == Model.ClassId, CancellationToken.None);
            Class = new ClassModel(classvar, _Repository);

            var grade =
                await _Repository.Grade.GetAsync(g => g.EnrollmentId == Model.EnrollmentId, CancellationToken.None);
            Grade = new GradeModel(grade, _Repository);

        }

        public async void LoadRelatedInfo()
        {
            await LoadRelatedInfoAsync();
        }


        // Attributes

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

        private EditModelBase<DataAccess.Ef.Enrollment> _editModel;

        public EditModelBase<DataAccess.Ef.Enrollment> EditModel
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
            return (EditModel != null) && EditModel.HasChanges && !EditModel.HasErrors;
        }

        private async Task SaveProcASync()
        {
            if (EditModel == null) return;
            if (!EditModel.HasChanges) return;
            try
            {
                await _Repository.Enrollment.UpdateAsync(EditModel.ModelCopy, CancellationToken.None);
                Model = EditModel.ModelCopy;
                IsEditing = false;
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to Save!", "Student Update");
            }
        }
        private async void SaveProc()
        {
            await SaveProcASync();
        }

        public ICommand EditCommand => new RelayCommand(EditProc);

        private void EditProc()
        {
            EditModel?.Dispose();
            EditModel = new EnrollmentEditModel(Model);
            IsEditing = true;
        }

        public ICommand CancelCommand => new RelayCommand(CancelProc);

        private void CancelProc()
        {
            EditModel?.Dispose();
            IsEditing = false;
        }
    }
}
