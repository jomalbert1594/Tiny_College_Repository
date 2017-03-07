using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyCollege.Models.Building
{
    public class BuildingNewModel : BuildingEditModel
    {
        public BuildingNewModel() : base(new DataAccess.Ef.Building())
        {
        }
    }
    public class BuildingEditModel:EditModelBase<DataAccess.Ef.Building>
    {
        public BuildingEditModel(DataAccess.Ef.Building model) : base(model)
        {
            ModelCopy = CreateCopy(model);
        }

        private DataAccess.Ef.Building CreateCopy(DataAccess.Ef.Building model)
        {
            var copy = new DataAccess.Ef.Building
            {
                BuildingId = model.BuildingId,
                BuildingName = model.BuildingName,
                BuildingLocation = model.BuildingLocation
            };  
            return copy;
        }

        public int BuildingId
        {
            get { return ModelCopy.BuildingId; }
            set
            {
                ModelCopy.BuildingId = value; 
                RaisePropertyChanged(nameof(BuildingId));
            }
        }

        public string BuildingName
        {
            get { return ModelCopy.BuildingName; }
            set
            {
                ModelCopy.BuildingName = value; 
                RaisePropertyChanged(nameof(BuildingName));
            }
        }

        public string BuildingLocation
        {
            get { return ModelCopy.BuildingLocation; }
            set
            {
                ModelCopy.BuildingLocation = value; 
                RaisePropertyChanged(nameof(BuildingLocation));
            }
        }
    }
}
