using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using Nito.AsyncEx;
using TinyCollege.DataAccess;
using TinyCollege.Models.Class;
using TinyCollege.Models.Department;
using TinyCollege.Models.Room;
using TinyCollege.Models.School;
using TinyCollege.Models.Student;
using MessageBox = System.Windows.MessageBox;

namespace TinyCollege.Models.Professor
{
    public class ProfessorModel:ModelBase<DataAccess.Ef.Professor>, IEditable<DataAccess.Ef.Professor>
    {
        public ProfessorModel(DataAccess.Ef.Professor model, IRepository repository) : base(model, repository)
        {
        }


        public ObservableCollection<ClassModel>  Classes { get; } = new ObservableCollection<ClassModel>();



        private ClassModel _selectedClass;

        public ClassModel SelectedClass
        {
            get { return _selectedClass; }
            set
            {
                _selectedClass = value;
                if (value != null)
                {
                    _selectedClass.LoadRelatedInfo();
                }
                RaisePropertyChanged(nameof(SelectedClass));
            }
        }
        private SchoolModel _school;
        public SchoolModel School
        {
            get { return _school; }
            set
            {
                _school = value;
                RaisePropertyChanged(nameof(School));
            }
        }

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

        private DepartmentModel _department;
        public DepartmentModel Department
        {
            get { return _department; }
            set
            {
                _department = value;
                RaisePropertyChanged(nameof(Department));
            }
        }

        private async Task LoadRelatedInfoAsync()
        {
            var department = await Task.Run(() => _Repository.Department.GetAsync(d => d.DepartmentId == Model.DepartmentId, CancellationToken.None));
            Department = new DepartmentModel(department, _Repository);

            var classes = await Task.Run(() => _Repository.Class.GetRangeAsync(c => c.ProfessorId == Model.ProfessorId, CancellationToken.None));
            Classes.Clear();
            foreach (var item in classes)
            {
                var classmodel = new ClassModel(item, _Repository);
                classmodel.LoadRelatedInfo();
                Classes.Add(classmodel);
                await Task.Delay(100);
            }

            var student = await Task.Run(() => _Repository.Student.GetAsync(s => s.ProfessorId == Model.ProfessorId, CancellationToken.None));
            Student = new StudentModel(student, _Repository);

            var school = await Task.Run(() => _Repository.School.GetAsync(s => s.ProfessorId == Model.ProfessorId, CancellationToken.None));
            School = new SchoolModel(school, _Repository);
        }

        public void LoadRelatedInfo()
        {
            NotifyTaskCompletion.Create(() => LoadRelatedInfoAsync());

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

        private bool _isViewingClassList;

        public bool IsViewingClassList
        {
            get { return _isViewingClassList;}
            set
            {
                _isViewingClassList = value;
                RaisePropertyChanged(nameof(IsViewingClassList));
            }
        }
        private EditModelBase<DataAccess.Ef.Professor> _editModel;

        public EditModelBase<DataAccess.Ef.Professor> EditModel
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

        private async Task SaveProcAsync()
        {
            if (EditModel == null) return;
            if (!EditModel.HasChanges) return;

            try
            {
                await Task.Run(() => _Repository.Professor.UpdateAsync(EditModel.ModelCopy, CancellationToken.None));
                Model = EditModel.ModelCopy;
                IsEditing = false;
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to Save!", "Student Update", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void SaveProc()
        {
            NotifyTaskCompletion.Create(() => SaveProcAsync());

        }

        public ICommand EditCommand => new RelayCommand(EditProc);

        private void EditProc()
        {
            EditModel?.Dispose();
            EditModel = new ProfessorEditModel(Model);
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
