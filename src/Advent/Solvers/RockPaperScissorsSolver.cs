// Copyright (c) 2022 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;

namespace Advent.Solvers;

internal sealed class RockPaperScissorsSolver : ISolver
{
    public async Task<Solution> SolveAsync(TextReader reader)
    {
        int first = 0;
        int second = 0;

        do
        {
            string? line = await reader.ReadLineAsync();

            switch (line)
            {
                case null:
                    return new Solution(first, second);

                case "A X":
                    first += 4;
                    second += 3;
                    break;

                case "A Y":
                    first += 8;
                    second += 4;
                    break;

                case "A Z":
                    first += 3;
                    second += 8;
                    break;

                case "B X":
                    first += 1;
                    second += 1;
                    break;

                case "B Y":
                    first += 5;
                    second += 5;
                    break;

                case "B Z":
                    first += 9;
                    second += 9;
                    break;

                case "C X":
                    first += 7;
                    second += 2;
                    break;

                case "C Y":
                    first += 2;
                    second += 6;
                    break;

                case "C Z":
                    first += 6;
                    second += 7;
                    break;

                default:
                    throw new FormatException();
            }
        }
        while (true);
    }
}
