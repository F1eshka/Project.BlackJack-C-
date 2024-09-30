using System;

namespace PROJECT.BlackJack
{
    internal class Dealer
    {
        public Hand Hand { get; private set; }  // Рука дилера

        // Конструктор дилера
        public Dealer()
        {
            Hand = new Hand();  // Инициализируем пустую руку для дилера
        }

        // Метод для добавления карты дилеру
        public void AddCard(Card card)
        {
            Hand.AddCard(card);
            Console.WriteLine($"Дилер получает карту: {card}");
        }

        // Метод для показа первой карты дилера
        public void ShowFirstCard()
        {
            if (Hand.CardsRemaining() > 0) // Проверка, есть ли карты
            {
                Console.WriteLine($"Первая карта дилера: {Hand.ToString().Split(' ')[0]}");
            }
            else
            {
                Console.WriteLine("У дилера ещё нет карт");
            }
        }

        // Метод, при котором дилер берёт карты
        public void PlayTurn(Deck deck)
        {
            while (Hand.CalculateValue() < 21)
            {
                AddCard(deck.DealCard());
                Console.WriteLine($"Очки дилера: {Hand.CalculateValue()}");
            }

            if (Hand.IsBusted())
            {
                Console.WriteLine("Дилер проиграл! Перебор очков.");
            }
        }

        // Метод для проверки, перебрал ли дилер
        public bool HasBusted()
        {
            return Hand.IsBusted();
        }

        // Метод для отображения всех карт дилера
        public void ShowHand()
        {
            Console.WriteLine("Карты дилера:");
            Console.WriteLine(Hand);
            Console.WriteLine($"Очки дилера: {Hand.CalculateValue()}");
        }
    }
}
