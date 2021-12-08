namespace day_4;

internal class Game
{
    IEnumerable<BingoCard> Cards { get; set; }

    private List<(BingoCard card, int number)> _Results = new(); 

    public (BingoCard card, int number) Winner => _Results.First();

    public (BingoCard card, int number) Loser => _Results.Last();

    public Game(IEnumerable<BingoCard> cards)
    {
        Cards = cards ?? throw new ArgumentNullException(nameof(cards));
    }

    public void PlayGame(IEnumerable<int> drawnNumbers)
    {
        foreach (var number in drawnNumbers)
        {
            var playingCards = Cards.Where(c => !c.isWinner).ToArray();
            foreach (var card in playingCards)
            {
                var isWinner = card.MarkAndCheck(number);
                if (isWinner)
                {
                    _Results.Add((card, number));
                }
            }
        }
    }
}
