using Services.Storage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesWindowsPhone8.Storage
{
    public class StorageService : IStorageService
    {

        public async Task<bool> StoreJeuxForains(IList<Models.JeuForain> listToStore)
        {
            try
            {
                using (IsolatedStorageFileStream filestream = GetStorageFile("JeuxForains.Save", FileAccess.Write, true))
                {
                    using (StreamWriter sw = new StreamWriter(filestream))
                    {
                        string json = Newtonsoft.Json.JsonConvert.SerializeObject(listToStore);
                        await sw.WriteLineAsync(json);
                    }
                }
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
                string json;
                using (IsolatedStorageFileStream filestream = GetStorageFile("JeuxForains.Save", FileAccess.Read))
                {
                    StreamReader sw = new StreamReader(filestream);
                    json = await sw.ReadToEndAsync();
                    if (string.IsNullOrEmpty(json))
                        return null;

                    listObject = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Models.JeuForain>>(json);

                }
                return listObject;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("RetrieveListObject : " + ex);
                return null;
            }
        }

        private static IsolatedStorageFileStream GetStorageFile(string fileName, FileAccess access, bool erase = false)
        {
            var store = IsolatedStorageFile.GetUserStoreForApplication();
            if (erase)
                return store.OpenFile(fileName, FileMode.Create, access);
            else
                return store.OpenFile(fileName, FileMode.OpenOrCreate, access);
        }
    }
}
