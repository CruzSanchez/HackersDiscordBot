using HackersDiscordBot.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System.IO;
using System.Threading.Tasks;

namespace HackersDiscordBot
{
    public class BaseServiceCall
    {
        const string API_URL = "https://www.googleapis.com/youtube/v3/search";

        public static async Task<Root> CallYouTube(string searchQuery)
        {
            RestClient restClient = new RestClient(API_URL);
            RestRequest request = new RestRequest();

            request.Method = Method.Get;
            request.AddQueryParameter("key", GetYoutubeKey());
            request.AddQueryParameter("part", "snippet");
            request.AddQueryParameter("q", searchQuery);
            request.AddQueryParameter("maxResults", 1);

            RestResponse response = await restClient.GetAsync(request);

            Root root = JsonConvert.DeserializeObject<Root>(response.Content);

            return root;
        }

        private static string GetYoutubeKey()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            return builder["YouTubeToken"];
        }
    }
}
