using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Quhinja.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Quhinja.Services.Implementations
{
   public class BlobService : IBlobService
        {
            private readonly BlobServiceClient blobServiceClient;

            public const string ProfilePicturesContainer = "profile-pictures";
            public const string DishPicturesContainer = "vehicle-pictures";
            public const string RecipePicturesContainer = "vehicle-category-icons";
            public BlobService(BlobServiceClient blobServiceClient)
                 {
                     this.blobServiceClient = blobServiceClient;
                 }

            public async Task<Stream> GetBlobAsync(string name)
                {
                    var containerClient = blobServiceClient.GetBlobContainerClient("images");
                    var blob = containerClient.GetBlobClient(name);
                    var blobInfo = await blob.DownloadAsync();
                    return blobInfo.Value.Content;
                }

        public async Task<byte []> GetBytesFromPicture(IFormFile file)
        {
            var filePath = Path.GetTempFileName();
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            FileStream fS = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            byte[] b = new byte[fS.Length];
            fS.Read(b, 0, (int)fS.Length);
            fS.Close();
            return b;
        }
            public async Task<string> UploadPictureAsync(IFormFile file, string blobContainerName)
                {
                    var filePath = Path.GetTempFileName();

                    using (var stream = new FileStream(filePath, FileMode.Create))
                        { 
                        await file.CopyToAsync(stream);
                        }

           

            var fileContentType = file.FileName.Substring(file.FileName.LastIndexOf('.'));

                    var containerClient = blobServiceClient.GetBlobContainerClient(blobContainerName);

                    var blobClient = containerClient.GetBlobClient($"{Guid.NewGuid()}{fileContentType}");

                    var response = await blobClient.UploadAsync(filePath);

                    return blobClient.Uri.AbsoluteUri;
            
                }
        }
}
