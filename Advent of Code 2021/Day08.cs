namespace Advent_of_Code_2021
{
    public class Day08
    {
        public static Dictionary<HashSet<char>, byte> DecodePatterns(IEnumerable<HashSet<char>> patterns)
        {
            List<HashSet<char>> remaining = patterns.ToList();
            Dictionary<byte, HashSet<char>> decoded = new ();

            // Get initial uniques
            foreach (HashSet<char> pattern in patterns)
            {
                switch (pattern.Count)
                {
                    case 2:
                        decoded[1] = pattern;
                        remaining.Remove(pattern);
                        break;

                    case 3:
                        decoded[7] = pattern;
                        remaining.Remove(pattern);
                        break;

                    case 4:
                        decoded[4] = pattern;
                        remaining.Remove(pattern);
                        break;

                    case 7:
                        decoded[8] = pattern;
                        remaining.Remove(pattern);
                        break;
                }
            }

            // 9 should be the only one that has the subset of 4 and one unknown.
            decoded[9] = remaining.Single(p => p.Count == 6 && p.IsProperSupersetOf(decoded[4]) && p.Except(decoded[4]).Count() == 2);
            remaining.Remove(decoded[9]);

            // 0 should be one of two remaining six-segment digits, and the only one 1 or 7 both fit into.
            decoded[0] = remaining.Single(p => p.Count == 6 && p.IsProperSupersetOf(decoded[7]));
            remaining.Remove(decoded[0]);

            // 6 should be the only six-segment digit left.
            decoded[6] = remaining.Single(p => p.Count == 6);
            remaining.Remove(decoded[6]);

            // 5 should be the remaining digit that fits into 6.
            decoded[5] = remaining.Single(p => p.IsProperSubsetOf(decoded[6]));
            remaining.Remove(decoded[5]);

            // 3 should be the remaining digit that fits into 1
            decoded[3] = remaining.Single(p => p.IsProperSupersetOf(decoded[1]));
            remaining.Remove(decoded[3]);

            // 2 is the last one left.
            decoded[2] = remaining.Single();

            return decoded.ToDictionary(kv => kv.Value, kv => kv.Key, HashSet<char>.CreateSetComparer());
        }

        public static int Execute(string patterns, string digits)
        {
            Dictionary<HashSet<char>, byte> decoded = DecodePatterns(patterns.Split(" ")
                                                                             .Select(x => x.ToHashSet())
                                                                             .ToList());

            return int.Parse(string.Join(string.Empty, digits.Split(" ")
                                                             .Select(x => decoded[x.ToHashSet()])));
        }
    }
}