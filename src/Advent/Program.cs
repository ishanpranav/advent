// Ishan Pranav's REBUS: Program.cs
// Copyright (c) 2021-2022 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Advent.Solutions;

namespace Advent
{
    internal static class Program
    {
        private static async Task Main()
        {
            foreach (Type type in typeof(Program).Assembly.GetExportedTypes())
            {
                if (!type.IsAbstract &&
                    type.IsAssignableTo(typeof(Solution)) &&
                    Activator.CreateInstance(type) is Solution solution)
                {
                    await solution.SolveAsync();
                    await Console.Out.WriteLineAsync($"Day {solution.Day}, Part {solution.Part}: {solution.Result}");
                }
            }
        }
    }
}
