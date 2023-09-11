namespace JokesClient.Models
{
    public class Joke
    {
        public string _id { get; set; }
        public string setup { get; set; }
        public string punchline { get; set; }
        public string type { get; set; }
        public long date { get; set; }
        public bool NSFW { get; set; }
        public string shareableLink { get; set; }
    }
}
