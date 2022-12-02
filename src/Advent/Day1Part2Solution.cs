// Ishan Pranav's REBUS: Day1Part2Solution.cs
// Copyright (c) 2021-2022 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading.Tasks;
using Advent.StreamProviders;

namespace Advent
{
    internal static class Day1Part2Solution
    {
        public static async Task<int> SolveAsync(IStreamProvider provider)
        {
            int first = 0;
            int second = 0;
            int third = 0;

            using (TextReader reader = await provider.OpenTextAsync(1))
            {
                string? line;
                int sum = 0;

                while ((line = await reader.ReadLineAsync()) is not null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        if (sum > first)
                        {
                            third = second;
                            second = first;
                            first = sum;
                        }
                        else if (sum > second)
                        {
                            third = second;
                            second = sum;
                        }
                        else if (sum > third)
                        {
                            third = sum;
                        }

                        sum = 0;
                    }
                    else
                    {
                        sum += int.Parse(line);
                    }
                }
            }

            return first + second + third;
        }
    }
}
