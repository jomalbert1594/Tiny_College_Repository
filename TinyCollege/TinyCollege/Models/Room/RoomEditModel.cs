using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;
using Nito.AsyncEx;
using TinyCollege.DataAccess;
using TinyCollege.Models.Building;

namespace TinyCollege.Models.Room
{
    public class RoomNewModel : RoomEditModel
    {
        public RoomNewModel() : base(new DataAccess.Ef.Room())
        {
        }
    }
    public class RoomEditModel:EditModelBase<DataAccess.Ef.Room>
    {
        public RoomEditModel(DataAccess.Ef.Room model) : base(model)
        {
            ModelCopy = CreateCopy(model);
            LoadRelatedInfo();
        }

        private DataAccess.Ef.Room CreateCopy(DataAccess.Ef.Room model)
        {
            var copy = new DataAccess.Ef.Room
            {
                RoomName = model.RoomName,
                BuildingId = model.BuildingId,
                RoomId = model.RoomId
            };
            return copy;
        }
        public int RoomId
        {
            get { return ModelCopy.RoomId; }
            set
            {
                ModelCopy.RoomId = value; 
                RaisePropertyChanged(nameof(RoomId));
            }
        }

        public string RoomName
        {
            get { return ModelCopy.RoomName; }
            set
            {
                ModelCopy.RoomName = value; 
                RaisePropertyChanged(nameof(RoomName));
            }
        }

        public int? BuildingId
        {
            get { return ModelCopy.BuildingId; }
            set
            {
                ModelCopy.BuildingId = value; 
                RaisePropertyChanged(nameof(BuildingId));
            }
        }

        private static readonly IRepository _Repository = new EfRepository();
        public ObservableCollection<BuildingModel> BuildingList { get; } = new ObservableCollection<BuildingModel>();

        private BuildingModel _building;

        public BuildingModel Building
        {
            get { return _building; }
            set
            {
                _building = value;
                if (value != null)
                {
                    BuildingId = Building.Model.BuildingId;
                }
                RaisePropertyChanged(nameof(Building));
            }
        }

        private async Task LoadRelatedInfoAsync()
        {
            var buildings = await Task.Run(() => _Repository.Building.GetRangeAsync(CancellationToken.None));
            foreach (var building in buildings)
            {
                BuildingList.Add(new BuildingModel(building, _Repository));
                await Task.Delay(100);
            }
        }

        private void LoadRelatedInfo()
        {
            NotifyTaskCompletion.Create(() => LoadRelatedInfoAsync());

        }
    }
}
