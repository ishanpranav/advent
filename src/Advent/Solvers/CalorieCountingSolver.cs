// Copyright (c) 2022 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading.Tasks;

namespace Advent.Solvers;

internal sealed class CalorieCountingSolver : ISolver
{
    public async Task<Solution> SolveAsync(TextReader reader)
    {
        int sum = 0;
        int max = 0;
        int first = 0;
        int second = 0;
        int third = 0;

        do
        {
            string? line = await reader.ReadLineAsync();

            if (line is null)
            {
                return new Solution(max, first + second + third);
            }

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

                if (sum > max)
                {
                    max = sum;
                }

                sum = 0;
            }
            else
            {
                sum += int.Parse(line);
            }
        }
        while (true);
    }
}
