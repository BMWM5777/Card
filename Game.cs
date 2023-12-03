using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card
{
    class Game
    {
        private List<Player> players;
        private List<Karta> deck;

        public Game()
        {
            // Инициализация игроков
            players = new List<Player>
        {
            new Player("Dilsha M5"),
            new Player("Индеец")
            // Добавьте еще игроков по мере необходимости
        };

            // Инициализация колоды карт
            deck = InitializeDeck();
        }

        public void Play()
        {
            // Перетасовка карт
            ShuffleDeck();

            // Раздача карт игрокам
            DealCards();

            // Игровой процесс
            while (deck.Count > 0)
            {
                PlayRound();
            }

            // Выводим результаты
            DisplayResults();
        }

        private List<Karta> InitializeDeck()
        {
            // Инициализация колоды карт
            List<Karta> deck = new List<Karta>();
            string[] suits = { "Пики", "Трефы", "Черви", "Бубны" };
            string[] ranks = { "6", "7", "8", "9", "10", "Валет", "Дама", "Король", "Туз" };

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    deck.Add(new Karta(suit, rank));
                }
            }

            return deck;
        }

        private void ShuffleDeck()
        {
            Random random = new Random();
            deck = deck.OrderBy(card => random.Next()).ToList();
        }

        private void DealCards()
        {
            int playerIndex = 0;
            foreach (var card in deck)
            {
                players[playerIndex].AddCard(card);
                playerIndex = (playerIndex + 1) % players.Count;
            }
        }

        private void PlayRound()
        {
            // Игровой процесс одного раунда
            List<Karta> roundCards = new List<Karta>();

            // Игроки кладут по одной карте
            foreach (var player in players)
            {
                Karta playedCard = player.PlayCard();

                if (playedCard != null)
                {
                    Console.WriteLine($"{player.Name} играет карту: {playedCard}");
                    roundCards.Add(playedCard);
                }
            }

            // Определяем победителя раунда
            if (roundCards.Any())
            {
                Karta winningCard = roundCards.OrderByDescending(card => card.GetValue()).First();
                Player roundWinner = players.First(player => player.HasCard(winningCard));
                Console.WriteLine($"Победитель раунда: {roundWinner.Name}");

                // Победитель забирает все карты и кладет их в конец своей колоды
                roundWinner.AddCards(roundCards);
            }
            else
            {
                Console.WriteLine("Ничья в этом раунде.");
            }
        }


        private void DisplayResults()
        {
            // Выводим результаты игры
            foreach (var player in players)
            {
                Console.WriteLine($"{player.Name}: {player.GetCardCount()} карт");
            }

            // Определяем победителя игры
            Player gameWinner = players.OrderByDescending(player => player.GetCardCount()).First();
            Console.WriteLine($"Победитель игры: {gameWinner.Name}");
        }
    }
}
