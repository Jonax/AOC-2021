namespace Advent_of_Code_2021
{
    public class Day05
    {
        private static IEnumerable<(int, int)> IterateLine((int startX, int startY, int endX, int endY) line, bool includeDiagonals)
        {
            int width = Math.Abs(line.endX - line.startX);
            int height = Math.Abs(line.endY - line.startY);

            if (height == 0)
            {
                for (int x = Math.Min(line.startX, line.endX); x <= Math.Max(line.startX, line.endX); x++)
                {
                    yield return (x, line.startY);
                }
            }
            else if (width == 0)
            {
                for (int y = Math.Min(line.startY, line.endY); y <= Math.Max(line.startY, line.endY); y++)
                {
                    yield return (line.startX, y);
                }
            }
            else if (includeDiagonals && width == height)
            {
                int xGradient = (line.endX - line.startX) / width;
                int yGradient = (line.endY - line.startY) / height;

                for (int i = 0; i <= width; i++)
                {
                    yield return (line.startX + (i * xGradient),
                                  line.startY + (i * yGradient));
                }
            }
        }

        public static int Execute(IEnumerable<(int, int, int, int)> lines, bool includeDiagonals = false)
        {
            Dictionary<(int x, int y), int> grid = new ();

            // Also works for if quads were defined instead of lines, but it means the one codepath for
            // horizontal & vertical lines.
            foreach (var line in lines)
            {
                var x = IterateLine(line, includeDiagonals).ToList();
                foreach (var cell in IterateLine(line, includeDiagonals))
                {
                    if (!grid.ContainsKey(cell))
                    {
                        grid[cell] = 0;
                    }

                    grid[cell]++;
                }
            }

            return grid.Values.Count(v => v > 1);
        }
    }
}