using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApiClient
{
    class Lyric
    {
        [JsonPropertyName("lyrics")]
        public string Lyrics { get; set; }
    }
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var client = new HttpClient();
            var responseAsStream = await client.GetStreamAsync("https://api.lyrics.ovh/v1/mariah_carey/cant_take_that_away");

            var theLyrics = await JsonSerializer.DeserializeAsync<Lyric>(responseAsStream);

            Console.WriteLine(theLyrics.Lyrics);

        }
    }
}
