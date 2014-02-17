using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Web
{
    public interface IJeuxForainsAPIService
    {
        Task<List<JeuForain>> GetJeuxForainsAsync();
    }
}
