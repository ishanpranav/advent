// Ishan Pranav's REBUS: RucksackReorganizationSolution.cs
// Copyright (c) 2022 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Advent.Solutions
{
    internal sealed class RucksackReorganizationSolution : ISolution
    {
        private string? _first;
        private string? _second;

        public int Part1 { get; private set; }
        public int Part2 { get; private set; }

        public void ReadLine(string line)
        {
            int length = line.Length;

            if (length < 2)
            {
                throw new FormatException();
            }

            int quotient = Math.DivRem(length, 2, out int remainder);

            if (remainder == 1)
            {
                throw new FormatException();
            }

            readLinePart1();
            readLinePart2();

            void readLinePart1()
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

            void readLinePart2()
            {
                if (_first is null)
                {
                    _first = line;

                    return;
                }

                if (_second is null)
                {
                    _second = line;

                    return;
                }

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
    }
}
