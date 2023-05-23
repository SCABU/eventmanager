namespace eventmanager.Models
{
    

        public class Rootobject
        {
            public DateTime generated_at { get; set; }
            public Competition[] competitions { get; set; }
        }

        public class Competition
        {
            public string id { get; set; }
            public string name { get; set; }
            public string parent_id { get; set; }
            public Category category { get; set; }
        }

        public class Category
        {
            public string id { get; set; }
            public string name { get; set; }
        }
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Root
        {
            public DateTime generated_at { get; set; }
            public List<Season> seasons { get; set; }
        }

        public class Season
        {
            public string id { get; set; }
            public string name { get; set; }
            public string start_date { get; set; }
            public string end_date { get; set; }
            public string year { get; set; }
            public string competition_id { get; set; }
        }

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class RootCompetitors
        {
            public DateTime generated_at { get; set; }
            public List<SeasonCompetitor> season_competitors { get; set; }
        }

        public class SeasonCompetitor
        {
            public string id { get; set; }
            public string name { get; set; }
            public string short_name { get; set; }
            public string abbreviation { get; set; }
        }


   


    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class CategoryChampions
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<WeightClass> weight_classes { get; set; }
    }

    public class CompetitorChampion
    {
        public string id { get; set; }
        public string name { get; set; }
        public string abbreviation { get; set; }
        public string gender { get; set; }
    }

    public class RootChampions
    {
        public DateTime generated_at { get; set; }
        public List<CategoryChampions> categories { get; set; }
    }

    public class WeightClass
    {
        public string description { get; set; }
        public CompetitorChampion competitor { get; set; }
    }

    //___________________________________________________________________________________//

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Competitor
    {
        public string id { get; set; }
        public string name { get; set; }
        public string abbreviation { get; set; }
        public string gender { get; set; }
    }

    public class Info
    {
        public string birth_city { get; set; }
        public string birth_state { get; set; }
        public string birth_country { get; set; }
        public string birth_country_code { get; set; }
        public string birth_date { get; set; }
        public string fighting_out_of_city { get; set; }
        public string fighting_out_of_country { get; set; }
        public string fighting_out_of_country_code { get; set; }
        public string fighting_out_of_state { get; set; }
        public int reach { get; set; }
        public int height { get; set; }
        public decimal weight { get; set; }
        public string nickname { get; set; }
    }

    public class Record
    {
        public int wins { get; set; }
        public int draws { get; set; }
        public int losses { get; set; }
    }

    public class RootChampionDetails
    {
        public DateTime generated_at { get; set; }
        public Competitor competitor { get; set; }
        public Info info { get; set; }
        public Record record { get; set; }
    }

    //-----------------------------------------------------//

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Datum
    {
        public string id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string size { get; set; }
        public string background_color { get; set; }
        public string thumbnail_url { get; set; }
        public int thumbnail_width { get; set; }
        public int thumbnail_height { get; set; }
        public string source { get; set; }
        public string source_url { get; set; }
        public string source_domain { get; set; }
        public string copyright { get; set; }
        public string creative { get; set; }
        public string credits { get; set; }
    }

    public class Parameters
    {
        public string query { get; set; }
        public string region { get; set; }
    }

    public class RootImage
    {
        public string status { get; set; }
        public string request_id { get; set; }
        public Parameters parameters { get; set; }
        public List<Datum> data { get; set; }
    }

    //-------------------------------------------//

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    

    public class Channel
    {
        public string name { get; set; }
        public string url { get; set; }
        public string country { get; set; }
        public string country_code { get; set; }
    }

   
    public class Coverage
    {
        public bool live { get; set; }
        public string type { get; set; }
        public SportEventProperties sport_event_properties { get; set; }
    }

    public class Period
    {
        public int number { get; set; }
        public List<Competitor> competitors { get; set; }
    }

    public class RootInformazioni
    {
        public DateTime generated_at { get; set; }
        public List<Summary> summaries { get; set; }
    }

   

    public class Sport
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class SportEvent
    {
        public string id { get; set; }
        public DateTime start_time { get; set; }
        public bool start_time_confirmed { get; set; }
        public SportEventContext sport_event_context { get; set; }
        public Coverage coverage { get; set; }
        public List<Competitor> competitors { get; set; }
        public Venue venue { get; set; }
        public List<Channel> channels { get; set; }
    }

    public class SportEventContext
    {
        public Sport sport { get; set; }
        public Category category { get; set; }
        public Competition competition { get; set; }
        public Season season { get; set; }
        public Stage stage { get; set; }
    }

    public class SportEventProperties
    {
        public bool data_complete { get; set; }
    }

    public class SportEventStatus
    {
        public string status { get; set; }
        public string match_status { get; set; }
        public string winner_id { get; set; }
        public int final_round { get; set; }
        public string final_round_length { get; set; }
        public string method { get; set; }
        public string winner { get; set; }
        public int scheduled_length { get; set; }
        public string weight_class { get; set; }
        public bool title_fight { get; set; }
        public bool main_event { get; set; }
    }

    public class Stage
    {
        public string type { get; set; }
    }

    public class Statistics
    {
        public Totals totals { get; set; }
        public List<Period> periods { get; set; }
        public string control { get; set; }
        public int knockdowns { get; set; }
        public double significant_strike_percentage { get; set; }
        public int significant_strikes { get; set; }
        public int significant_strikes_attempted { get; set; }
        public int submission_attempts { get; set; }
        public double takedown_percentage { get; set; }
        public int takedowns { get; set; }
        public int takedowns_attempted { get; set; }
        public double total_strike_percentage { get; set; }
        public int total_strikes { get; set; }
        public int total_strikes_attempted { get; set; }
    }

    public class Summary
    {
        public SportEvent sport_event { get; set; }
        public SportEventStatus sport_event_status { get; set; }
        public Statistics statistics { get; set; }
    }

    public class Totals
    {
        public List<Competitor> competitors { get; set; }
    }

    public class Venue
    {
        public string id { get; set; }
        public string name { get; set; }
        public int capacity { get; set; }
        public string city_name { get; set; }
        public string country_name { get; set; }
        public string map_coordinates { get; set; }
        public string country_code { get; set; }
        public string timezone { get; set; }
        public string state { get; set; }
    }


    //____________________________________________________________//

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    public class CompetitorRanking
    {
        public int rank { get; set; }
        public int movement { get; set; }
        public Competitor competitor { get; set; }
    }

    public class Ranking
    {
        public int type_id { get; set; }
        public string name { get; set; }
        public int year { get; set; }
        public int week { get; set; }
        public List<CompetitorRanking> competitor_rankings { get; set; }
    }

    public class RootRanking
    {
        public DateTime generated_at { get; set; }
        public List<Ranking> rankings { get; set; }
    }
    //------------------------------------------------------------//

    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class Accessibility
    {
        public string title { get; set; }
        public string duration { get; set; }
    }

    public class ChannelVideo
    {
        public string name { get; set; }
        public string id { get; set; }
        public List<Thumbnail> thumbnails { get; set; }
        public string link { get; set; }
    }

    public class DescriptionSnippet
    {
        public string text { get; set; }
        public bool? bold { get; set; }
    }

    public class RichThumbnail
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class RootVideo
    {
        public string type { get; set; }
        public string id { get; set; }
        public string title { get; set; }
        public string publishedTime { get; set; }
        public string duration { get; set; }
        public ViewCount viewCount { get; set; }
        public List<Thumbnail> thumbnails { get; set; }
        public RichThumbnail richThumbnail { get; set; }
        public List<DescriptionSnippet> descriptionSnippet { get; set; }
        public ChannelVideo channel { get; set; }
        public Accessibility accessibility { get; set; }
        public string link { get; set; }
        public object shelfTitle { get; set; }
    }

    public class Thumbnail
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class ViewCount
    {
        public string text { get; set; }
        public string @short { get; set; }
    }


    public class SecuritySettings
    {
        public string ReferrerPolicy { get; set; }
    }



}

