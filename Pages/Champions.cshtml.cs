using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using eventmanager.Models;
using eventmanager.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace eventmanager.Pages
{
    public class ChampionsModel : PageModel
    {
        ApiClient client = new ApiClient("http://api.sportradar.us/mma/trial/v2/en/champions.json?api_key=89cw884adkkjbxkpp6tnknj2");

        RootChampions rootChampions = new RootChampions();

        public List<CategoryChampions> ChampionsList = new List<CategoryChampions>();
        public List<WeightClass> WeightClasses = new List<WeightClass>();
        private readonly ILogger<IndexModel> _logger;
        public string urlimmagine = "";
        public ChampionsModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            // Crea un'istanza di HttpClient
            using (HttpClient client = new HttpClient())
            {

                int random = 0;
                Random rnd = new Random();
                random = rnd.Next(1, 2);
                // Imposta l'URI dell'API
                string uri = "";
                if (random == 0)
                {
                    uri = "http://api.sportradar.us/mma/trial/v2/en/champions.json?api_key=89cw884adkkjbxkpp6tnknj2";
                }
                else if (random == 1)
                {
                    uri = "http://api.sportradar.us/mma/trial/v2/en/champions.json?api_key=h6ryfpyyh98qbd7c73zsjpq9";
                }
                else if (random == 2)
                {
                    uri = "http://api.sportradar.us/mma/trial/v2/en/champions.json?api_key=yy96sbxbk8qxqfjajshu4yec";
                }

                // Effettua la chiamata HTTP GET all'API e ottiene la risposta come stringa
                HttpResponseMessage response = await client.GetAsync(uri);
                string responseBody = await response.Content.ReadAsStringAsync();

                rootChampions = JsonConvert.DeserializeObject<RootChampions>(responseBody);

                ChampionsList = rootChampions.categories.ToList();
                WeightClasses = ChampionsList[0].weight_classes.ToList();
            }
        }
    }
}
