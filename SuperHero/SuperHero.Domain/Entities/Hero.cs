namespace SuperHero.Domain.Entities
{
    public class Hero
    {
        public int id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string image { get; set; }
        //Power Stats
        public string intelligence { get; set; }
        public string strength { get; set; }
        public string speed { get; set; }
        public string durability { get; set; }
        public string power { get; set; }
        public string combat { get; set; }
        //Work
        public string occupation { get; set; }
        public string @base { get; set; }
    }
}
