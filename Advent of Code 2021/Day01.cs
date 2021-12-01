namespace Advent_of_Code_2021
{
    public class Day01
    {
        public static int Execute(IEnumerable<int> heights, int windowLength)
        {
            IEnumerable<int> sums = Enumerable.Range(0, heights.Count() - (windowLength - 1))
                                              .Select(i => heights.Skip(i)
                                                                  .Take(windowLength)
                                                                  .Sum())
                                              .ToList();

            return Enumerable.Range(0, sums.Count() - 1)
                             .Count(i =>
                             {
                                 int[] window = sums.Skip(i)
                                                    .Take(2)
                                                    .ToArray();

                                 return window[0] < window[1];
                             });
        }
    }
}