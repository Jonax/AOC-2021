using System.Numerics;

namespace Advent_of_Code_2021
{
    public class Day06
    {
        public static BigInteger Execute(int numIterations, IEnumerable<byte> initialStates)
        {
            Dictionary<byte, BigInteger> fishGroups = Enumerable.Range(0, 7)
                                                                .ToDictionary(i => Convert.ToByte(i), _ => new BigInteger(0));

            foreach (IGrouping<byte, byte> initialFish in initialStates.GroupBy(n => n))
            {
                fishGroups[initialFish.Key] += initialFish.Count();
            }

            byte groupI = 0;

            BigInteger buffer7 = 0;
            BigInteger buffer8 = 0;
            for (int n = 0; n < numIterations; n++)
            {
                BigInteger temp = buffer7;
                buffer7 = buffer8;
                buffer8 = fishGroups[groupI];
                fishGroups[groupI] += temp;

                // For some reason, running modulus turns the result into a byte (hence the forced casting back).
                groupI = Convert.ToByte((groupI + 1) % fishGroups.Count);
            }

            return fishGroups.Values.Aggregate(BigInteger.Add) + buffer7 + buffer8;
        }
    }
}