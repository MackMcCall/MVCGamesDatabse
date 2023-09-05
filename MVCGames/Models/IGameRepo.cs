namespace MVCGames.Models
{
    public interface IGameRepo
    {
        public IEnumerable<Game> GetAllGames();
        public Game GetGame(int id);
        public void InsertGame(Game gameToInsert);
        public void UpdateGame(Game game);
        public void DeleteGame(Game game);
    }
}
