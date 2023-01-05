// Copyright (c) 2022 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent.Solvers;

internal sealed class SupplyStacksSolver : ISolver
{
    private const RegexOptions Options = RegexOptions.Compiled | RegexOptions.CultureInvariant;

    private static readonly Regex s_stackRegex = new Regex(@"\[([A-Z])\]\s?", Options);
    private static readonly Regex s_moveRegex = new Regex(@"move ([0-9]+) from ([0-9]+) to ([0-9]+)", Options);

    public async Task<Solution> SolveAsync(TextReader reader)
    {
        string? line = await reader.ReadLineAsync();

        if (line is null)
        {
            throw new FormatException();
        }

        const int crateLength = 4;

        int count = (line.Length + 1) / crateLength;
        Deque<char>[] firstStacks = new Deque<char>[count];
        Deque<char>[] secondStacks = new Deque<char>[count];
        Stack<char> craneStack = new Stack<char>();

        for (int i = 0; i < count; i++)
        {
            firstStacks[i] = new Deque<char>();
            secondStacks[i] = new Deque<char>();
        }

        while (!string.IsNullOrWhiteSpace(line))
        {
            foreach (Match match in s_stackRegex.Matches(line))
            {
                int index = match.Index / crateLength;
                char crate = match.Groups[1].Value[0];

                firstStacks[index].AddLast(crate);
                secondStacks[index].AddLast(crate);
            }

            line = await reader.ReadLineAsync();
        }

        do
        {
            line = await reader.ReadLineAsync();

            if (string.IsNullOrWhiteSpace(line))
            {
                break;
            }

            Match match = s_moveRegex.Match(line);
            int moves = int.Parse(match.Groups[1].Value);
            int source = int.Parse(match.Groups[2].Value) - 1;
            int target = int.Parse(match.Groups[3].Value) - 1;
            Deque<char> secondStack = secondStacks[target];

            for (int i = 0; i < moves; i++)
            {
                firstStacks[target].AddFirst(firstStacks[source].RemoveFirst());
                craneStack.Push(secondStacks[source].RemoveFirst());
            }

            for (int i = 0; i < moves; i++)
            {
                secondStack.AddFirst(craneStack.Pop());
            }
        }
        while (true);

        char[] firstTops = new char[count];
        char[] secondTops = new char[count];

        for (int i = 0; i < count; i++)
        {
            firstTops[i] = firstStacks[i].First;
            secondTops[i] = secondStacks[i].First;
        }

        return new Solution(new string(firstTops), new string(secondTops));
    }
}
