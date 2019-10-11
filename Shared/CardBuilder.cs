using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpotIt.Shared
{
    public class CardBuilder
    {
        //based on https://www.ryadel.com/en/dobble-spot-it-algorithm-math-function-javascript/amp/

        public List<Card> MakeCards(int itemsPerCard)
        {
            var cards = new List<Card>();

            // Generate cards from 1 to N
            for (var i = 0; i <itemsPerCard; i++)
            {
                var card = new Card();
                card.items.Add(1);
                for (var j = 1; j < itemsPerCard; j++)
                {
                    card.items.Add((itemsPerCard - 1) + (itemsPerCard - 1) * (i - 1) + (j + 1));
                }

                card.items = Shuffle(card.items);
                cards.Add(card);
            }

            // Generate cards from N+1 to N+(N-1)*(N-1)
            for (var i = 1; i < itemsPerCard; i++)
            {
                for (var j = 1; j < itemsPerCard; j++)
                {
                    var card = new Card();
                    card.items.Add(i + 1);
                    for (var k = 1; k <itemsPerCard; k++)
                    {
                        card.items.Add((itemsPerCard + 1) + (itemsPerCard - 1) * (k - 1) + (((i - 1) * (k - 1) + (j - 1))) % (itemsPerCard - 1));
                    }

                    card.items = Shuffle(card.items);
                    cards.Add(card);
                }
            }
            return cards;
        }

        private Random rnd = new Random();

        public List<int> Shuffle(List<int> lst) => lst
                .Select(x => new { value = x, order = rnd.Next() })
                .OrderBy(x => x.order)
                .Select(x => x.value)
                .ToList();
    }
}
