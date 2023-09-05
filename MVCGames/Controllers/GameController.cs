using Microsoft.AspNetCore.Mvc;
using MVCGames.Models;

namespace MVCGames.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameRepo repo;
        public GameController(IGameRepo repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var games = repo.GetAllGames();
            return View(games);
        }

        public IActionResult ViewGame(int id)
        {
            var game = repo.GetGame(id);
            return View(game);
        }

        public IActionResult UpdateGame(int id)
        {
            Game game = repo.GetGame(id);
            if (game == null)
            {
                return View("Product Not Found");
            }
            return View(game);
        }

        public IActionResult UpdateGameToDatabase(Game game)
        {
            repo.UpdateGame(game);

            return RedirectToAction("ViewGame", new { id = game.GameID });
        }

        public IActionResult InsertGame(Game gameToInsert)
        {
            return View(gameToInsert);
        }

        public IActionResult InsertGameToDatabase(Game gameToInsert)
        {
            repo.InsertGame(gameToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteGame(Game game)
        {
            repo.DeleteGame(game);
            return RedirectToAction("Index");
        }
    }
}
