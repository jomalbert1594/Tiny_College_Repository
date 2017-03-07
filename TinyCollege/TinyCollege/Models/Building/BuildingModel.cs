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
using TinyCollege.DataAccess;
using TinyCollege.Models.Class;
using TinyCollege.Models.Room;

namespace TinyCollege.Models.Building
{
    public class BuildingModel:ModelBase<DataAccess.Ef.Building>, IEditable<DataAccess.Ef.Building>
    {
        public BuildingModel(DataAccess.Ef.Building model, IRepository repository) : base(model, repository)
        {
        }

        public ObservableCollection<RoomModel> RoomList { get; } = new ObservableCollection<RoomModel>();

        private async Task LoadRelatedInfoAsync()
        {
            var rooms = await _Repository.Room.GetRangeAsync(r => r.BuildingId == Model.BuildingId, CancellationToken.None);
            RoomList.Clear();
            foreach (var room in rooms)
            {
                var roommodel = new RoomModel(room, _Repository);
                roommodel.LoadRelatedInfo();
                RoomList.Add(roommodel);
                await Task.Delay(100);
            }
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

        private EditModelBase<DataAccess.Ef.Building> _editModel;

        public EditModelBase<DataAccess.Ef.Building> EditModel
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
                await _Repository.Building.UpdateAsync(EditModel.ModelCopy, CancellationToken.None);
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
            await SaveProcAsync();
        }

        public ICommand EditCommand => new RelayCommand(EditProc);

        private void EditProc()
        {
            EditModel?.Dispose();
            EditModel = new BuildingEditModel(Model);
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
