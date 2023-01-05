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
        LinkedList<char>[] firstStacks = new LinkedList<char>[count];
        LinkedList<char>[] secondStacks = new LinkedList<char>[count];

        for (int i = 0; i < count; i++)
        {
            firstStacks[i] = new LinkedList<char>();
            secondStacks[i] = new LinkedList<char>();
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

        LinkedListNode<char>? firstTop;
        LinkedListNode<char>? secondTop;
        Stack<char> craneStack = new Stack<char>();

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
            LinkedList<char> firstStack = firstStacks[source];
            LinkedList<char> secondStack = secondStacks[source];

            for (int i = 0; i < moves; i++)
            {
                firstTop = firstStack.First;
                secondTop = secondStack.First;

                if (firstTop is null || secondTop is null)
                {
                    throw new FormatException();
                }

                char firstCrate = firstTop.Value;

                firstStack.RemoveFirst();
                firstStacks[target].AddFirst(firstCrate);

                char secondCrate = secondTop.Value;

                secondStack.RemoveFirst();
                craneStack.Push(secondCrate);
            }

            for (int i = 0; i < moves; i++)
            {
                secondStacks[target].AddFirst(craneStack.Pop());
            }
        }
        while (true);

        char[] firstTops = new char[count];
        char[] secondTops = new char[count];

        for (int i = 0; i < count; i++)
        {
            firstTop = firstStacks[i].First;
            secondTop = secondStacks[i].First;

            if (firstTop is null || secondTop is null)
            {
                throw new FormatException();
            }

            firstTops[i] = firstTop.Value;
            secondTops[i] = secondTop.Value;
        }

        return new Solution(new string(firstTops), new string(secondTops));
    }
}
