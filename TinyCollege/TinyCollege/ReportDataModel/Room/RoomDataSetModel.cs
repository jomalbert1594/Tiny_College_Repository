using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using TinyCollege.Models.Class;
using TinyCollege.Models.Room;

namespace TinyCollege.ReportDataModel.Room
{
    public class RoomDataSetModel:ObservableObject
    {
        private string _roomName;
        private string _buildingName;
        private string _classCode;
        private string _courseName;
        private string _classDescription;
        private string _day;
        private string _time;

        public RoomDataSetModel(ClassModel classmodel)
        {
            _roomName = classmodel.Room?.Model?.RoomName;
            _buildingName = classmodel.Room?.Building?.Model.BuildingName;
            _classCode = classmodel.Model.ClassId;
            _courseName = classmodel.Course?.Model?.CourseName;
            _classDescription = classmodel.Model?.ClassName;
            _day = classmodel.Model?.Day;
            _time = classmodel.Model?.Time;
        }

        public string RoomName
        {
            get { return _roomName; }
            set
            {
                _roomName = value; 
                RaisePropertyChanged(nameof(RoomName));
            }
        }

        public string BuildingName
        {
            get { return _buildingName; }
            set
            {
                _buildingName = value; 
                RaisePropertyChanged(nameof(BuildingName));
            }
        }

        public string ClassCode
        {
            get { return _classCode; }
            set
            {
                _classCode = value; 
                RaisePropertyChanged(nameof(ClassCode));
            }
        }

        public string CourseName
        {
            get { return _courseName; }
            set
            {
                _courseName = value;
                RaisePropertyChanged(nameof(CourseName));
            }
        }

        public string ClassDescription
        {
            get { return _classDescription; }
            set
            {
                _classDescription = value; 
                RaisePropertyChanged(nameof(ClassDescription));
            }
        }

        public string Day
        {
            get { return _day; }
            set
            {
                _day = value; 
                RaisePropertyChanged(nameof(Day));
            }
        }

        public string Time
        {
            get { return _time; }
            set
            {
                _time = value; 
                RaisePropertyChanged(nameof(Time));
            }
        }
    }
}
