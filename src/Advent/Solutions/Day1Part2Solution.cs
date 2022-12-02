// Ishan Pranav's REBUS: Day1Part2Solution.cs
// Copyright (c) 2021-2022 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

namespace Advent.Solutions
{
    internal sealed class Day1Part2Solution : Solution
    {
        private int _first;
        private int _second;
        private int _third;
        private int _sum;

        protected override int Day
        {
            get
            {
                return 1;
            }
        }

        protected override int Result
        {
            get
            {
                return _first + _second + _third;
            }
        }

        protected override void ReadLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                if (_sum > _first)
                {
                    _third = _second;
                    _second = _first;
                    _first = _sum;
                }
                else if (_sum > _second)
                {
                    _third = _second;
                    _second = _sum;
                }
                else if (_sum > _third)
                {
                    _third = _sum;
                }

                _sum = 0;
            }
            else
            {
                _sum += int.Parse(line);
            }
        }
    }
}
