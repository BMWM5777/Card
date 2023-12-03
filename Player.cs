using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card
{
    class Player
    {
        public string Name { get; }
        private List<Karta> cards;

        public Player(string name)
        {
            Name = name;
            cards = new List<Karta>();
        }

        public void AddCard(Karta card)
        {
            cards.Add(card);
        }

        public void AddCards(List<Karta> newCards)
        {
            cards.AddRange(newCards);
        }

        public Karta PlayCard()
        {
            // Игрок кладет карту
            if (cards.Count > 0)
            {
                Karta playedCard = cards.First();
                cards.Remove(playedCard);
                return playedCard;
            }

            return null; // Возвращаем null, если карты закончились
        }


        public bool HasCards()
        {
            // Проверка на наличие карт у игрока
            return cards.Count > 0;
        }

        public bool HasCard(Karta card)
        {
            // Проверка наличия конкретной карты у игрока
            return cards.Contains(card);
        }

        public int GetCardCount()
        {
            return cards.Count;
        }
    }

}
