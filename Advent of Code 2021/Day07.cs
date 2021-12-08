namespace Advent_of_Code_2021
{
    public class Day07
    {
        public static IEnumerable<int> GetMedians(IEnumerable<int> positions)
        {
            List<int> ordered = positions.OrderBy(x => x)
                                         .ToList();

            return Enumerable.Range(Convert.ToInt32((positions.Count() - 1) / 2), Convert.ToBoolean(positions.Count() % 2) ? 1 : 2)
                             .Select(i => ordered[i])
                             .Distinct()
                             .ToList();
        }

        public static int GetFuelCost(int targetPosition, IEnumerable<int> positions, bool crabEngineering = false)
        {
            if (crabEngineering)
            {
                return positions.Sum(p => {
                                        int d = Math.Abs(targetPosition - p);
                                        
                                        return d * (d + 1) / 2;
                                    });
            }

            return positions.Sum(p => Math.Abs(targetPosition - p));
        }

        public static int Execute(IEnumerable<int> positions, bool crabEngineering = false)
        {
            IEnumerable<int> positionsToQuery = null;
            if (crabEngineering)
            {
                double avg = positions.Average();

                positionsToQuery = new int[] { (int)Math.Floor(avg), (int)Math.Ceiling(avg) }
                                   .Distinct();
            }
            else
            {
                positionsToQuery = GetMedians(positions);
            }

            return positionsToQuery.Min(i => GetFuelCost(i, positions, crabEngineering));
        }
    }
}