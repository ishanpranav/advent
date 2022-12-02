// Ishan Pranav's REBUS: FileStreamProvider.cs
// Copyright (c) 2021-2022 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading.Tasks;

namespace Advent.StreamProviders
{
    internal sealed class FileStreamProvider : IStreamProvider
    {
        public Task<StreamReader> OpenTextAsync(int day)
        {
            return Task.FromResult(File.OpenText(Path.ChangeExtension(Path.Combine($"Day{day}"), extension: "txt")));
        }
    }
}
