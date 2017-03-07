using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using NewGoodReading.Helpers.ReportViewer;
using TinyCollege.DataAccess;
using TinyCollege.Models.Building;
using TinyCollege.Models.Class;
using TinyCollege.Modules;
using TinyCollege.ReportDataModel.Professor;
using TinyCollege.ReportDataModel.Room;

namespace TinyCollege.Reports.Room
{
    /// <summary>
    /// Interaction logic for RoomReportWindow.xaml
    /// </summary>
    public partial class RoomReportWindow : Window, INotifyPropertyChanged
    {
        private ReportViewBuilder _reportView;
        private string _selectedDay;
        private static readonly IRepository _Repository = new EfRepository();
        private bool _isByTime;
        private string _selecteDay;
        private TimeSpan _startTime;
        private TimeSpan _endTime;
        private BuildingModel _building;
        private bool _isByBuilding;


        public RoomReportWindow()
        {
            InitializeComponent();
            _reportView = new ReportViewBuilder("TinyCollege.Reports.Room.RoomReportViewer.rdlc", UpdateDatasetSource());
            _reportView.RefreshDataSourceCallback = UpdateDatasetSource;
            ReportContainer.Content = _reportView.ReportContent;
            Schedule = new Schedule();
        }

        public Schedule Schedule { get; set; }

        public BuildingModel Building
        {
            get { return _building; }
            set
            {
                _building = value;
                _reportView.ReportContent.UpdateDataSource(UpdateDatasetSource());
            }
        }

        public bool IsByTime
        {
            get { return _isByTime; }
            set
            {
                _isByTime = value;
                ViewModelLocatorStatic.Locator.RoomModule.IsByTime = _isByTime;
            }
        }

        public bool IsByBuilding
        {
            get { return _isByBuilding; }
            set
            {
                _isByBuilding = value;
                ViewModelLocatorStatic.Locator.RoomModule.IsByBuilding = _isByBuilding;
                _reportView.ReportContent.UpdateDataSource(UpdateDatasetSource());
            }
        }

        public string SelectedDay
        {
            get { return _selecteDay; }
            set
            {
                _selecteDay = value;
                if (value != null)
                {
                    _reportView.ReportContent.UpdateDataSource(UpdateDatasetSource());
                }
                
            }
        }

        public TimeSpan StartTime
        {
            get { return _startTime; }
            set
            {
                _startTime = value;
                _reportView.ReportContent.UpdateDataSource(UpdateDatasetSource());
            }
        }

        public TimeSpan EndTime
        {
            get { return _endTime; }
            set
            {
                _endTime = value;
                _reportView.ReportContent.UpdateDataSource(UpdateDatasetSource());
            }
        }


        public IReadOnlyCollection<DataSetValuePair> UpdateDatasetSource()
        {
            var sources = new List<DataSetValuePair>();
            var classes = ViewModelLocatorStatic.Locator.ClassModule.ClassList;
            var classcollection = new ObservableCollection<RoomDataSetModel>();
            var filteredclasses = new ObservableCollection<RoomDataSetModel>();

            foreach (var item in classes)
            {
                var roommodel = new ClassModel(item.Model, _Repository);
                roommodel.LoadRelatedInfo();
                classcollection.Add(new RoomDataSetModel(roommodel));
            }

            // filter classes by day
            try
            {
                if (SelectedDay.Contains("All"))
                {
                    var classrooms = _Repository.Class.GetRange(c => c.Day.Contains(SelectedDay));

                    foreach (var item in classrooms)
                    {
                        var classroommodel = new ClassModel(item, _Repository);
                        classroommodel.LoadRelatedInfo();
                        filteredclasses.Add(new RoomDataSetModel(classroommodel));
                    }
                    classcollection = new ObservableCollection<RoomDataSetModel>(filteredclasses);
                }
            }
            catch(Exception e) { }

            // filter classes by time
            if (IsByTime)
            {
                foreach (var item in classcollection)
                {
                    var timeinterval = StartTime.ToString("H:mm") + '-' + EndTime.ToString("H:mm");
                    if (IsTimeInBetween(item.Time.Trim(), timeinterval.Trim()))
                    {
                        filteredclasses.Add(item);
                    }
                }
                classcollection = new ObservableCollection<RoomDataSetModel>(filteredclasses);
            }

            // filter classes by building

            if (IsByBuilding)
            {
                
            }

            sources.Add(new DataSetValuePair("RoomDataSet", classcollection));

            return sources;
        }

        private bool IsTimeInBetween(string interval, string intervalcomparedto)
        {
            var timescomparedto = intervalcomparedto.Split('-').ToList();
            timescomparedto.Remove("");
            var timescomparedtoobservable = new ObservableCollection<string>();
            foreach (var item in timescomparedto)
            {
                timescomparedtoobservable.Add(item.Trim());
            }

            var times = interval.Split('-').ToList();
            times.Remove("");
            var timesobservable = new ObservableCollection<string>();
            foreach (var item in times)
            {
                timesobservable.Add(item.Trim());
            }

            if ((TimeSpan.Parse(timesobservable[0]) >= TimeSpan.Parse(timescomparedtoobservable[0])
                && (TimeSpan.Parse(timesobservable[1]) >= TimeSpan.Parse(timescomparedtoobservable[0])
                 && TimeSpan.Parse(timesobservable[1]) <= TimeSpan.Parse(timescomparedtoobservable[1]))

                || (TimeSpan.Parse(timesobservable[0]) >= TimeSpan.Parse(timescomparedtoobservable[0])
                    && TimeSpan.Parse(timesobservable[0]) <= TimeSpan.Parse(timescomparedtoobservable[1])
                    && TimeSpan.Parse(timesobservable[1]) >= TimeSpan.Parse(timescomparedtoobservable[1]))

                || (TimeSpan.Parse(timesobservable[0]) <= TimeSpan.Parse(timescomparedtoobservable[0])
                    && TimeSpan.Parse(timesobservable[1]) >= TimeSpan.Parse(timescomparedtoobservable[0])
                    && TimeSpan.Parse(timesobservable[1]) <= TimeSpan.Parse(timescomparedtoobservable[1]))))
                return true;


            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
