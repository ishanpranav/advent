// Ishan Pranav's REBUS: Day1Part1Solution.cs
// Copyright (c) 2021-2022 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Advent.Solutions
{
    public class Day1Part1Solution : Solution
    {
        private int _sum;
        private int _result;

        public override int Day => 1;
        public override int Part => 1;
        public override int Result => _result;

        protected override void ReadLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                _result = Math.Max(_result, _sum);
                _sum = 0;
            }
            else
            {
                _sum += int.Parse(line);
            }
        }
    }
}
