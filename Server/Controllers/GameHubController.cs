using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SpotIt.Shared;

namespace SpotIt.Server.Controllers
{
    public class GameHub : Hub
    {
        private readonly int SYMBOLS_PER_CARD = 8;
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
            var gameIndex = db.Games.FindIndex(x => x.Id == game.Id);
            if (gameIndex >= 0)
                db.Games[gameIndex] = game;
            else
                db.Games.Add(game);

            await Clients.Groups(game.Id).SendAsync("Refresh", game);
        }

        public async Task JoinGame(string gameId, string name)
        {
            var gameIndex = db.Games.FindIndex(x => x.Id == gameId);
            if (gameIndex < 0)
                return;

            var player = new Player() {Name = name};
            db.Games[gameIndex].Players.Add(player);

            await Clients.Groups(gameId).SendAsync("Refresh", db.Games[gameIndex]);
        }

        public async Task PlayCard(string gameId, string name, Card card, int match)
        {
            var gameIndex = db.Games.FindIndex(x => x.Id == gameId);
            if (gameIndex < 0)
                return;
            var playerIndex = db.Games[gameIndex].Players.FindIndex(x => x.Name == name);
            if (playerIndex < 0)
                return;

            if (db.Games[gameIndex].Cards.Last().items.Contains(match))
            {
                db.Games[gameIndex].Cards.Add(card);
                db.Games[gameIndex].Players[playerIndex].Cards.RemoveAt(db.Games[gameIndex].Players[playerIndex].Cards.Count - 1);
            }

            if (db.Games[gameIndex].Players[playerIndex].Cards.Count == 0)
            {
                await FinishGame(gameId);
            }
            else
            {
                await Clients.Groups(gameId).SendAsync("Refresh", db.Games[gameIndex]);
            }
        }

        public async Task Connect(string gameId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, gameId);
        }

        public async Task LoadGame(string gameId)
        {
            var game = db.Games.Find(x => x.Id == gameId);

            await Clients.Groups(gameId).SendAsync("Refresh", game);
        }

        public async Task StartGame(string gameId)
        {
            var gameIndex = db.Games.FindIndex(x => x.Id == gameId);
            if (gameIndex >= 0)
            {
                db.Games[gameIndex].State = Game.GameState.Started;
                db.Games[gameIndex].Cards = new CardBuilder().MakeCards(SYMBOLS_PER_CARD);
                db.Games[gameIndex].Shuffle();

                await DealCards(gameId);

                await Clients.Groups(gameId).SendAsync("Refresh", db.Games[gameIndex]);
            }
        }

        private async Task DealCards(string gameId)
        {
            var gameIndex = db.Games.FindIndex(x => x.Id == gameId);
            if (gameIndex >= 0 && db.Games[gameIndex].Players.Count > 0)
            {
                var nCards = db.Games[gameIndex].Cards.Count;
                var nPlayers = db.Games[gameIndex].Players.Count;
                var cardsPerPlayer = nCards / (nPlayers + 1);

                foreach (var i in Enumerable.Range(0, nPlayers))
                {
                    db.Games[gameIndex].Players[i].Cards = db
                        .Games[gameIndex].Cards
                        .Skip(cardsPerPlayer * i)
                        .Take(cardsPerPlayer)
                        .ToList();
                }
                db.Games[gameIndex].Cards = db
                    .Games[gameIndex].Cards
                    .Skip(cardsPerPlayer * nPlayers)
                    .Take(cardsPerPlayer)
                    .ToList();

                await Clients.Groups(gameId).SendAsync("Refresh", db.Games[gameIndex]);
            }
        }

        public async Task FinishGame(string gameId)
        {
            var gameIndex = db.Games.FindIndex(x => x.Id == gameId);
            if (gameIndex >= 0)
                db.Games[gameIndex].State = Game.GameState.Finished;

            await Clients.Groups(gameId).SendAsync("Refresh", db.Games[gameIndex]);
        }

        public async Task ListGames()
        {
            await Clients.All.SendAsync("GameList", db.Games);
        }
    }
}