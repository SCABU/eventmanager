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
    public class RankingsModel : PageModel
    {
        ApiClient client = new ApiClient("http://api.sportradar.us/mma/trial/v2/en/competitions.json?api_key=89cw884adkkjbxkpp6tnknj2");
        RootRanking oggetto = new RootRanking();
        public List<Ranking> Rank = new List<Ranking>();
        /*
        public List<Ranking> P4P = new List<Ranking>();
        public List<Ranking> flyweight = new List<Ranking>();
        public List<Ranking> featherweight = new List<Ranking>();
        public List<Ranking> lightweight = new List<Ranking>();
        public List<Ranking> walterweight = new List<Ranking>();
        public List<Ranking> middleweight = new List<Ranking>();
        public List<Ranking> P4P = new List<Ranking>();
        */public List<Ranking> P4P = new List<Ranking>();
        private readonly ILogger<IndexModel> _logger;

        public RankingsModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            using (HttpClient client = new HttpClient())
            {

                int random = 0;
                Random rnd = new Random();
                random = rnd.Next(1, 2);
                // Imposta l'URI dell'API
                string uri = "";
                if (random == 0)
                {
                    uri = "http://api.sportradar.us/mma/trial/v2/en/rankings.json?api_key=89cw884adkkjbxkpp6tnknj2";
                }
                else if (random == 1)
                {
                    uri = "http://api.sportradar.us/mma/trial/v2/en/rankings.json?api_key=h6ryfpyyh98qbd7c73zsjpq9";
                }
                else if (random == 2)
                {
                    uri = "http://api.sportradar.us/mma/trial/v2/en/rankings.json?api_key=yy96sbxbk8qxqfjajshu4yec";
                }
                HttpResponseMessage response = await client.GetAsync(uri);
                string responseBody = await response.Content.ReadAsStringAsync();

                try
                {
                    oggetto = JsonConvert.DeserializeObject<RootRanking>(responseBody);
                    Rank = oggetto.rankings.ToList();
                    P4P = Rank.Where(p => p.name == "pound_for_pound").ToList();
                }
                catch (Exception ex)
                {
                    return RedirectToPage("./index");
                }
                return Page();
            }
        }

    }
}
