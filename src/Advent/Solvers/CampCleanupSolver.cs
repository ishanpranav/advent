// Copyright (c) 2022 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Advent.Solvers;

internal sealed class CampCleanupSolver : ISolver
{
    public Task<Solution> SolveAsync(TextReader reader)
    {
        int containments = 0;
        int overlaps = 0;
        int index = 0;
        int[] bounds = new int[4];
        StringBuilder builder = new StringBuilder();

        do
        {
            int read = reader.Read();

            if (read is -1)
            {
                return Task.FromResult(new Solution(containments, overlaps));
            }

            char symbol = (char)read;

            if (char.IsDigit(symbol))
            {
                builder.Append(read);
            }
            else if (builder.Length > 0)
            {
                bounds[index] = int.Parse(builder.ToString());
                index++;

                builder.Clear();
            }

            if (index is 4)
            {
                index = 0;

                int start1 = bounds[0];
                int start2 = bounds[2];
                int end1 = bounds[1];
                int end2 = bounds[3];

                if (start1 <= end2 && end1 >= start2)
                {
                    overlaps++;

                    if ((start1 <= start2 && end2 <= end1) || (start1 >= start2 && end2 >= end1))
                    {
                        containments++;
                    }
                }
            }
        }
        while (true);
    }
}
