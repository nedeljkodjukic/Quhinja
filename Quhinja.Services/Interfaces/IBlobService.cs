﻿using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Quhinja.Services.Interfaces
{
    public interface IBlobService
    {
         Task<Stream> GetBlobAsync(string name);

        Task<string> UploadPictureAsync(IFormFile file, string blobContainerName);

    }
}
