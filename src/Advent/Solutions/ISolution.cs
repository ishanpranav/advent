// Ishan Pranav's REBUS: ISolution.cs
// Copyright (c) 2022 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

namespace Advent.Solutions
{
    internal interface ISolution
    {
        int Part1 { get; }
        int Part2 { get; }

        void ReadLine(string line);
    }
}
