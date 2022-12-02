// Ishan Pranav's REBUS: Day2Part2Solution.cs
// Copyright (c) 2021-2022 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Advent.Solutions
{
    public class Day2Part2Solution : Solution
    {
        private int _result;

        public override int Day => 2;
        public override int Part => 2;
        public override int Result => _result;
        
        protected override void ReadLine(string line)
        {
            _result += line switch
            {
                "A X" => 3,
                "A Y" => 4,
                "A Z" => 8,
                "B X" => 1,
                "B Y" => 5,
                "B Z" => 9,
                "C X" => 2,
                "C Y" => 6,
                "C Z" => 7,
                _ => throw new FormatException()
            };
        }
    }
}
