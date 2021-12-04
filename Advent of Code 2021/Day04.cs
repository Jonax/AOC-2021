namespace Advent_of_Code_2021
{
    public class BingoSheet
    {
        public int Size { get; private set; }

        private readonly List<int> _tileOrder = new ();

        private readonly Dictionary<int, bool> _tiles = new ();

        private readonly List<List<int>> _lines = new();

        public int UnmarkedSum => _tiles.Where(kv => kv.Value == false)
                                        .Sum(kv => kv.Key);

        public BingoSheet(string sourceData)
        {
            List<List<int>> grid = sourceData.Split("\n")
                                             .Select(row => row.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                            .Select(i => Convert.ToInt32(i))
                                                            .ToList())
                                             .ToList();

            int width = grid[0].Count;
            int height = grid.Count;

            if (width != height)
            {
                throw new Exception("Malformed grid");
            }
            Size = height;

            _tileOrder = grid.SelectMany(row => row)
                             .ToList();

            _tiles = _tileOrder.ToDictionary(x => x, x => false);

            // Rows
            _lines.AddRange(Enumerable.Range(0, Size)
                                      .Select(row => Enumerable.Range(row * Size, Size)
                                                               .ToList()));

            // Columns
            _lines.AddRange(Enumerable.Range(0, Size)
                                      .Select(col => Enumerable.Range(0, Size)
                                                               .Select(row => (row * Size) + col)
                                                               .ToList()));
        }

        public bool MarkCard(params int[] numbers)
        {
            bool marked = false;
            foreach (int number in numbers)
            {
                if (_tiles.ContainsKey(number))
                {
                    _tiles[number] = true;
                    marked = true;
                }
            }

            if (!marked)
            {
                return false;
            }

            foreach (IEnumerable<int> line in _lines)
            {
                if (line.All(i => _tiles[_tileOrder[i]]))
                {
                    return true;
                }
            }

            return false;
        }
    }

    public class Day04
    {
        public static int Execute(IEnumerable<string> segments, bool intentionallyLose = false)
        {
            List<int> callList = segments.First()
                                         .Split(',')
                                         .Select(x => Convert.ToInt32(x))
                                         .ToList();

            List<BingoSheet> sheets = segments.Skip(1)
                                              .Select(t => new BingoSheet(t))
                                              .ToList();

            int sheetSize = sheets.Select(s => s.Size)
                                  .Distinct()
                                  .Single();

            int targetNumber = intentionallyLose ? sheets.Count : 1;

            List<BingoSheet> winningSheets = new ();

            IEnumerable<BingoSheet> winners = sheets.Where(s => s.MarkCard(callList.Take(sheetSize).ToArray()))
                                                    .ToList();
            if (winners.Any())
            {
                winningSheets.AddRange(winners);

                sheets = sheets.Except(winners)
                               .ToList();
            }

            IEnumerator<int> bingoCall = callList.Skip(sheetSize).GetEnumerator();
            while (winningSheets.Count < targetNumber)
            {
                bingoCall.MoveNext();

                winners = sheets.Where(s => s.MarkCard(bingoCall.Current))
                                .ToList();

                if (winners.Any())
                {
                    winningSheets.AddRange(winners);

                    sheets = sheets.Except(winners)
                                   .ToList();
                }
            }

            return bingoCall.Current * winningSheets.Last().UnmarkedSum;
        }
    }
}