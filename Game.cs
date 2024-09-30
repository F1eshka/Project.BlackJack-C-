using System;

namespace PROJECT.BlackJack
{
    internal class Game
    {
        private Deck deck;
        private Player player;
        private Dealer dealer;

        // Конструктор игры
        public Game()
        {
            deck = new Deck();
            deck.Shuffle();  // Перемешиваем колоду

            Console.WriteLine("Введите имя игрока:");
            string playerName = Console.ReadLine();
            player = new Player(playerName);  // Создаём игрока

            dealer = new Dealer();  // Создаём дилера
        }

        // Основной метод для запуска игры
        public void Start()
        {
            // Раздаём игроку и дилеру по одной карте
            player.AddCard(deck.DealCard());
            dealer.AddCard(deck.DealCard());

            // Игровой цикл
            while (true)
            {
                // Показываем карты игрока
                player.ShowHand();

                // Показываем первую карту дилера
                dealer.ShowFirstCard();

                // Ход игрока
                PlayerTurn(deck, player);

                // Проверяем, перебрал ли игрок
                if (player.HasBusted())
                {
                    Console.WriteLine("Вы проиграли!");
                    return; // Завершаем игру
                }

                // Дилер берёт карту сразу после игрока
                if (!dealer.HasBusted() && dealer.Hand.CalculateValue() < 21)
                {
                    dealer.AddCard(deck.DealCard());
                }

                // Проверяем, перебрал ли дилер
                if (dealer.HasBusted())
                {
                    dealer.ShowHand(); // Показываем карты дилера
                    Console.WriteLine("Дилер проиграл! Перебор очков.");
                    return; // Завершаем игру
                }

                // После того как игрок закончил брать карты, дилер играет по своим правилам
                dealer.PlayTurn(deck);

                // Показываем карты дилера
                dealer.ShowHand();

                // Определение победителя
                DetermineWinner();
                return; // Завершаем игру после определения победителя
            }
        }

        // Метод для хода игрока
        public void PlayerTurn(Deck deck, Player player)
        {
            while (true)  // Бесконечный цикл для хода игрока
            {
                Console.WriteLine("Нажмите 'Y', чтобы взять карту, или 'N', чтобы остановиться");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);  // Читаем нажатие клавиши

                if (keyInfo.Key == ConsoleKey.Y)  // Если нажата 'Y'
                {
                    Card drawnCard = deck.DealCard();  // Игрок берёт карту
                    player.AddCard(drawnCard);  // Добавляем карту в руку игрока

                    // Проверяем, не перебрал ли игрок очки
                    if (player.HasBusted())
                    {
                        break;  // Выходим из цикла, если игрок проиграл
                    }
                }
                else if (keyInfo.Key == ConsoleKey.N)  // Если нажата 'N'
                {
                    break;  // Выходим из цикла, если игрок решил остановиться
                }
            }
        }

        // Метод для определения победителя
        private void DetermineWinner()
        {
            int playerValue = player.Hand.CalculateValue();
            int dealerValue = dealer.Hand.CalculateValue();

            if (player.HasBusted())
            {
                Console.WriteLine("Дилер победил");
            }
            else if (dealer.Hand.IsBusted())
            {
                Console.WriteLine($"{player.Name} победил! У дилера перебор");
            }
            else if (playerValue > dealerValue)
            {
                Console.WriteLine($"{player.Name} победил с {playerValue} очками против {dealerValue} у дилера");
            }
            else if (playerValue < dealerValue)
            {
                Console.WriteLine($"Дилер победил с {dealerValue} очками против {playerValue} у {player.Name}");
            }
            else
            {
                Console.WriteLine("Ничья!");
            }
        }
    }
}
