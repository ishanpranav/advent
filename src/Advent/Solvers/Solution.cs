// Copyright (c) 2022 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Advent.Solvers;

internal class Solution : IEquatable<Solution>
{
    public static readonly Solution None = new Solution(double.NaN, double.NaN);

    public object First { get; }
    public object Second { get; }

    public Solution(object first, object second)
    {
        ArgumentNullException.ThrowIfNull(first);
        ArgumentNullException.ThrowIfNull(second);

        First = first;
        Second = second;
    }

    public bool Equals(Solution? other)
    {
        return other is not null && First.Equals(other.First) && Second.Equals(other.Second);
    }

    public override bool Equals(object? obj)
    {
        return obj is Solution other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(First, Second);
    }

    public override string ToString()
    {
        return $"({First}, {Second})";
    }
}
