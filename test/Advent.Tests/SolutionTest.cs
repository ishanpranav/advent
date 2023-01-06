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
        return TestAsync<CalorieCountingSolver>(year: 2022, day: 1, new Solution(first: 70720, second: 207148));
    }

    [TestMethod("2022 Day 2: Rock-Paper-Scissors")]
    public Task Test2022Day2()
    {
        return TestAsync<RockPaperScissorsSolver>(year: 2022, day: 2, new Solution(first: 14827, second: 13889));
    }

    [TestMethod("2022 Day 3: Rucksack Reorganization")]
    public Task Test2022Day3()
    {
        return TestAsync<RucksackReorganizationSolver>(year: 2022, day: 3, new Solution(first: 8233, second: 2821));
    }

    [TestMethod("2022 Day 4: Camp Cleanup")]
    public Task Test2022Day4()
    {
        return TestAsync<CampCleanupSolver>(year: 2022, day: 4, new Solution(first: 569, second: 936));
    }

    [TestMethod("2022 Day 5: Supply Stacks")]
    public Task Test2022Day5()
    {
        return TestAsync<SupplyStacksSolver>(year: 2022, day: 5, new Solution(first: "TPGVQPFDH", second: "DMRDFRHHH"));
    }

    [TestMethod("2022 Day 6: Tuning Trouble")]
    public Task Test2022Day6()
    {
        return TestAsync<TuningTroubleSolver>(year: 2022, day: 6, new Solution(first: 1544, second: 2145));
    }

    [TestMethod("2022 Day 7: No Space Left On Device")]
    public Task Test2022Day7()
    {
        return TestAsync<NoSpaceLeftOnDeviceSolver>(year: 2022, day: 7, new Solution(first: 1243729, second: 0));
    }

    private static async Task TestAsync<TSolver>(int year, int day, Solution expectedSolution) where TSolver : ISolver, new()
    {
        TSolver solver = new TSolver();
        Stream? stream = typeof(SolutionTest).Assembly.GetManifestResourceStream($"Advent.Tests.resources.{year}_day_{day}_input.txt");

        Assert.IsNotNull(stream);

        using StreamReader reader = new StreamReader(stream);

        Assert.AreEqual(expectedSolution, await solver.SolveAsync(reader));
    }
}
