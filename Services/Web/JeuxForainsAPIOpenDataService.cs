using Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services.Web
{
    public class JeuxForainsAPIOpenDataService : IJeuxForainsAPIService
    {
        /// <summary>
        /// Données issue de l'open data de paris
        /// http://parisdata.opendatasoft.com/
        /// </summary>
        public const string JEUXFORAINSURL = @"http://parisdata.opendatasoft.com/api/records/1.0/search?dataset=maneges_et_jeux_2012&facet=arrt&facet=categorie_de_jeux_forains";
        
        public async Task<List<JeuForain>> GetJeuxForainsAsync()
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, JEUXFORAINSURL);
                HttpClient httpClient = new HttpClient();

                HttpResponseMessage httpResponse = await httpClient.SendAsync(request);

                string content = await httpResponse.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(content))
                {
                    var json = JObject.Parse(content);

                    var records = Newtonsoft.Json.JsonConvert.DeserializeObject<List<APIJeuxForainsRecord>>(json["records"].ToString());

                    List<JeuForain> values = new List<JeuForain>();

                    foreach (var jeux in records)
                        values.Add(jeux.Value);

                    return values;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetJeuxForainsAsync : " + ex);
            }
            return null;
        }
    }
}
