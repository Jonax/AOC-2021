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
    public class Day03Tests : TestBase
    {
        [Fact]
        internal async Task Part1_Example()
        {
            IEnumerable<string> binaries = await ReadExampleFile<string>("Day03_Example.txt").ToListAsync();

            Assert.Equal(198, Day03.PartA(binaries));
        }


        [Fact]
        internal async Task Part1_Answer()
        {
            IEnumerable<string> binaries = await ReadExampleFile<string>("Day03_Answer.txt").ToListAsync();

            Assert.Equal(2003336, Day03.PartA(binaries));
        }

        [Fact]
        internal async Task Part2_Example()
        {
            IEnumerable<string> binaries = await ReadExampleFile<string>("Day03_Example.txt").ToListAsync();

            Assert.Equal(230, Day03.PartB(binaries));
        }


        [Fact]
        internal async Task Part2_Answer()
        {
            IEnumerable<string> binaries = await ReadExampleFile<string>("Day03_Answer.txt").ToListAsync();

            Assert.Equal(1877139, Day03.PartB(binaries));
        }
    }
}
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.