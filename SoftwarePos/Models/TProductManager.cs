using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwarePos.Models
{
    public class TProductManager
    {
        static HttpClient client;

        public static async Task<IEnumerable<TProducto>> GetAll()
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return new List<TProducto>();
            client = new HttpClient();
            string result = await client.GetStringAsync($"{Constans.RestUrl}productos");
            return JsonConvert.DeserializeObject<List<TProducto>>(result);
        }
    }
}
