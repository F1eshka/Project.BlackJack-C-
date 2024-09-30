using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.BlackJack
{
    internal class Deck
    {
        private List<Card> cards;

        // Генерация всех карт
        public Deck()
        {
            cards = new List<Card>();

            foreach (var Suit in Card.Suits)
            {
                foreach (var Rank in Card.Ranks)
                {
                    cards.Add(new Card(Rank, Suit));
                }
            }

        }

        // Перемешиваем колоду
        public void Shuffle()
        {
            Random random = new Random();
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                Card temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }

        public Card DealCard()
        {
            if (cards.Count == 0)
            {
                throw new InvalidOperationException("Не осталось карт в колоде");
            }
            Card dealcard = cards[0]; //Берём карту
            cards.RemoveAt(0); //Удаляем ёё
            return dealcard; //Возвращаем карту, которую взяли

        }

        public int CardsRemaining()
        {
            return cards.Count; 
        }
    

    }
}
