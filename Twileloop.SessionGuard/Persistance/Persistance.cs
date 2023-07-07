using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;
using Twileloop.SessionGuard.Exceptions;
using Twileloop.SessionGuard.Helper;

namespace Twileloop.SessionGuard.Persistance
{

    public class Persistance<T> : IPersistance<T>
    {
        public async Task<T> ReadFileAsync(string filePath)
        {
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true))
                {
                    byte[] buffer = new byte[fileStream.Length];
                    await fileStream.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false);
                    var decompressedBytes = DeflateHelper.DecompressData(buffer);
                    var xml = Encoding.UTF8.GetString(decompressedBytes);
                    var state = XmlHelper.Deserialize<T>(xml);
                    return state;
                }
            }
            catch (Exception ex)
            {
                throw new FileAccessException(ex, filePath, true);
            }
        }

        public async Task WriteFileAsync(T state, string filePath)
        {
            try
            {
                var xml = XmlHelper.Serialize(state);
                var compresedBytes = DeflateHelper.CompressData(Encoding.UTF8.GetBytes(xml), CompressionLevel.Optimal);
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true))
                {
                    await fileStream.WriteAsync(compresedBytes, 0, compresedBytes.Length).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                throw new FileAccessException(ex, filePath, false);
            }
        }
    }
}
