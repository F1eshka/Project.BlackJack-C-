using System;

namespace PROJECT.BlackJack
{
    internal class Player
    {
        public string Name { get; private set; }  
        public Hand Hand { get; private set; }   

        // Конструктор игрока
        public Player(string name)
        {
            Name = name;
            Hand = new Hand();  // Инициализируем пустую руку для игрока
        }

        // Метод для добавления карты игроку
        public void AddCard(Card card)
        {
            Hand.AddCard(card);
            Console.WriteLine($"{Name} получает карту: {card}");
        }

        // Метод для отображения состояния игрока
        public void ShowHand()
        {
            Console.WriteLine($"{Name} имеет следующие карты:");
            Console.WriteLine(Hand); 
            Console.WriteLine($"Очки: {Hand.CalculateValue()}");

            if (Hand.IsBusted())
            {
                Console.WriteLine($"{Name} проиграл! Перебор очков");
            }
        }

        // Метод для проверки, проиграл ли игрок 
        public bool HasBusted()
        {
            return Hand.IsBusted();
        }
    }
}
