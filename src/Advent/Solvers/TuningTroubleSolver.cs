// Copyright (c) 2022 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Advent.Solvers;

internal class TuningTroubleSolver : ISolver
{
    public async Task<Solution> SolveAsync(TextReader reader)
    {
        bool fourFound = false;
        int fourCount = 4;
        string text = await reader.ReadToEndAsync();
        HashSet<int> set = new HashSet<int>(capacity: 14);

        for (int i = 0; i < text.Length; i++)
        {
            set.Clear();

            for (int j = 0; j < 4; j++)
            {
                set.Add(text[i + j]);
            }

            if (set.Count is 4)
            {
                fourFound = true;

                for (int j = 4; j < 14; j++)
                {
                    set.Add(text[i + j]);
                }

                if (set.Count is 14)
                {
                    return new Solution(fourCount, i + 14);
                }
            }
            else if (!fourFound)
            {
                fourCount++;
            }
        }

        return Solution.None;
    }
}
