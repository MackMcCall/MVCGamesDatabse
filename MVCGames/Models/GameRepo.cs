using Dapper;
using System.Data;

namespace MVCGames.Models
{
    public class GameRepo : IGameRepo
    {
        private readonly IDbConnection _conn;

        public GameRepo(IDbConnection conn)
        {
            _conn = conn;
        }

        public Game GetGame(int id)
        {
            return _conn.QuerySingle<Game>("SELECT * FROM videogames WHERE GameID = @id;", new {id});
        }

        public IEnumerable<Game> GetAllGames()
        {
            return _conn.Query<Game>("SELECT * FROM videogames;");
        }

        public void InsertGame(Game gameToInsert)
        {
            _conn.Execute("INSERT INTO videogames (TITLE, GENRE, RELEASEYEAR, PUBLISHER, PLATFORM) " +
                "VALUES (@title, @genre, @releaseYear, @publisher, @platform);",
                new { title = gameToInsert.Title, genre = gameToInsert.Genre, 
                      releaseYear = gameToInsert.ReleaseYear, publisher = gameToInsert.Publisher, 
                      platform = gameToInsert.Platform });
        }

        public void DeleteGame(Game game)
        {
            _conn.Execute("DELETE FROM videogames WHERE GameID = @id", new { id = game.GameID});
        }

        public void UpdateGame(Game game)
        {
            _conn.Execute("UPDATE videogames SET Title = @title, ReleaseYear = @releaseYear WHERE GameID = @id",
                new { title = game.Title, releaseYear = game.ReleaseYear, id = game.GameID });
        }
    }
}
