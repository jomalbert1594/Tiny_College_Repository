using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using Nito.AsyncEx;
using TinyCollege.DataAccess;
using TinyCollege.Models.Building;
using TinyCollege.Models.Class;
using TinyCollege.Models.School;

namespace TinyCollege.Models.Room
{
    public class RoomModel:ModelBase<DataAccess.Ef.Room>, IEditable<DataAccess.Ef.Room>
    {
        public RoomModel(DataAccess.Ef.Room model, IRepository repository) : base(model, repository)
        {
        }

        public ObservableCollection<ClassModel> Classes { get; } = new ObservableCollection<ClassModel>();

        private BuildingModel _building;
        public BuildingModel Building
        {
            get { return _building; }
            set
            {
                _building = value;
                RaisePropertyChanged(nameof(Building));
            }
        }

        private async Task LoadRelatedInfoAsync()
        {
            var classes = await Task.Run(() => _Repository.Class.GetRangeAsync(c => c.RoomId == Model.RoomId, CancellationToken.None));
            Classes.Clear();
            foreach (var item in classes)
            {
                var classmodel = new ClassModel(item, _Repository);
                classmodel.LoadRelatedInfo();
                Classes.Add(classmodel);
                await Task.Delay(100);
            }

            var building = await Task.Run(() => _Repository.Building.GetAsync(b => b.BuildingId == Model.BuildingId, CancellationToken.None));
            Building = new BuildingModel(building, _Repository);
        }

        public async void LoadRelatedInfo()
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

        private EditModelBase<DataAccess.Ef.Room> _editModel;

        public EditModelBase<DataAccess.Ef.Room> EditModel
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
                await Task.Run(() => _Repository.Room.UpdateAsync(EditModel.ModelCopy, CancellationToken.None));
                Model = EditModel.ModelCopy;
                IsEditing = false;
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to Save!", "Student Update");
            }
        }

        private void SaveProc()
        {
            NotifyTaskCompletion.Create(() => SaveProcAsync());
        }

        public ICommand EditCommand => new RelayCommand(EditProc);

        private void EditProc()
        {
            EditModel?.Dispose();
            EditModel = new RoomEditModel(Model);
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
