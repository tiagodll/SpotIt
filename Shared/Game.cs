using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotIt.Shared
{
    public class Game
    {
        public enum GameState { Created, Joined, Started, Finished }

        public DateTime Date { get; set; }

        public string Id { get; set; }

        public List<Player> Players { get; set; }

        public List<Card> Cards { get; set; }

        public GameState State { get; set; }

        public Game() => Init(null);

        public Game(string gameId) => Init(gameId);

        private void Init(string gameId)
        {
            this.State = GameState.Created;
            this.Date = DateTime.Now;
            this.Id = gameId ?? new Random().Next(0, 999).ToString();
            this.Players = new List<Player>();
        }

        public void Shuffle()
        {
            Random rnd = new Random(); 

            this.Cards = Cards
                .Select(x => new { value = x, order = rnd.Next() })
                .OrderBy(x => x.order)
                .Select(x => x.value)
                .ToList();
        }
    }
}
