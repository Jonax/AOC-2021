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
    public class Day02Tests : TestBase
    {
        [Fact]
        internal async Task Part1_Example()
        {
            IEnumerable<(string, int)> directions = await ReadExampleFile<string>("Day02_Example.txt")
                                                          .Select(line =>
                                                          {
                                                              string[] components = line.Split(' ');

                                                              return (components[0], Convert.ToInt32(components[1]));
                                                          })
                                                          .ToListAsync();

            Assert.Equal(150, Day02.Execute(directions));
        }


        [Fact]
        internal async Task Part1_Answer()
        {
            IEnumerable<(string, int)> directions = await ReadExampleFile<string>("Day02_Answer.txt")
                                                          .Select(line =>
                                                          {
                                                              string[] components = line.Split(' ');

                                                              return (components[0], Convert.ToInt32(components[1]));
                                                          })
                                                          .ToListAsync();

            Assert.Equal(1488669, Day02.Execute(directions));
        }

        [Fact]
        internal async Task Part2_Example()
        {
            IEnumerable<(string, int)> directions = await ReadExampleFile<string>("Day02_Example.txt")
                                                          .Select(line =>
                                                          {
                                                              string[] components = line.Split(' ');

                                                              return (components[0], Convert.ToInt32(components[1]));
                                                          })
                                                          .ToListAsync();

            Assert.Equal(900, Day02.Execute(directions, advanced: true));
        }


        [Fact]
        internal async Task Part2_Answer()
        {
            IEnumerable<(string, int)> directions = await ReadExampleFile<string>("Day02_Answer.txt")
                                                          .Select(line =>
                                                          {
                                                              string[] components = line.Split(' ');

                                                              return (components[0], Convert.ToInt32(components[1]));
                                                          })
                                                          .ToListAsync();

            Assert.Equal(1176514794, Day02.Execute(directions, advanced: true));
        }
    }
}
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.