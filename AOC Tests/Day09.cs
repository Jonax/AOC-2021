using Advent_of_Code_2021;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
namespace AOC_Tests
{
    public class Day09Tests : TestBase
    {
        [Fact]
        internal async Task Part1_Example()
        {
            IEnumerable<IEnumerable<byte>> heights = await ReadExampleFile<string>("Day09_Example.txt")
                                                           .Select(line => line.ToCharArray()
                                                                               .Select(c => byte.Parse(c.ToString()))
                                                                               .ToList())
                                                           .ToListAsync();

            Assert.Equal(15, Day09.Execute(heights));
        }

        [Fact]
        internal async Task Part1_Answer()
        {
            IEnumerable<IEnumerable<byte>> heights = await ReadExampleFile<string>("Day09_Answer.txt")
                                                           .Select(line => line.ToCharArray()
                                                                               .Select(c => byte.Parse(c.ToString()))
                                                                               .ToList())
                                                           .ToListAsync();

            Assert.Equal(468, Day09.Execute(heights));
        }

        
        [Fact]
        internal async Task Part2_Example()
        {
            IEnumerable<IEnumerable<byte>> heights = await ReadExampleFile<string>("Day09_Example.txt")
                                                           .Select(line => line.ToCharArray()
                                                                               .Select(c => byte.Parse(c.ToString()))
                                                                               .ToList())
                                                           .ToListAsync();

            Assert.Equal(1134, Day09.Execute(heights, floodFill: true));
        }

        [Fact]
        internal async Task Part2_Answer()
        {
            IEnumerable<IEnumerable<byte>> heights = await ReadExampleFile<string>("Day09_Answer.txt")
                                                           .Select(line => line.ToCharArray()
                                                                               .Select(c => byte.Parse(c.ToString()))
                                                                               .ToList())
                                                           .ToListAsync();

            Assert.Equal(1280496, Day09.Execute(heights, floodFill: true));
        }
    }
}
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.