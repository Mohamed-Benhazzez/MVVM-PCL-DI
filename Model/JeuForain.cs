using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   
    public class JeuForain
    {
        [JsonProperty("categorie_de_jeux_forains")]
        public string Categorie { get; set; }

        [JsonProperty("arrt")]
        public string Arrondissement { get; set; }

        [JsonProperty("lieux")]
        public string Lieux { get; set; }

        [JsonProperty("horaires")]
        public string Horraires { get; set; }

    }
}
