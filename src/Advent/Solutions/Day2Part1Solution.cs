// Ishan Pranav's REBUS: Day2Part1Solution.cs
// Copyright (c) 2021-2022 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Advent.Solutions
{
    internal sealed class Day2Part1Solution : Solution
    {
        private int _result;

        public override int Day
        {
            get
            {
                return 2;
            }
        }

        public override int Result
        {
            get
            {
                return _result;
            }
        }

        public override void ReadLine(string line)
        {
            _result += line switch
            {
                "A X" => 4,
                "A Y" => 8,
                "A Z" => 3,
                "B X" => 1,
                "B Y" => 5,
                "B Z" => 9,
                "C X" => 7,
                "C Y" => 2,
                "C Z" => 6,
                _ => throw new FormatException()
            };
        }
    }
}
