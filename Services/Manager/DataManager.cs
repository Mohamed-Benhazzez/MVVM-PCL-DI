using Models;
using Services.Storage;
using Services.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Manager
{
    public class DataManager
    {
        #region fields & props

        #region service
        public bool IsInitialized
        {
            get
            {
                return _storageService != null && _jeuxForainsApiService != null;
            }
        }
        private IStorageService _storageService;
        private IJeuxForainsAPIService _jeuxForainsApiService;
        #endregion


        #region multi thread access

        private static object syncRoot = new Object();
        private static DataManager instance;

        public static DataManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        instance = new DataManager();
                    }
                }

                return instance;
            }
        }

        #endregion

        #region data
        public IList<JeuForain> AllLoadedJeuxForrains { get; set; }
        #endregion


        #endregion

        #region constructor & initialize
        public DataManager()
        {
            AllLoadedJeuxForrains = new List<JeuForain>();
        }

        public void Initialize(IStorageService storageService, IJeuxForainsAPIService jeuxForainsAPIService)
        {
            _storageService = storageService;
            _jeuxForainsApiService = jeuxForainsAPIService;
        }

        #endregion

        #region methods

        public async Task<bool> LoadOnlineJeuxForains()
        {
            var jeux = await _jeuxForainsApiService.GetJeuxForainsAsync();

            if (jeux != null)
            {
                foreach (var jeu in jeux)
                {
                    if (!AllLoadedJeuxForrains.Contains(jeu))
                        AllLoadedJeuxForrains.Add(jeu);
                }
                return true;
            }
            return false;

        }

        public async Task<bool> LoadLocalJeuxForains()
        {
            var jeux = await _storageService.RetrieveJeuxForains();

            if (jeux != null)
            {
                foreach (var jeu in jeux)
                {
                    if (!AllLoadedJeuxForrains.Contains(jeu))
                        AllLoadedJeuxForrains.Add(jeu);
                }
                return true;
            }

            return false;
        }

        public async void StoreLocalJeuxForains(List<JeuForain> listToStore)
        {
            if (listToStore != null)
                await _storageService.StoreJeuxForains(listToStore);
        }

        #endregion
    }
}
