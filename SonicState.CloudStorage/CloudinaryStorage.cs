using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using SonicState.Contracts;

namespace SonicState.CloudStorage
{
    public class CloudinaryStorage : FileStorage
    {
        private static readonly string defaultUrl = "https://res.cloudinary.com/dc2luclac/video/upload/";
        private static readonly string cloudName = "dc2luclac";
        private static readonly string apiKey = "625915388985786";
        private static readonly string apiSecret = "5DrRB_FlbSGJuAb8ggVEP-jc9U0";
        private static readonly string environmentVariable = "CLOUDINARY_URL=cloudinary://625915388985786:5DrRB_FlbSGJuAb8ggVEP-jc9U0@dc2luclac";

        static Account account = new Account(cloudName, apiKey, apiSecret);
        Cloudinary cloudinary = new Cloudinary(account);

        public async Task Upload(IFormFile file, string storageName)
        {
            var uploadParams = new RawUploadParams()
            {
                File = new FileDescription(storageName, file.OpenReadStream()),
                UseFilename = true,
                UniqueFilename = false
                
            };

            cloudinary.Upload(uploadParams);
        }


       public async Task<string> GenerateURL(string objectName)
        {
            return defaultUrl + objectName;
        }
    }
}
