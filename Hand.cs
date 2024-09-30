using PROJECT.BlackJack;

internal class Hand
{
    private List<Card> cards;

    public Hand()
    {
        cards = new List<Card>();
    }

    public void AddCard(Card card)
    {
        cards.Add(card);
    }

    public int CalculateValue()
    {
        int totalValue = 0;
        foreach (var card in cards)
        {
            totalValue += card.Value;
        }
        return totalValue;
    }

    public bool IsBusted()
    {
        return CalculateValue() > 21;
    }

    // Метод для отображения карт в руке
    public override string ToString()
    {
        string handDescription = "Карты в руке: ";
        foreach (var card in cards)
        {
            handDescription += $"{card} ";
        }
        return handDescription;
    }

    public int CardsRemaining()
    {
        return cards.Count; // Возвращаем количество карт в руке
    }
}
