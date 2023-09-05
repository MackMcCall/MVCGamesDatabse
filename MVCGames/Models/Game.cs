namespace MVCGames.Models
{
    public class Game
    {
        public int GameID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string Publisher { get; set; }
        public string Platform { get; set; }
    }
}
