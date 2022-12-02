using System.IO;
using System.Threading.Tasks;

namespace Advent.StreamProviders
{
    internal interface IStreamProvider
    {
        Task<StreamReader> OpenTextAsync(int day);
    }
}
