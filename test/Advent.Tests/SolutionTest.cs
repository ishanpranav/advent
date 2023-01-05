// Ishan Pranav's REBUS: SolutionTest.cs
// Copyright (c) 2022 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading.Tasks;
using Advent.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent.Tests;

[TestClass]
public sealed class SolutionTest
{
    private static async Task TestAsync<TSolution>(int year, int day, int part1, int part2) where TSolution : ISolution, new()
    {
        TSolution solution = new TSolution();
        Stream? stream = typeof(SolutionTest).Assembly.GetManifestResourceStream($"Advent.Tests.resources.{year}_day_{day}_input.txt");

        Assert.IsNotNull(stream);

        using StreamReader reader = new StreamReader(stream);
        
        await solution.SolveAsync(reader);

        Assert.AreEqual(part1, solution.Part1);
        Assert.AreEqual(part2, solution.Part2);
    }

    [TestMethod]
    public Task Test2022Day1()
    {
        return TestAsync<CalorieCountingSolution>(year: 2022, day: 1, part1: 70720, part2: 207148);
    }

    [TestMethod]
    public Task Test2022Day2()
    {
        return TestAsync<RockPaperScissorsSolution>(year: 2022, day: 2, part1: 14827, part2: 13889);
    }

    [TestMethod]
    public Task Test2022Day3()
    {
        return TestAsync<RucksackReorganizationSolution>(year: 2022, day: 3, part1: 8233, part2: 2821);
    }

    [TestMethod]
    public Task Test2022Day4()
    {
        return TestAsync<CampCleanupSolution>(year: 2022, day: 4, part1: 569, part2: 936);
    }
}
