﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Nito.AsyncEx;
using TinyCollege.DataAccess;
using TinyCollege.Models.Room;
using TinyCollege.Reports.Room;
using TinyCollege.Views.Room;

namespace TinyCollege.Modules
{
    public class RoomModule:ObservableObject
    {
        private IRepository _repository;

        public RoomModule(IRepository repository)
        {
            _repository = repository;
            RoomLoading = NotifyTaskCompletion.Create(() => LoadRoomsAsync());

        }

        public ObservableCollection<RoomModel> RoomList { get; } = new ObservableCollection<RoomModel>();

        private RoomModel _selectedRoom;

        public RoomModel SelectedRoom
        {
            get { return _selectedRoom;}
            set
            {
                _selectedRoom = value;
                if (_selectedRoom != null)
                {
                    _selectedRoom.LoadRelatedInfo();
                }
                RaisePropertyChanged(nameof(SelectedRoom));
            }
        }

        public INotifyTaskCompletion RoomLoading { get; private set; }

        private async Task LoadRoomsAsync()
        {
            var rooms = await Task.Run(() => _repository.Room.GetRangeAsync(CancellationToken.None));
            foreach (var room in rooms)
            {
                var roommodel = new RoomModel(room, _repository);
                roommodel.LoadRelatedInfo();
                RoomList.Add(roommodel);
                await Task.Delay(100);
            }
        }

        private RoomNewModel _newRoom;
        public RoomNewModel NewRoom
        {
            get { return _newRoom; }
            set
            {
                _newRoom = value;
                RaisePropertyChanged(nameof(NewRoom));
            }
        }

        public bool IsByTime
        {
            get { return _isByTime; }
            set
            {
                _isByTime = value; 
                RaisePropertyChanged(nameof(IsByTime));
            }
        }

        public bool IsByBuilding
        {
            get { return _isByBuilding; }
            set
            {
                _isByBuilding = value; 
                RaisePropertyChanged(nameof(IsByBuilding));
            }
        }

        public ICommand AddRoomCommand => new RelayCommand(AddRoomProc);

        private RoomAddingWindow _roomAddwindow;
        private bool _isByTime;
        private bool _isByBuilding;

        private void AddRoomProc()
        {
            NewRoom?.Dispose();
            NewRoom = new RoomNewModel();
            _roomAddwindow = new RoomAddingWindow {Owner = Application.Current.MainWindow};
            _roomAddwindow.ShowDialog();
        }

        public ICommand SaveRoomCommand => new RelayCommand(SaveRoomProc, SaveRoomCondition);

        private bool SaveRoomCondition()
        {
            return (NewRoom != null) && NewRoom.HasChanges && !NewRoom.HasErrors;
        }

        private async Task SaveRoomProcAsync()
        {
            if (NewRoom == null) return;
            if (!NewRoom.HasChanges) return;
            try
            {
                await Task.Run(() => _repository.Room.AddAsync(NewRoom.ModelCopy));
                var roommodel = new RoomModel(NewRoom.ModelCopy, _repository);
                roommodel.LoadRelatedInfo();
                RoomList.Add(roommodel);
                _roomAddwindow.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to Save!", "Add Room", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        private void SaveRoomProc()
        {
            NotifyTaskCompletion.Create(() => SaveRoomProcAsync());

        }

        public ICommand CancelRoomCommand => new RelayCommand(CancelRoomProc);

        private void CancelRoomProc()
        {
            NewRoom?.Dispose();
            _roomAddwindow.Close();
        }

        public ICommand DeleteRoomCommand => new RelayCommand(DeleteRoomProc, DeleteProcCondition);

        private bool DeleteProcCondition()
        {
            return (SelectedRoom != null);
        }

        public ICommand PrintRoomReport => new RelayCommand(PrintRoomReportProc);

        private RoomReportWindow _roomReportWindow;
        private void PrintRoomReportProc()
        {
            _roomReportWindow = new RoomReportWindow();
            _roomReportWindow.Owner = Application.Current.MainWindow;
            _roomReportWindow.Show();
        }

        private async Task DeleteRoomProcAsync()
        {
            if (SelectedRoom == null) return;
            try
            {
                await Task.Run(() => _repository.Room.RemoveAsync(SelectedRoom.Model, CancellationToken.None));
                RoomList.Remove(SelectedRoom);
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to Delete!", "Delete Room", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void DeleteRoomProc()
        {
            NotifyTaskCompletion.Create(() => DeleteRoomProcAsync());

        }
    }
}
