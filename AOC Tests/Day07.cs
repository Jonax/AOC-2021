using Advent_of_Code_2021;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
namespace AOC_Tests
{
    public class Day07Tests : TestBase
    {
        [Theory]
        [InlineData(1, 41)]
        [InlineData(3, 39)]
        [InlineData(10, 71)]
        internal async Task Part1_SubExample(int position, int expectedFuel)
        {
            string data = await ReadExampleFile<string>("Day07_Example.txt", skipLineSplitting: true)
                                .SingleAsync();

            Assert.Equal(expectedFuel, Day07.GetFuelCost(position, data.Split(",")
                                                                       .Select(x => Convert.ToInt32(x))));
        }

        [Fact]
        internal async Task Part1_Example()
        {
            string data = await ReadExampleFile<string>("Day07_Example.txt", skipLineSplitting: true)
                                .SingleAsync();

            Assert.Equal(37, Day07.Execute(data.Split(",")
                                               .Select(x => Convert.ToInt32(x))));
        }

        [Fact]
        internal async Task Part1_Answer()
        {
            string data = await ReadExampleFile<string>("Day07_Answer.txt", skipLineSplitting: true)
                                .SingleAsync();

            Assert.Equal(344735, Day07.Execute(data.Split(",")
                                                   .Select(x => Convert.ToInt32(x))));
        }

        [Theory]
        [InlineData(5, 168)]
        [InlineData(2, 206)]
        internal async Task Part2_SubExample(int position, int expectedFuel)
        {
            string data = await ReadExampleFile<string>("Day07_Example.txt", skipLineSplitting: true)
                                .SingleAsync();

            Assert.Equal(expectedFuel, Day07.GetFuelCost(position, data.Split(",")
                                                                       .Select(x => Convert.ToInt32(x)), 
                                                         crabEngineering: true));
        }

        [Fact]
        internal async Task Part2_Example()
        {
            string data = await ReadExampleFile<string>("Day07_Example.txt", skipLineSplitting: true)
                                .SingleAsync();

            Assert.Equal(168, Day07.Execute(data.Split(",")
                                                .Select(x => Convert.ToInt32(x)), 
                                            crabEngineering: true));
        }

        [Fact]
        internal async Task Part2_Answer()
        {
            string data = await ReadExampleFile<string>("Day07_Answer.txt", skipLineSplitting: true)
                                .SingleAsync();

            Assert.Equal(96798233, Day07.Execute(data.Split(",")
                                                     .Select(x => Convert.ToInt32(x)), 
                                                 crabEngineering: true));
        }
    }
}
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.