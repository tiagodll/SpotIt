using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpotIt.Shared
{
    public class CardBuilder
    {
        public List<Card> MakeCards(int size)
        {
            var cards = new List<Card>();

            for (var i = 0; i <= size; i++)
                cards.Add(MakeCard(cards, size, i));

            return cards;
        }

        public Card MakeCard(List<Card> cards, int size, int row)
        {
            var card = new Card();
            for (var i = 0; i < size; i++)
            {
                card.items.Add(i < row ? cards[i].items[row - 1] : CalculateCardItem(size, row, i));
            }
            return card;
        }
        private int CalculateCardItem(int size, int row, int i) => i + 1 + (row * size) - CalculateOffset(row);

        private int CalculateOffset(int row) => row == 0 ? 0 : Enumerable.Range(1, row).Aggregate((x, y) => x + y);
    }
}
