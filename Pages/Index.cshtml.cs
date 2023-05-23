using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using eventmanager.Models;
using eventmanager.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

//using static eventmanager.Models.champions;

namespace eventmanager.Pages
{
    public class IndexModel : PageModel
    {
        ApiClient client = new ApiClient("http://api.sportradar.us/mma/trial/v2/en/competitions.json?api_key=89cw884adkkjbxkpp6tnknj2");
        //Rootobject competition = await client.GetAsync<Rootobject>("");
        Rootobject competitions = new Rootobject();
        Root dettagli = new Root();

        public List<Competition> competitionList = new List<Competition>();
        public List<Season> competitionseason = new List<Season>();

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
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
                random=rnd.Next(1,  2);
                // Imposta l'URI dell'API
                string uri = "";
                if(random==0)
                {
                    uri = "http://api.sportradar.us/mma/trial/v2/en/competitions.json?api_key=89cw884adkkjbxkpp6tnknj2";
                    ///
                }
                else if(random == 1)
                {
                    uri = "http://api.sportradar.us/mma/trial/v2/en/competitions.json?api_key=h6ryfpyyh98qbd7c73zsjpq9";
                }
                else if (random == 2)
                {
                    uri = "http://api.sportradar.us/mma/trial/v2/en/competitions.json?api_key=yy96sbxbk8qxqfjajshu4yec";
                }

                // Effettua la chiamata HTTP GET all'API e ottiene la risposta come stringa
                HttpResponseMessage response = await client.GetAsync(uri);
                string responseBody = await response.Content.ReadAsStringAsync();

                competitions= JsonConvert.DeserializeObject<Rootobject>(responseBody);

                competitionList = competitions.competitions.ToList();
                competitionList.Reverse();

            }
        }

        public async Task<List<Season>> estraidataAsync(Competition competition)
        {
            using (HttpClient client = new HttpClient())
            {
                string codice = competition.id.ToString();

                string uri = "http://api.sportradar.us/mma/trial/v2/en/competitions/" + codice + "/seasons.json?api_key=89cw884adkkjbxkpp6tnknj2";
                HttpResponseMessage response = await client.GetAsync(uri);
                string responseBody = await response.Content.ReadAsStringAsync();
                
                try
                {

                    dettagli = JsonConvert.DeserializeObject<Root>(responseBody);
                    competitionseason = dettagli.seasons.ToList();
                    return competitionseason;
                }
                catch (Exception ex)
                {
                    return null;
                }
                
            }
        }
    }
}