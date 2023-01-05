// Copyright (c) 2022 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;

namespace Advent.Solvers;

internal sealed class RucksackReorganizationSolver : ISolver
{
    public async Task<Solution> SolveAsync(TextReader reader)
    {
        int firstPriority = 0;
        int secondPriority = 0;
        string? first = null;
        string? second = null;

        do
        {
            string? line = await reader.ReadLineAsync();

            if (line is null)
            {
                return new Solution(firstPriority, secondPriority);
            }

            int length = line.Length;

            if (length < 2)
            {
                throw new FormatException();
            }

            int quotient = Math.DivRem(length, 2, out int remainder);

            if (remainder is 1)
            {
                throw new FormatException();
            }

            part1();

            if (first is null)
            {
                first = line;
            }
            else if (second is null)
            {
                second = line;
            }
            else
            {
                int index = 0;
                char item = line[0];

                do
                {
                    if (first.Contains(item) && second.Contains(item))
                    {
                        break;
                    }

                    index++;
                    item = line[index];
                }
                while (index < length);

                secondPriority += getPriority(item);
                first = null;
                second = null;
            }

            void part1()
            {
                for (int left = 0; left < quotient; left++)
                {
                    char item = line[left];

                    for (int right = length - 1; right >= quotient; right--)
                    {
                        if (line[right] == item)
                        {
                            firstPriority += getPriority(item);

                            return;
                        }
                    }
                }
            }

            static int getPriority(char item)
            {
                return item switch
                {
                    >= 'A' and <= 'Z' => item - 'A' + 27,
                    >= 'a' and <= 'z' => item - 'a' + 1,
                    _ => throw new FormatException()
                };
            }
        }
        while (true);
    }
}
