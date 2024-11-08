using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Application.Storage
{
    public class StorageService : IStorageService
    {
        private readonly string storageBucket = "tune-cinema.appspot.com";

        public Task<string> DeleteFileAsync(string fileName)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UploadFileAsync(Stream mediaBinaryStream, string folderPath, string fileName)
        {
            try
            {
                var firebaseStorage = new FirebaseStorage(
                        storageBucket,
                        new FirebaseStorageOptions
                        {
                            ThrowOnCancel = true
                        })
                        .Child(folderPath)
                        .Child(fileName);
                await firebaseStorage.PutAsync(mediaBinaryStream);
                string fileUrl = await firebaseStorage.GetDownloadUrlAsync();
                return fileUrl;
            }
            catch (Exception ex)
            {
                throw new StorageException("Error while uploading file to Firebase Storage", ex);
            }
        }

        public string GetFileUrl(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
