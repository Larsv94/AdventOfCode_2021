namespace day_4;

public class BingoCard
{
    public bool isWinner = false;

    SortedDictionary<int, Position> UnmarkedPositions { get; set; }

    bool[][] Marked { get; set; }
    public BingoCard(int[][] numbers)
    {
        UnmarkedPositions = new(GetPositionsOnBoard(numbers));

        var rows = numbers.Length;
        var columns = numbers[0].Length;

        Marked = Enumerable
                  .Range(0, rows)
                  .Select(i => new bool[columns])
                  .ToArray();
    }
    public int GetUnmarkedSum()
    {
        return UnmarkedPositions.Sum(x => x.Key);
    }
    public bool MarkAndCheck(int rolled)
    {
        if (!UnmarkedPositions.ContainsKey(rolled))
        {
            return false;
        }
        var pos = UnmarkedPositions[rolled];
        Mark(pos);
        UnmarkedPositions.Remove(rolled);
        return Check(pos);
    }

    private void Mark(Position pos)
    {
        Marked[pos.Row][pos.Column] = true;
    }

    private bool Check(Position pos)
    {
        isWinner = CheckRow(pos.Row) || CheckColumn(pos.Column);
        return isWinner;
    }


    private bool CheckRow(int row)
    {
        return Marked[row].All(x => x);
    }
    private bool CheckColumn(int column)
    {
        return Enumerable
                  .Range(0, 5)
                  .All(row => Marked[row][column]);
    }

    private Dictionary<int, Position> GetPositionsOnBoard(int[][] numbers)
    {
        var positions = new Dictionary<int, Position>();
        var rowIndex = 0;
        foreach (var row in numbers)
        {
            var columnIndex = 0;
            foreach (var column in row)
            {
                positions[column] = new Position(columnIndex, rowIndex);
                columnIndex++;
            }
            rowIndex++;
        }
        return positions;
    }
    private record Position(int Column, int Row);
}
