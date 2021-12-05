using Advent_of_Code_2021;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
namespace AOC_Tests
{
    public class Day04Tests : TestBase
    {
        [Fact]
        internal async Task Part1_Example()
        {
            var data = await ReadExampleFile<string>("Day04_Example.txt", skipLineSplitting: true).SingleAsync();

            Assert.Equal(4512, Day04.Execute(data.Split("\n\n")));
        }

        [Fact]
        internal async Task Part1_Answer()
        {
            var data = await ReadExampleFile<string>("Day04_Answer.txt", skipLineSplitting: true).SingleAsync();

            Assert.Equal(33348, Day04.Execute(data.Split("\n\n")));
        }

        [Fact]
        internal async Task Part2_Example()
        {
            var data = await ReadExampleFile<string>("Day04_Example.txt", skipLineSplitting: true).SingleAsync();

            Assert.Equal(1924, Day04.Execute(data.Split("\n\n"), intentionallyLose: true));
        }

        [Fact]
        internal async Task Part2_Answer()
        {
            var data = await ReadExampleFile<string>("Day04_Answer.txt", skipLineSplitting: true).SingleAsync();

            Assert.Equal(8112, Day04.Execute(data.Split("\n\n"), intentionallyLose: true));
        }
    }
}
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.