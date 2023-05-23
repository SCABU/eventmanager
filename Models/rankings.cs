namespace eventmanager.Models
{
    public class rankings
    {

        public class Rootobject
        {
            public DateTime generated_at { get; set; }
            public Ranking[] rankings { get; set; }
        }

        public class Ranking
        {
            public int type_id { get; set; }
            public string name { get; set; }
            public int year { get; set; }
            public int week { get; set; }
            public Competitor_Rankings[] competitor_rankings { get; set; }
        }

        public class Competitor_Rankings
        {
            public int rank { get; set; }
            public int movement { get; set; }
            public Competitor competitor { get; set; }
        }

        public class Competitor
        {
            public string id { get; set; }
            public string name { get; set; }
            public string abbreviation { get; set; }
            public string gender { get; set; }
        }

    }
}
