using Foggy.CheckSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Foggy.CheckSystem.Checkers
{
    internal class AnilibriaChecker : IChecker
    {
        private static HttpClient _client;
        private static string _url = @"https://api.anilibria.tv/v2/getTitle?code=";

        public AnilibriaChecker()
        {
            _client = new HttpClient();
        }

        public async Task<bool> IsCompleted(string name)
        {
            var response = await _client.GetAsync(_url + name);
            var resultJson = "";
            if (response.IsSuccessStatusCode)
            {
                resultJson = await response.Content.ReadAsStringAsync();
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(resultJson);
                if (result.ChildrenTokens[4].Compare("Завершен"))
                    return true;
            }
            Console.WriteLine("asdasd");
            return false;
        }
    }
}
