using System.Collections;

namespace Advent_of_Code_2021
{
    public class Day03
    {
        private static string FilterByBit(IEnumerable<string> binaries, bool commonBit = true)
        {
            int minLength = binaries.Min(b => b.Length);

            for (int i = 0; i < minLength; i++)
            {
                // Since "least common bit" is the polar opposite of the "most common bit" check, we can simply calculate
                // the latter and flip to get the former if needed instead.
                bool targetBit = (binaries.Select(b => b[i]).Count(x => x == '1') * 2) >= binaries.Count();
                if (!commonBit)
                {
                    targetBit = !targetBit;
                }

                binaries = binaries.Where(r => (r[i] == '1') == targetBit)
                                   .ToList();

                if (binaries.Count() == 1)
                {
                    return binaries.Single();
                }
            }

            throw new Exception();
        }

        public static int PartA(IEnumerable<string> binaries)
        {
            int minLength = binaries.Min(b => b.Length);

            IEnumerable<bool> commonBits = Enumerable.Range(0, minLength)
                                                     .Select(i => (binaries.Select(b => b[i]).Count(x => x == '1') * 2) > binaries.Count())
                                                     .ToList();

            int gamma = Convert.ToInt32(string.Join(string.Empty, commonBits.Select(b => b ? "1" : "0")), 2);
            int epsilon = Convert.ToInt32(string.Join(string.Empty, commonBits.Select(b => b ? "0" : "1")), 2);

            return gamma * epsilon;
        }

        public static int PartB(IEnumerable<string> binaries)
        {
            var oxygen = Convert.ToInt32(FilterByBit(binaries), 2);
            var co2 = Convert.ToInt32(FilterByBit(binaries, commonBit: false), 2);

            return oxygen * co2;
        }
    }
}