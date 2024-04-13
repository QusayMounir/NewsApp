using NewsApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Services
{
    public class ApiService
    {
        public async Task<Root> GetNews(string CatName)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync($"https://gnews.io/api/v4/top-headlines?category={CatName.ToLower()}&apikey=357968f1bcba33ebcb6151046d30d74f&lang=en");
            return JsonConvert.DeserializeObject<Root>(response);

        }
    }
}
