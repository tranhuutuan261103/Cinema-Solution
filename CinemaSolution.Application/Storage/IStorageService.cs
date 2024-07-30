using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Application.Storage
{
    public interface IStorageService
    {
        string GetFileUrl(string fileName);
        Task<string> UploadFileAsync(Stream mediaBinaryStream, string folderPath, string fileName);
        Task<string> DeleteFileAsync(string fileName);
    }
}
