using SpotIt.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SpotIt.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> logger;
        private readonly InMemoryDb db;

        public GameController(ILogger<GameController> logger, InMemoryDb db)
        {
            this.logger = logger;
            this.db = db;
        }

        [HttpGet]
        public List<Game> Get()
        {
            return db.Games;
        }

        [HttpGet("{gameId}")]
        public Game Get(string gameId)
        {
            return db.Games.Find(x => x.Id == gameId);
        }

        [HttpPost]
        public bool Post(Game game)
        {
            var gameIndex = db.Games.FindIndex(x => x.Id == game.Id);
            if (gameIndex >= 0)
                db.Games[gameIndex] = game;
            else
                db.Games.Add(game);

            return true;
        }

        [HttpPost("{gameId}/join")]
        public bool Join(string gameId, [FromBody] string name)
        {
            var gameIndex = db.Games.FindIndex(x => x.Id == gameId);
            if (gameIndex >= 0)
                db.Games[gameIndex].Players.Add(new Player(){ Name = name});

            return true;
        }
        [HttpDelete("{gameId}")]
        public bool Delete(string gameId)
        {
            var gameIndex = db.Games.FindIndex(x => x.Id == gameId);
            if (gameIndex >= 0)
                db.Games.RemoveAt(gameIndex);

            return true;
        }
    }
}
