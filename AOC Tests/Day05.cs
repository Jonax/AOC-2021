using Advent_of_Code_2021;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
namespace AOC_Tests
{
    public class Day05Tests : TestBase
    {
        private readonly static Regex ParseRegex = new (@"(?<startX>[0-9]+),(?<startY>[0-9]+) -> (?<endX>[0-9]+),(?<endY>[0-9]+)");

        [Fact]
        internal async Task Part1_Example()
        {
            var lines = await ReadExampleFile<string>("Day05_Example.txt")
                               .Select(line =>
                               {
                                    List<int> components = ParseRegex.Match(line).Groups
                                                                     .Cast<Group>()
                                                                     .Skip(1)           // Skips the "whole capture" group
                                                                     .Select(group => Convert.ToInt32(group.Value))
                                                                     .ToList();

                                   return (components[0], components[1], components[2], components[3]);
                               })
                               .ToListAsync();

            Assert.Equal(5, Day05.Execute(lines));
        }

        [Fact]
        internal async Task Part1_Answer()
        {
            var lines = await ReadExampleFile<string>("Day05_Answer.txt")
                               .Select(line =>
                               {
                                   List<int> components = ParseRegex.Match(line).Groups
                                                                    .Cast<Group>()
                                                                    .Skip(1)           // Skips the "whole capture" group
                                                                    .Select(group => Convert.ToInt32(group.Value))
                                                                    .ToList();

                                   return (components[0], components[1], components[2], components[3]);
                               })
                               .ToListAsync();

            Assert.Equal(5442, Day05.Execute(lines));
        }

        [Fact]
        internal async Task Part2_Example()
        {
            var lines = await ReadExampleFile<string>("Day05_Example.txt")
                               .Select(line =>
                               {
                                   List<int> components = ParseRegex.Match(line).Groups
                                                                    .Cast<Group>()
                                                                    .Skip(1)           // Skips the "whole capture" group
                                                                    .Select(group => Convert.ToInt32(group.Value))
                                                                    .ToList();

                                   return (components[0], components[1], components[2], components[3]);
                               })
                               .ToListAsync();

            Assert.Equal(12, Day05.Execute(lines, includeDiagonals: true));
        }

        [Fact]
        internal async Task Part2_Answer()
        {
            var lines = await ReadExampleFile<string>("Day05_Answer.txt")
                               .Select(line =>
                               {
                                   List<int> components = ParseRegex.Match(line).Groups
                                                                    .Cast<Group>()
                                                                    .Skip(1)           // Skips the "whole capture" group
                                                                    .Select(group => Convert.ToInt32(group.Value))
                                                                    .ToList();

                                   return (components[0], components[1], components[2], components[3]);
                               })
                               .ToListAsync();

            Assert.Equal(19571, Day05.Execute(lines, includeDiagonals: true));
        }
    }
}
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.