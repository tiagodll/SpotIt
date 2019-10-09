using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SpotIt.Shared;

namespace SpotIt.Server.Controllers
{
    public class GameHub : Hub
    {
        private readonly InMemoryDb db;
        public GameHub(InMemoryDb db)
        {
            this.db = db;
        }
        public Task Refresh(string gameId, Game game)
        {
            return Clients.All.SendCoreAsync("refresh", new object[]{ game });
        }

        public async Task CreateGame(Game game)
        {
            var gameIndex = db.Rooms.FindIndex(x => x.Id == game.Id);
            if (gameIndex >= 0)
                db.Rooms[gameIndex] = game;
            else
                db.Rooms.Add(game);

            await Clients.All.SendAsync("Refresh", game);
        }

        public async Task JoinGame(string gameId, string player)
        {
            var gameIndex = db.Rooms.FindIndex(x => x.Id == gameId);
            if (gameIndex >= 0)
                db.Rooms[gameIndex].Players.Add(player);

            await Clients.All.SendAsync("Refresh", db.Rooms[gameIndex]);
        }

        public async Task LoadGame(string gameId)
        {
            var game = db.Rooms.Find(x => x.Id == gameId);
            await Clients.All.SendAsync("Refresh", game);
            //await Clients.Group(BOT_GROUP).SendAsync("LoadGame", board, Context.ConnectionId);
        }

        public async Task StartGame(string gameId)
        {
            var gameIndex = db.Rooms.FindIndex(x => x.Id == gameId);
            if (gameIndex >= 0)
                db.Rooms[gameIndex].State = Game.GameState.Started;

            await Clients.All.SendAsync("Refresh", db.Rooms[gameIndex]);
        }

        public async Task FinishGame(string gameId)
        {
            var gameIndex = db.Rooms.FindIndex(x => x.Id == gameId);
            if (gameIndex >= 0)
                db.Rooms[gameIndex].State = Game.GameState.Finished;

            await Clients.All.SendAsync("Refresh", db.Rooms[gameIndex]);
        }

    }
}