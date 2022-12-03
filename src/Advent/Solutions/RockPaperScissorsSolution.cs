// Ishan Pranav's REBUS: RockPaperScissorsSolution.cs
// Copyright (c) 2022 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Advent.Solutions
{
    internal sealed class RockPaperScissorsSolution : ISolution
    {
        public int Part1 { get; private set; }
        public int Part2 { get; private set; }

        public void ReadLine(string line)
        {
            switch (line)
            {
                case "A X":
                    Part1 += 4;
                    Part2 += 3;
                    break;

                case "A Y":
                    Part1 += 8;
                    Part2 += 4;
                    break;

                case "A Z":
                    Part1 += 3;
                    Part2 += 8;
                    break;

                case "B X":
                    Part1 += 1;
                    Part2 += 1;
                    break;

                case "B Y":
                    Part1 += 5;
                    Part2 += 5;
                    break;

                case "B Z":
                    Part1 += 9;
                    Part2 += 9;
                    break;

                case "C X":
                    Part1 += 7;
                    Part2 += 2;
                    break;

                case "C Y":
                    Part1 += 2;
                    Part2 += 6;
                    break;

                case "C Z":
                    Part1 += 6;
                    Part2 += 7;
                    break;

                default:
                    throw new FormatException();
            }
        }
    }
}
