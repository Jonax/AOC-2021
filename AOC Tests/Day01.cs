using Advent_of_Code_2021;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
namespace AOC_Tests
{
    public class Day01Tests : TestBase
    {
        [Fact]
        internal async Task Part1_Example()
        {
            IEnumerable<int> digits = await ReadExampleFile<int>("Day01_Example.txt").ToListAsync();

            Assert.Equal(7, Day01.Execute(digits, 1));
        }


        [Fact]
        internal async Task Part1_Answer()
        {
            IEnumerable<int> digits = await ReadExampleFile<int>("Day01_Answer.txt").ToListAsync();

            Assert.Equal(1692, Day01.Execute(digits, 1));
        }

        [Fact]
        internal async Task Part2_Example()
        {
            IEnumerable<int> digits = await ReadExampleFile<int>("Day01_Example.txt").ToListAsync();

            Assert.Equal(5, Day01.Execute(digits, 3));
        }


        [Fact]
        internal async Task Part2_Answer()
        {
            IEnumerable<int> digits = await ReadExampleFile<int>("Day01_Answer.txt").ToListAsync();

            Assert.Equal(1724, Day01.Execute(digits, 3));
        }
    }
}
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.