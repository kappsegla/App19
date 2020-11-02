using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace App1.Models
{
    public class CatFactApi
    {
        private Uri uri = new Uri("https://cat-fact.herokuapp.com/facts/random");
        private Uri uriAll = new Uri("https://cat-fact.herokuapp.com/facts");
        
        private HttpClient _client;

        public CatFactApi(HttpClient client)
        {
            _client = client;
        }


        public async Task<CatFact> GetRandomCatFact()
        {
            //Connect to api
            //We can use await on any method returning Task or Task<>
            var response = await _client.GetAsync(uri);
          
            //Convert response into C# object
            var content = await response.Content.ReadAsStringAsync();
            
            var catFact = JsonConvert.DeserializeObject<CatFact>(content);
            //Return that object
            return catFact;
        }
         
        public async Task<IEnumerable<CatFact>> GetCatFactsAsync()
        {
            //Connect to api
            //We can use await on any method returning Task or Task<>
            var response = await _client.GetAsync(uriAll);
            response.EnsureSuccessStatusCode();
            
            JsonSerializer serializer = new JsonSerializer();
            
            using (var stream = await response.Content.ReadAsStreamAsync())
            using (var reader = new StreamReader(stream))
            using (var json = new JsonTextReader(reader))
            {
                var catFacts = await Task.Run( () =>  serializer.Deserialize<CatFacts>(json));
                return catFacts.All;
            }
        }
    }
}