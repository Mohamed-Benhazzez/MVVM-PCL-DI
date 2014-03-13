using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Models;
using Services.Manager;
using Services.Storage;
using Services.Web;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWindowsPhone8App.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region fields & props

        #region services
        private readonly IStorageService _storageService;
        #endregion

        #region fields
        private ObservableCollection<JeuForain> _allJeuxForains;
        public ObservableCollection<JeuForain> AllJeuxForains
        {
            get
            {
                return _allJeuxForains
                    ?? (_allJeuxForains = new ObservableCollection<JeuForain>());
            }
        }

        public bool IsInitialized
        {
            get
            {
                return DataManager.Instance.IsInitialized;
            }
        }
        #endregion

        #region commands
        private RelayCommand _refreshDataCommand;
        public RelayCommand RefreshDataCommand
        {
            get
            {
                return _refreshDataCommand
                       ?? (_refreshDataCommand = new RelayCommand(RefreshData));
            }
        }
        #endregion

        #endregion

        #region constructor & initializer

        public MainViewModel( IStorageService storageService)
        {
            if (!IsInDesignModeStatic)
            {
                _storageService = storageService;
            }
        }

        #endregion

        #region methods
        public async void RefreshData()
        {
            if (await DataManager.Instance.LoadLocalJeuxForains())
            {
                AllJeuxForains.Clear();
                foreach (var item in DataManager.Instance.AllLoadedJeuxForrains)
                    AllJeuxForains.Add(item);
                RaisePropertyChanged(() => AllJeuxForains);
            }

            if (await DataManager.Instance.LoadOnlineJeuxForains())
            {
                AllJeuxForains.Clear();
                foreach (var item in DataManager.Instance.AllLoadedJeuxForrains)
                    AllJeuxForains.Add(item);
                RaisePropertyChanged(() => AllJeuxForains);

                DataManager.Instance.StoreLocalJeuxForains(AllJeuxForains.ToList());
            }
        }
        #endregion
    }
}
