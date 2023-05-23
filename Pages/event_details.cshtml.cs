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
    public class event_detailsModel : PageModel
    {
        ApiClient client = new ApiClient("http://api.sportradar.us/mma/trial/v2/en/competitions.json?api_key=89cw884adkkjbxkpp6tnknj2");
        Root dettagli = new Root();
       RootCompetitors competitors = new RootCompetitors();
        
        public List<Season> competitionseason = new List<Season>();
        public List<SeasonCompetitor> Competitors = new List<SeasonCompetitor>();

        private readonly ILogger<IndexModel> _logger;

        public event_detailsModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public string codiceevento;
        public async Task<IActionResult> OnGetAsync(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                string codice = id;
                codiceevento = codice;

                int random = 0;
                Random rnd = new Random();
                random = rnd.Next(1, 2);
                // Imposta l'URI dell'API
                string uri = "";
                if (random == 0)
                {
                    uri = "http://api.sportradar.us/mma/trial/v2/en/competitions/" + codice + "/seasons.json?api_key=89cw884adkkjbxkpp6tnknj2";
                }
                else if (random == 1)
                {
                    uri = "http://api.sportradar.us/mma/trial/v2/en/competitions/" + codice + "/seasons.json?api_key=h6ryfpyyh98qbd7c73zsjpq9";
                }
                else if (random == 2)
                {
                    uri = "http://api.sportradar.us/mma/trial/v2/en/competitions/" + codice + "/seasons.json?api_key=yy96sbxbk8qxqfjajshu4yec";
                }
                //yy96sbxbk8qxqfjajshu4yec
                HttpResponseMessage response = await client.GetAsync(uri);
                string responseBody = await response.Content.ReadAsStringAsync();

                try
                {
                    dettagli = JsonConvert.DeserializeObject<Root>(responseBody);
                    competitionseason = dettagli.seasons.ToList();
                   
                    
                }
                catch (Exception ex)
                {
                    return RedirectToPage("./wrongresponse");
                }
                
                    codiceevento = competitionseason[0].id.ToString();

            }
            using (HttpClient cliente = new HttpClient())
            {
                string uriF = "http://api.sportradar.us/mma/trial/v2/en/seasons/" + codiceevento + "/competitors.json?api_key=89cw884adkkjbxkpp6tnknj2";
                HttpResponseMessage responseF = await cliente.GetAsync(uriF);
                string responseBodyF = await responseF.Content.ReadAsStringAsync();

                try
                {
                    competitors = JsonConvert.DeserializeObject<RootCompetitors>(responseBodyF);
                    Competitors = competitors.season_competitors.ToList();

                }
                catch (Exception ex)
                {
                    return RedirectToPage("./wrongresponse");
                }
            }
            return Page();
        }

        
    }
}
