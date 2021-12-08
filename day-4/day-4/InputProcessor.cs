namespace day_4;

public class InputProcessor
{
    public IEnumerable<string> GetInput(string path)
    {
        return File.ReadAllLines(path);
    }

    public IEnumerable<int> GetRollsFromInput(IEnumerable<string> lines)
    {
        return lines.First().Split(new[] { ',' }).Select(num => int.Parse(num));
    }

    public List<BingoCard> GetBingoCards(IEnumerable<string> lines)
    {
        var cardLines = lines
            .Skip(1)
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Select((x, i) => new { Index = i, Value = x })
            .GroupBy(x => x.Index / 5)
            .Select(x => x.Select(
                v => v.Value
                .Split(' ')
                .Where(num => !string.IsNullOrWhiteSpace(num))
                .Select(num => int.Parse(num))
                )
            );
        var cards = cardLines.Select(lines => new BingoCard(lines.Select(x=>x.ToArray()).ToArray()));
        return cards.ToList();
    }
}
