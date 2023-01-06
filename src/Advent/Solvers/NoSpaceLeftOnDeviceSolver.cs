// Copyright (c) 2022 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Advent.Solvers;

internal sealed class NoSpaceLeftOnDeviceSolver : ISolver
{
    public async Task<Solution> SolveAsync(TextReader reader)
    {
        Stack<string> paths = new Stack<string>();
        Dictionary<string, int> lengths = new Dictionary<string, int>();

        do
        {
            string? line = await reader.ReadLineAsync();

            switch (line)
            {
                case null:
                    int sum = 0;
                    int min = int.MaxValue;
                    int requiredLength =  lengths["/"] - 40000000;

                    foreach (int length in lengths.Values)
                    {
                        if (length <= 100000)
                        {
                            sum += length;
                        }

                        if (length >= requiredLength && length < min)
                        {
                            min = length;
                        }
                    }

                    return new Solution(sum, min);

                case "$ cd /":
                    paths.Clear();
                    paths.Push(item: "/");
                    break;

                case "$ cd ..":
                    paths.Pop();
                    break;

                default:
                    if (line.StartsWith("$ cd "))
                    {
                        StringBuilder pathBuilder = new StringBuilder();

                        foreach (string path in paths)
                        {
                            pathBuilder
                                .Append(path)
                                .Append(value: '/');
                        }

                        pathBuilder.Append(line.AsSpan(start: 5, line.Length - 5));
                        paths.Push(pathBuilder.ToString());
                    }
                    else if (line[0] is not '$' and not 'd')
                    {
                        int length = int.Parse(line.Substring(startIndex: 0, line.IndexOf(value: ' ')));

                        foreach (string path in paths)
                        {
                            lengths[path] = lengths.GetValueOrDefault(path) + length;
                        }
                    }
                    break;
            }
        }
        while (true);
    }
}
