using DemoLibrary;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace practicaApiC_
{
    public class ComicProcessor
    {
        
        public static async Task<ComicModel> LoadComic(int comicNumber = 0)
        {
            string url = "";

            if(comicNumber > 0)
            {
                url = $"https://xkcd.com/{ comicNumber }/info.0.json";
            }
            else
            {
                url = $"https://xkcd.com/info.0.json";
            }
            using (HttpResponseMessage reponse = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (reponse.IsSuccessStatusCode)
                {
                    ComicModel comic = await reponse.Content.ReadFromJsonAsync<ComicModel>();

                    return comic;
                }
                else
                {
                    throw new Exception(reponse.ReasonPhrase);
                }
            }
        }
    }
}
