// Copyright (c) 2022 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading.Tasks;

namespace Advent.Solvers;

internal interface ISolver
{
    Task<Solution> SolveAsync(TextReader reader);
}
