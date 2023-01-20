using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwarePos.Models
{
    public class TMesaManager
    {
        static HttpClient client;

        public static async Task<IEnumerable<TMesa>> GetAll()
        {
            client = new HttpClient();
            string result = await client.GetStringAsync($"{Constans.RestUrl}mesas");
            return JsonConvert.DeserializeObject<List<TMesa>>(result);
        }
    }
}
