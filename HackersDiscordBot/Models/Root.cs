using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackersDiscordBot.Models
{
    public class Root
    {
        [JsonProperty("items")]
        public List<Item> Items { get; set; }
    }

    public class Snippet
    {
        [JsonProperty("description")]
        public string Description { get; set; }       
    }

    public class Item
    {
        [JsonProperty("id")]
        public Id Id { get; set; }

        [JsonProperty("snippet")]
        public Snippet Snippet { get; set; }
    }

    public class Id
    {
        [JsonProperty("videoId")]
        public string VideoId { get; set; }
    }
}
