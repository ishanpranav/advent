// Ishan Pranav's REBUS: RucksackReorganizationSolution.cs
// Copyright (c) 2022 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;

namespace Advent.Solutions;

internal sealed class RucksackReorganizationSolution : ISolution
{
    private string? _first;
    private string? _second;

    public int Part1 { get; private set; }
    public int Part2 { get; private set; }

    public async Task SolveAsync(TextReader reader)
    {
        do
        {
            string? line = await reader.ReadLineAsync();

            if (line is null)
            {
                return;
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

            if (_first is null)
            {
                _first = line;
            }
            else if (_second is null)
            {
                _second = line;
            }
            else
            {
                int index = 0;
                char item = line[0];

                do
                {
                    if (_first.Contains(item) && _second.Contains(item))
                    {
                        break;
                    }

                    index++;
                    item = line[index];
                }
                while (index < length);

                Part2 += getPriority(item);
                _first = null;
                _second = null;
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
                            Part1 += getPriority(item);

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
