using System.Threading.Tasks;
using Twileloop.SessionGuard.Models;

namespace Twileloop.SessionGuard.Persistance
{
    public interface IPersistance<T>
    {
        Task<FileDetails<T>> ReadFileAsync(string filePath);
        Task WriteFileAsync(T state, string filePath);
    }
}
