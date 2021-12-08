using Advent_of_Code_2021;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
namespace AOC_Tests
{
    public class Day06Tests : TestBase
    {
        [Theory]
        [InlineData(18, 26)]
        [InlineData(80, 5934)]
        internal async Task Part1_Example(int numIterations, int expected)
        {
            string data = await ReadExampleFile<string>("Day06_Example.txt", skipLineSplitting: true)
                                .SingleAsync();

            Assert.Equal(expected, Day06.Execute(numIterations, data.Split(",")
                                                                    .Select(x => byte.Parse(x))));
        }

        [Fact]
        internal async Task Part1_Answer()
        {
            string data = await ReadExampleFile<string>("Day06_Answer.txt", skipLineSplitting: true)
                                .SingleAsync();

            Assert.Equal(345387, Day06.Execute(80, data.Split(",")
                                      .Select(x => byte.Parse(x))));
        }

        [Fact]
        internal async Task Part2_Example()
        {
            string data = await ReadExampleFile<string>("Day06_Example.txt", skipLineSplitting: true)
                                .SingleAsync();

            Assert.Equal(26984457539, Day06.Execute(256, data.Split(",")
                                                             .Select(x => byte.Parse(x))));
        }

        [Fact]
        internal async Task Part2_Answer()
        {
            string data = await ReadExampleFile<string>("Day06_Answer.txt", skipLineSplitting: true)
                                .SingleAsync();

            Assert.Equal(1574445493136, Day06.Execute(256, data.Split(",")
                                                               .Select(x => byte.Parse(x))));
        }
    }
}
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.