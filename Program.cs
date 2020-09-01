using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

namespace ApiClient
{
    class Lyric
    {
        public string Lyrics { get; set; }
    }
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var client = new HttpClient();
            var responseAsStream = await client.GetStreamAsync("https://api.lyrics.ovh/v1/mariah_carey/can't_take_that_away");

            List<Lyric> theLyrics = await JsonSerializer.DeserializeAsync<List<Lyric>>(responseAsStream);

            foreach (var theLyric in theLyrics)
            {

                Console.WriteLine($"{theLyric.Lyrics}");
            }
        }
    }
}
