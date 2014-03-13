using Services.Storage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace ServicesWindows8.Storage
{
    public class StorageService : IStorageService
    {

        public async Task<bool> StoreJeuxForains(IList<Models.JeuForain> listToStore)
        {
            try
            {
                var filestream = await GetStorageFile("JeuxForains.Save", true);

                string json = Newtonsoft.Json.JsonConvert.SerializeObject(listToStore);
                await FileIO.WriteTextAsync(filestream, json);
                return true;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("StoreListObject : " + ex);    
            }
            return false;
        }

        public async Task<IList<Models.JeuForain>> RetrieveJeuxForains()
        {
            try
            {
                IList<Models.JeuForain> listObject;
                StorageFile filestream = await GetStorageFile("JeuxForains.Save");


                string json = await FileIO.ReadTextAsync(filestream);
                if (string.IsNullOrEmpty(json))
                    return null;

                listObject = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Models.JeuForain>>(json);


                return listObject;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetStations : " + ex);  
            }
            return null;
        }

        private static async Task<StorageFile> GetStorageFile(string fileName, bool erase = false)
        {
            var store = ApplicationData.Current.LocalFolder;
            if (erase)
                return await store.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            else
                return await store.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
        }
    }
}
