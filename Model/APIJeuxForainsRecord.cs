using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class APIJeuxForainsRecord
    {
        [JsonProperty("datasetid")]
        public string DatasetId { get; set; }

        [JsonProperty("recordid")]
        public string RecordiId { get; set; }

        [JsonProperty("fields")]
        public JeuForain Value { get; set; }

    }
}
