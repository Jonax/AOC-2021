using Advent_of_Code_2021;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
namespace AOC_Tests
{
    public class Day10Tests : TestBase
    {
        [Fact]
        internal async Task Part1_Example()
        {
            IEnumerable<string> lines = await ReadExampleFile<string>("Day10_Example.txt").ToListAsync();

            Assert.Equal(26397, lines.Sum(line => Day10.Execute(line).corruption));
        }
        
        [Fact]
        internal async Task Part1_Answer()
        {
            IEnumerable<string> lines = await ReadExampleFile<string>("Day10_Answer.txt").ToListAsync();

            Assert.Equal(387363, lines.Sum(line => Day10.Execute(line).corruption));
        }

        [Fact]
        internal async Task Part2_Example()
        {
            IEnumerable<string> lines = await ReadExampleFile<string>("Day10_Example.txt").ToListAsync();

            List<ulong> scores = lines.Select(line => Day10.Execute(line).incomplete)
                                      .Where(n => n > 0)
                                      .ToList();

            Assert.Equal(288957UL, scores.OrderBy(n => n)
                                         .ElementAt(scores.Count / 2));
        }

        [Fact]
        internal async Task Part2_Answer()
        {
            IEnumerable<string> lines = await ReadExampleFile<string>("Day10_Answer.txt").ToListAsync();

            List<ulong> scores = lines.Select(line => Day10.Execute(line).incomplete)
                                      .Where(n => n > 0)
                                      .ToList();

            Assert.Equal(4330777059UL, scores.OrderBy(n => n)
                                             .ElementAt(scores.Count / 2));
        }
    }
}
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.