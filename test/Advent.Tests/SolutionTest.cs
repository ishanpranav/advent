// Copyright (c) 2022 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading.Tasks;
using Advent.Solvers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent.Tests;

[TestClass]
public sealed class SolutionTest
{
    [TestMethod("2022 Day 1: Calorie Counting")]
    public Task Test2022Day1()
    {
        return TestAsync<CalorieCountingSolver>(year: 2022, day: 1, part1: 70720, part2: 207148);
    }

    [TestMethod("2022 Day 2: Rock-Paper-Scissors")]
    public Task Test2022Day2()
    {
        return TestAsync<RockPaperScissorsSolver>(year: 2022, day: 2, part1: 14827, part2: 13889);
    }

    [TestMethod("2022 Day 3: Rucksack Reorganization")]
    public Task Test2022Day3()
    {
        return TestAsync<RucksackReorganizationSolver>(year: 2022, day: 3, part1: 8233, part2: 2821);
    }

    [TestMethod("2022 Day 4: Camp Cleanup")]
    public Task Test2022Day4()
    {
        return TestAsync<CampCleanupSolver>(year: 2022, day: 4, part1: 569, part2: 936);
    }

    [TestMethod("2022 Day 5: Supply Stacks")]
    public Task Test2022Day5()
    {
        return TestAsync<SupplyStacksSolver>(year: 2022, day: 5, part1: "TPGVQPFDH", part2: "DMRDFRHHH");
    }

    private static async Task TestAsync<TSolver>(int year, int day, object part1, object part2) where TSolver : ISolver, new()
    {
        TSolver solver = new TSolver();
        Stream? stream = typeof(SolutionTest).Assembly.GetManifestResourceStream($"Advent.Tests.resources.{year}_day_{day}_input.txt");

        Assert.IsNotNull(stream);

        using StreamReader reader = new StreamReader(stream);

        Solution solution = await solver.SolveAsync(reader);

        Assert.AreEqual(part1, solution.First);
        Assert.AreEqual(part2, solution.Second);
    }
}
