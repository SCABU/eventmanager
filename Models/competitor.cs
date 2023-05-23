namespace eventmanager.Models
{
    public class competitor
    {

        public class Rootobject
        {
            public DateTime generated_at { get; set; }
            public Summary[] summaries { get; set; }
        }

        public class Summary
        {
            public Sport_Event sport_event { get; set; }
            public Sport_Event_Status sport_event_status { get; set; }
            public Statistics statistics { get; set; }
        }

        public class Sport_Event
        {
            public string id { get; set; }
            public DateTime start_time { get; set; }
            public bool start_time_confirmed { get; set; }
            public Sport_Event_Context sport_event_context { get; set; }
            public Coverage coverage { get; set; }
            public Competitor[] competitors { get; set; }
            public Venue venue { get; set; }
            public Channel[] channels { get; set; }
        }

        public class Sport_Event_Context
        {
            public Sport sport { get; set; }
            public Category category { get; set; }
            public Competition competition { get; set; }
            public Season season { get; set; }
            public Stage stage { get; set; }
        }

        public class Sport
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Category
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Competition
        {
            public string id { get; set; }
            public string name { get; set; }
            public string parent_id { get; set; }
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

        public class Stage
        {
            public string type { get; set; }
        }

        public class Coverage
        {
            public bool live { get; set; }
            public string type { get; set; }
            public Sport_Event_Properties sport_event_properties { get; set; }
        }

        public class Sport_Event_Properties
        {
            public bool data_complete { get; set; }
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

        public class Competitor
        {
            public string id { get; set; }
            public string name { get; set; }
            public string abbreviation { get; set; }
            public string qualifier { get; set; }
            public string gender { get; set; }
        }

        public class Channel
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Sport_Event_Status
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
        }

        public class Statistics
        {
            public Totals totals { get; set; }
            public Period[] periods { get; set; }
        }

        public class Totals
        {
            public Competitor1[] competitors { get; set; }
        }

        public class Competitor1
        {
            public string id { get; set; }
            public string name { get; set; }
            public string abbreviation { get; set; }
            public string qualifier { get; set; }
            public Statistics1 statistics { get; set; }
        }

        public class Statistics1
        {
            public string control { get; set; }
            public int knockdowns { get; set; }
            public float significant_strike_percentage { get; set; }
            public int significant_strikes { get; set; }
            public int significant_strikes_attempted { get; set; }
            public int submission_attempts { get; set; }
            public float takedown_percentage { get; set; }
            public int takedowns { get; set; }
            public int takedowns_attempted { get; set; }
            public float total_strike_percentage { get; set; }
            public int total_strikes { get; set; }
            public int total_strikes_attempted { get; set; }
        }

        public class Period
        {
            public int number { get; set; }
            public Competitor2[] competitors { get; set; }
        }

        public class Competitor2
        {
            public string id { get; set; }
            public string name { get; set; }
            public string abbreviation { get; set; }
            public string qualifier { get; set; }
            public Statistics2 statistics { get; set; }
        }

        public class Statistics2
        {
            public string control { get; set; }
            public int knockdowns { get; set; }
            public float significant_strike_percentage { get; set; }
            public int significant_strikes { get; set; }
            public int significant_strikes_attempted { get; set; }
            public int submission_attempts { get; set; }
            public int takedown_percentage { get; set; }
            public int takedowns { get; set; }
            public int takedowns_attempted { get; set; }
            public float total_strike_percentage { get; set; }
            public int total_strikes { get; set; }
            public int total_strikes_attempted { get; set; }
        }

    }
}
