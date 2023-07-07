using System.Threading.Tasks;

namespace Twileloop.SessionGuard.Persistance
{
    public interface IPersistance<T>
    {
        Task<T> ReadFileAsync(string filePath);
        Task WriteFileAsync(T state, string filePath);
    }
}
