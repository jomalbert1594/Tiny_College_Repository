using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using TinyCollege.DataAccess;
using TinyCollege.Models.Course;
using TinyCollege.Models.Professor;
using TinyCollege.Models.Room;

namespace TinyCollege.Models.Class
{
    public class ClassNewModel : ClassEditModel
    {
        public ClassNewModel() : base(new DataAccess.Ef.Class())
        {
        }
    }
    public class ClassEditModel:EditModelBase<DataAccess.Ef.Class>
    {
        public ClassEditModel(DataAccess.Ef.Class model) : base(model)
        {
            ModelCopy = CreateCopy(model);
            LoadRelatedInfo();
        }

        private DataAccess.Ef.Class CreateCopy(DataAccess.Ef.Class model)
        {
            var copy = new DataAccess.Ef.Class
            {
                ProfessorId = model.ProfessorId,
                CourseId = model.CourseId,
                ClassId = model.ClassId,
                ClassName = model.ClassName,
                Time = model.Time,
                Day = model.Day,
                RoomId = model.RoomId,
                Capacity = model.Capacity
            };

            return copy;
        }

        public int? Capacity
        {
            get { return ModelCopy.Capacity; }
            set
            {
                ModelCopy.Capacity = value;
                RaisePropertyChanged(nameof(Capacity));
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

        public string ClassName
        {
            get { return ModelCopy.ClassName; }
            set
            {
                ModelCopy.ClassName = value;
                RaisePropertyChanged(nameof(ClassName));
            }
        }

        public string Time
        {
            get { return ModelCopy.Time; }
            set
            {
                ModelCopy.Time = value;
                RaisePropertyChanged(nameof(Time));
            }
        }


        public string Day
        {
            get { return ModelCopy.Day; }
            set
            {
                ModelCopy.Day = value;
                RaisePropertyChanged(nameof(Day));
            }
        }

        public string CourseId
        {
            get { return ModelCopy.CourseId; }
            set
            {
                ModelCopy.CourseId = value;
                RaisePropertyChanged(nameof(CourseId));
            }
        }

        public int? ProfessorId
        {
            get { return ModelCopy.ProfessorId; }
            set
            {
                ModelCopy.ProfessorId = value;
                RaisePropertyChanged(nameof(ProfessorId));
            }
        }

        public int? RoomId
        {
            get { return ModelCopy.RoomId; }
            set
            {
                ModelCopy.RoomId = value;
                RaisePropertyChanged(nameof(RoomId));
            }
        }

        private static readonly  IRepository _Repository = new EfRepository();

        private async Task LoadRelatedInfoAsync()
        {
            var rooms = await Task.Run(() => _Repository.Room.GetRangeAsync(CancellationToken.None));
            foreach (var room in rooms)
            {
                RoomList.Add(new RoomModel(room, _Repository));
                await Task.Delay(100);
            }

            var courses = await Task.Run(() => _Repository.Course.GetRangeAsync(CancellationToken.None));

            foreach (var course in courses)
            {
                CourseList.Add(new CourseModel(course, _Repository));
                await Task.Delay(100);
            }
        }

        private async void LoadRelatedInfo()
        {
            await LoadRelatedInfoAsync();
        }

        public ObservableCollection<RoomModel> RoomList { get; } = new ObservableCollection<RoomModel>();
        public ObservableCollection<CourseModel> CourseList { get; } = new ObservableCollection<CourseModel>();
        public ObservableCollection<Schedule> ScheduleList { get; } = new ObservableCollection<Schedule>();
        
        private RoomModel _selectedroom;
        public RoomModel SelectedRoom
        {
            get { return _selectedroom; }
            set
            {
                _selectedroom = value;
                if (value != null)
                {
                    ModelCopy.RoomId = _selectedroom.Model.RoomId;
                    _room = _selectedroom;
                }
                RaisePropertyChanged(nameof(Room));
            }
        }

        private RoomModel _room;
        public RoomModel Room
        {
            get { return _room; }
            set
            {
                _room = value;
                if (value != null)
                {
                    var index = RoomList.IndexOf(_room);
                    RoomId = _room.Model.RoomId;
                    _roomindex = index;
                }
                RaisePropertyChanged(nameof(Room));
            }
        }


        private int _roomindex;
        public int RoomIndex
        {
            get { return _roomindex; }
            set
            {
                _roomindex = value;
                RaisePropertyChanged(nameof(RoomIndex));
            }
        }

        private CourseModel _course;
        
        public CourseModel Course
        {
            get { return _course; }
            set
            {
                _course = value;
                if (value != null)
                {
                    ModelCopy.CourseId = _course.Model.CourseId;
                }
                RaisePropertyChanged(nameof(Course));
            }
        }

        private Schedule _selectedSchedule;

        public Schedule SelectedSchedule
        {
            get { return _selectedSchedule; }
            set
            {
                _selectedSchedule = value;
                RaisePropertyChanged(nameof(SelectedSchedule));
            }
        }

        public ICommand AddScheduleCommand => new RelayCommand(AddScheduleProc);

        private void AddScheduleProc()
        {
            ScheduleList.Add(new Schedule());
        }

        public ICommand DeleteScheduleCommand => new RelayCommand(DeleteScheduleProc,DeleteSchduleCondition);

        private bool DeleteSchduleCondition()
        {
            return (SelectedSchedule != null);
        }

        private void DeleteScheduleProc()
        {
            if (SelectedSchedule == null) return;
            try
            {
                ScheduleList.Remove(SelectedSchedule);
            }
            catch (Exception e) { }
        }
    }

    public class Schedule : ObservableObject
    {
        public ObservableCollection<string> DayList { get; } = new ObservableCollection<string>
        {
            "All",
            "M",
            "T",
            "W",
            "TH",
            "F",
            "Sa"
        };

        private string _selectedDay;
        public string SelectedDay
        {
            get { return _selectedDay; }
            set
            {
                _selectedDay = value;
                RaisePropertyChanged(nameof(SelectedDay));
            }
        }


        private DateTime _timeStart;
        public DateTime TimeStart
        {
            get { return _timeStart; }
            set
            {
                _timeStart = value;
                RaisePropertyChanged(nameof(TimeStart));
            }
        }

        private DateTime _timeEnd;
        public DateTime TimeEnd
        {
            get { return _timeEnd; }
            set
            {
                _timeEnd = value;
                RaisePropertyChanged(nameof(TimeEnd));
            }
        }

    }
}
