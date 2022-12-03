// Ishan Pranav's REBUS: CalorieCountingSolution.cs
// Copyright (c) 2022 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Advent.Solutions
{
    internal sealed class CalorieCountingSolution : ISolution
    {
        private int _sum;
        private int _maxSum;
        private int _first;
        private int _second;
        private int _third;

        public int Part1
        {
            get
            {
                return _maxSum;
            }
        }

        public int Part2
        {
            get
            {
                return _first + _second + _third;
            }
        }

        public void ReadLine(string line)
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

                _maxSum = Math.Max(_maxSum, _sum);
                _sum = 0;
            }
            else
            {
                _sum += int.Parse(line);
            }
        }
    }
}
