// Ishan Pranav's REBUS: Day1Part1Solution.cs
// Copyright (c) 2021-2022 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Advent.StreamProviders;

namespace Advent
{
    internal static class Day1Part1Solution
    {
        public static async Task<int> SolveAsync(IStreamProvider provider)
        {
            int result = 0;

            using (TextReader reader = await provider.OpenTextAsync(1))
            {
                string? line;
                int sum = 0;

                while ((line = await reader.ReadLineAsync()) is not null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        result = Math.Max(result, sum);
                        sum = 0;
                    }
                    else
                    {
                        sum += int.Parse(line);
                    }
                }
            }

            return result;
        }
    }
}
