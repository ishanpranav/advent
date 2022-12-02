// Ishan Pranav's REBUS: Solution.cs
// Copyright (c) 2021-2022 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Resources;
using System.Threading.Tasks;

namespace Advent.Solutions
{
    public abstract class Solution
    {
        public abstract int Day { get; }
        public abstract int Part { get; }
        public abstract int Result { get; }

        protected abstract void ReadLine(string line);

        public async Task SolveAsync()
        {
            Stream? stream = typeof(Solution).Assembly.GetManifestResourceStream($"Advent.resources.Day{Day}.txt");

            if (stream is null)
            {
                throw new MissingManifestResourceException();
            }

            using (StreamReader reader = new StreamReader(stream))
            {
                string? line;

                while ((line = await reader.ReadLineAsync()) is not null)
                {
                    ReadLine(line);
                }
            }
        }
    }
}
