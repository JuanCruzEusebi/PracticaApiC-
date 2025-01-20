using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace practicaApiC_
{
    public class SunProcessor
    {
        public static async Task<SunModel> LoadSunInformation()
        {
            string url = "https://api.sunrise-sunset.org/json?lat=36.7201600&lng=-4.4203400&date=today";

            using (HttpResponseMessage reponse = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (reponse.IsSuccessStatusCode)
                {
                    SunResultModel? result = await reponse.Content.ReadFromJsonAsync<SunResultModel>();

                    return result.Results;
                }
                else
                {
                    throw new Exception(reponse.ReasonPhrase);
                }
            }
        }
    }
}
