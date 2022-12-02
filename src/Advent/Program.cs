using System;
using System.Threading.Tasks;
using Advent.Solutions;

namespace Advent
{
    internal static class Program
    {
        private static async Task Main()
        {
            int day1Part1 = await new Day1Part1Solution().SolveAsync();
            int day1Part2 = await new Day1Part2Solution().SolveAsync();
            int day2Part1 = await new Day2Part1Solution().SolveAsync();
            int day2Part2 = await new Day2Part2Solution().SolveAsync();

            await Console.Out.WriteLineAsync($"Day 1, Part 1: {day1Part1}");
            await Console.Out.WriteLineAsync($"Day 1, Part 2: {day1Part2}");
            await Console.Out.WriteLineAsync($"Day 2, Part 1: {day2Part1}");
            await Console.Out.WriteLineAsync($"Day 2, Part 2: {day2Part2}");
        }
    }
}
