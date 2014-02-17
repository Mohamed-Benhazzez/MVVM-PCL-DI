using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Storage
{
    public interface IStorageService
    {
        Task<bool> StoreJeuxForains(List<JeuForain> listToStore);

        Task<List<JeuForain>> RetrieveJeuxForains();
    }
}
