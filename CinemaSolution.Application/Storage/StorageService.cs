using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Application.Storage
{
    public class StorageService : IStorageService
    {
        public Task<string> DeleteFileAsync(string fileName)
        {
            throw new NotImplementedException();
        }
        public string GetFileUrl(string fileName)
        {
            throw new NotImplementedException();
        }
        public async Task<string> SaveFileAsync(Stream mediaBinaryStream, string filePath)
        {
            using var output = new FileStream(filePath, FileMode.Create);
            await mediaBinaryStream.CopyToAsync(output);
            return filePath;
        }
    }
}
