using Advent_of_Code_2021;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
namespace AOC_Tests
{
    public class Day08Tests : TestBase, IAsyncLifetime
    {
        private static IList<(string patterns, string value)> Examples;

        public async Task InitializeAsync()
        {
            Examples = await ReadExampleFile<string>("Day08_Example.txt")
                                 .Select(line =>
                                 {
                                     string[] segments = line.Split(" | ");

                                     return (segments[0], segments[1]);
                                 })
                                 .ToListAsync();
        }

        public async Task DisposeAsync() => await Task.Yield();

        [Fact]
        internal void Part1_Example()
        {
            Assert.Equal(26, Examples.SelectMany(ex => Day08.Execute(ex.patterns, ex.value).ToString())
                                      .Count(i => i switch
                                      {
                                          '1' or '4' or '7' or '8' => true,
                                          _ => false,
                                      }));
        }

        [Fact]
        internal async Task Part1_Answer()
        {
            IEnumerable<(string patterns, string digits)> displays = await ReadExampleFile<string>("Day08_Answer.txt")
                                                                           .Select(line =>
                                                                           {
                                                                               string[] segments = line.Split(" | ");

                                                                               return (segments[0], segments[1]);
                                                                           })
                                                                           .ToListAsync();

            Assert.Equal(303, displays.SelectMany(dp => Day08.Execute(dp.patterns, dp.digits).ToString())
                                      .Count(i => i switch
                                      {
                                          '1' or '4' or '7' or '8' => true,
                                          _ => false,
                                      }));
        }

        [Fact]
        internal void Part2_SubExamplePattern()
        {
            string samplePattern = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab";

            Dictionary<HashSet<char>, byte> decoded = Day08.DecodePatterns(samplePattern.Split(" ")
                                                           .Select(x => x.ToHashSet())
                                                           .ToList());

            Dictionary<HashSet<char>, byte> target = new Dictionary<string, byte>() {
                { "acedgfb", 8 },
                { "cdfbe", 5 },
                { "gcdfa", 2 },
                { "fbcad", 3 },
                { "dab", 7 },
                { "cefabd", 9 },
                { "cdfgeb", 6 },
                { "eafb", 4 },
                { "cagedb", 0 },
                { "ab", 1 }
            }.ToDictionary(kv => kv.Key.ToHashSet(),
                           kv => kv.Value);

            Assert.All(target, tkv => Assert.Equal(tkv.Value, decoded[tkv.Key]));
        }

        [Theory]
        [InlineData(0, 8394)]
        [InlineData(1, 9781)]
        [InlineData(2, 1197)]
        [InlineData(3, 9361)]
        [InlineData(4, 4873)]
        [InlineData(5, 8418)]
        [InlineData(6, 4548)]
        [InlineData(7, 1625)]
        [InlineData(8, 8717)]
        [InlineData(9, 4315)]
        internal void Part2_SubExampleDigits(int i, int expected)
        {
            Assert.Equal(expected, Day08.Execute(Examples[i].patterns, Examples[i].value));
        }

        
        [Fact]
        internal void Part2_Example()
        {
            Assert.Equal(61229, Examples.Sum(ex => Day08.Execute(ex.patterns, ex.value)));
        }

        [Fact]
        internal async Task Part2_Answer()
        {
            IEnumerable<(string patterns, string digits)> displays = await ReadExampleFile<string>("Day08_Answer.txt")
                                                                           .Select(line =>
                                                                           {
                                                                               string[] segments = line.Split(" | ");

                                                                               return (segments[0], segments[1]);
                                                                           })
                                                                           .ToListAsync();

            Assert.Equal(961734, displays.Sum(dp => Day08.Execute(dp.patterns, dp.digits)));
        }
    }
}
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.