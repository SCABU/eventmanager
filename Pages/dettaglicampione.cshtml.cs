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
    public class dettaglicampioneModel : PageModel
    {
        public string codicevideo = "";
        ApiClient client = new ApiClient("http://api.sportradar.us/mma/trial/v2/en/competitors/sr:competitor:260623/profile.json?api_key=89cw884adkkjbxkpp6tnknj2");
        RootChampionDetails champdetails = new RootChampionDetails();
        RootInformazioni infos = new RootInformazioni();
        public List<Competitor> CompetitorsInfo = new List<Competitor>();
        public List<Summary> summarys = new List<Summary>();
       public List<SportEventStatus> statoevento = new List<SportEventStatus>();
        public List<Statistics> statistiche = new List<Statistics>();
        public List<Datum> dataimage = new List<Datum>();
        public Competitor competitors = new Competitor();
        public Info Informazioni = new Info();
        public Record Record = new Record();
        public List<RootVideo> Video =new List<RootVideo>();
        public string link = "";
        private readonly ILogger<IndexModel> _logger;

        public dettaglicampioneModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        RootImage rootImage = new RootImage();
 
        public async Task<IActionResult> OnGetAsync(string? id)
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
                    uri = "http://api.sportradar.us/mma/trial/v2/en/competitors/" + id + "/profile.json?api_key=89cw884adkkjbxkpp6tnknj2";
                }
                else if (random == 1)
                {
                    uri = "http://api.sportradar.us/mma/trial/v2/en/competitors/" + id + "/profile.json?api_key=h6ryfpyyh98qbd7c73zsjpq9";
                }
                else if (random == 2)
                {
                    uri = "http://api.sportradar.us/mma/trial/v2/en/competitors/" + id + "/profile.json?api_key=yy96sbxbk8qxqfjajshu4yec";
                }

                HttpResponseMessage response = await client.GetAsync(uri);
                string responseBody = await response.Content.ReadAsStringAsync();

                
                try
                {
                    champdetails = JsonConvert.DeserializeObject<RootChampionDetails>(responseBody);

                    competitors = champdetails.competitor;
                    Informazioni = champdetails.info;
                    Record = champdetails.record;
                }
                catch (Exception ex)
                {
                    return RedirectToPage("./Rankings");
                }
                client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "3ab9d38261msh886820ea002781fp188aadjsn1993279e8004");
                client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "real-time-image-search.p.rapidapi.com");

                string query = Uri.EscapeDataString(champdetails.competitor.name + " ufc fighter");
                string uriI = $"https://real-time-image-search.p.rapidapi.com/search?query={query}&region=us";

                HttpResponseMessage responseI = await client.GetAsync(uriI);
                try
                {
                    string responseBodyI = await responseI.Content.ReadAsStringAsync();
                    rootImage = JsonConvert.DeserializeObject<RootImage>(responseBodyI);
                    dataimage = rootImage.data.ToList();

                }
                catch(Exception ex)
                {
                    return Page();
                }
                //informazioni eventi passati




            }
            using (HttpClient cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("X-RapidAPI-Key", "ac1a609d6cmsh43a2933149ead82p198e15jsn65dfb7cd9010");
                cliente.DefaultRequestHeaders.Add("X-RapidAPI-Host", "youtube-search13.p.rapidapi.com");

                string query = Uri.EscapeDataString(champdetails.competitor.name + " career highlights");

                string uriIv = $"https://youtube-search13.p.rapidapi.com/YouTube/Videos/Search?query={query}&page=1";

                HttpResponseMessage responseIv = await cliente.GetAsync(uriIv);
                string responseBodyIv = await responseIv.Content.ReadAsStringAsync();
                Video = JsonConvert.DeserializeObject<List<RootVideo>>(responseBodyIv);
                link = Video[0].link.ToString(); ;
                string[] splittato = link.Split('=');
                codicevideo = "https://www.youtube.com/embed/" + splittato[1];
            }



            return Page();
        }
    }
}
