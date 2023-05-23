namespace eventmanager.Models
{
    public class champions
    {
        public class Rootobject
        {
            public DateTime generated_at { get; set; }
            public Category[] categories { get; set; }
        }

        public class Category
        {
            public string id { get; set; }
            public string name { get; set; }
            public Weight_Classes[] weight_classes { get; set; }
        }

        public class Weight_Classes
        {
            public string description { get; set; }
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
