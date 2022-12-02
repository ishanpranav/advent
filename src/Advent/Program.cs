using System;
using System.Threading.Tasks;
using Advent.StreamProviders;

namespace Advent
{
    internal static class Program
    {
        private static async Task Main()
        {
            IStreamProvider provider = new FileStreamProvider();

            int day1Part1 = await Day1Part1Solution.SolveAsync(provider);
            int day1Part2 = await Day1Part2Solution.SolveAsync(provider);

            await Console.Out.WriteLineAsync($"Day 1, Part 1: {day1Part1}");
            await Console.Out.WriteLineAsync($"Day 1, Part 2: {day1Part2}");
        }
    }
}
