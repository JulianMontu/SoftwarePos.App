using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwarePos.Models
{
    public class TGrupoManager
    {
        static HttpClient client;

        public static async Task<IEnumerable<TGrupo>> GetAll()
        {
            client = new HttpClient();
            string result = await client.GetStringAsync($"{Constans.RestUrl}grupos");
            return JsonConvert.DeserializeObject<List<TGrupo>>(result);
        }

    }
}
