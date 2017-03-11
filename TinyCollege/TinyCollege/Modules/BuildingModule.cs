using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Nito.AsyncEx;
using TinyCollege.DataAccess;
using TinyCollege.DataAccess.Ef;
using TinyCollege.Models.Building;
using TinyCollege.Views.Building;

namespace TinyCollege.Modules
{
    public class BuildingModule:ObservableObject
    {
        private IRepository _repository;

        public BuildingModule(IRepository repository)
        {
            _repository = repository;
            BuildingLoading = NotifyTaskCompletion.Create(() => LoadBooksAsync());
        }

        public ObservableCollection<BuildingModel> BuildingList { get; } = new ObservableCollection<BuildingModel>();

        private async Task LoadBooksAsync()
        {
            var buildings = await Task.Run(() => _repository.Building.GetRangeAsync(CancellationToken.None));
            foreach (var building in buildings)
            {
                var buildingmodel = new BuildingModel(building, _repository);
                buildingmodel.LoadRelatedInfo();
                BuildingList.Add(buildingmodel);
                await Task.Delay(100);
            }
        }

        public INotifyTaskCompletion BuildingLoading { get; set; }

        private BuildingModel _selectedBuilding;
        public BuildingModel SelectedBuilding
        {
            get { return _selectedBuilding; }
            set
            {
                _selectedBuilding = value;
                if (value != null)
                {
                    _selectedBuilding.LoadRelatedInfo();
                }
                RaisePropertyChanged(nameof(SelectedBuilding));
            }
        }

        private BuildingNewModel _newBuilding;
        public BuildingNewModel NewBuilding
        {
            get { return _newBuilding; }
            set
            {
                _newBuilding = value;
                RaisePropertyChanged(nameof(NewBuilding));
            }
        }

        public ICommand AddBuildingCommand => new RelayCommand(AddBuildingProc);

        private AddingBuildingWindow _addBuildingWin;
        private void AddBuildingProc()
        {
            NewBuilding?.Dispose();
            NewBuilding = new BuildingNewModel();
            _addBuildingWin = new AddingBuildingWindow();
            _addBuildingWin.Owner = Application.Current.MainWindow;
            _addBuildingWin.ShowDialog();
        }

        public ICommand SaveBuildingCommand => new RelayCommand(SaveBuildingProc, SaveBuildingCondition);

        private bool SaveBuildingCondition()
        {
            return (NewBuilding != null) && NewBuilding.HasChanges && !NewBuilding.HasErrors;
        }

        private async Task SaveBuildingProcAsync()
        {
            if (NewBuilding == null) return;
            if (!NewBuilding.HasChanges) return;
            try
            {
                await Task.Run(() => _repository.Building.AddAsync(NewBuilding.ModelCopy, CancellationToken.None));
                BuildingList.Add(new BuildingModel(NewBuilding.ModelCopy, _repository));
                _addBuildingWin.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to Save!", "Add Building!");
            }

        }
        private async void SaveBuildingProc()
        {
            await SaveBuildingProcAsync();
        }

        public ICommand CancelBuildingCommand => new RelayCommand(CancelBuildingProc);

        private void CancelBuildingProc()
        {
            NewBuilding?.Dispose();
            _addBuildingWin.Close();
        }

        public ICommand DeleteBuildingCommand => new RelayCommand(DelteBuildingProc, DeleteBuildingCondition);

        private bool DeleteBuildingCondition()
        {
            return (SelectedBuilding != null);
        }

        private async Task DeleteBuildingProcAsync()
        {
            if (SelectedBuilding == null) return;
            try
            {
                await Task.Run(() => _repository.Building.RemoveAsync(SelectedBuilding.Model, CancellationToken.None));
                BuildingList.Remove(SelectedBuilding);
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to Delete", "Delete Building", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        private async void DelteBuildingProc()
        {
            await DeleteBuildingProcAsync();
        }
    }
}
