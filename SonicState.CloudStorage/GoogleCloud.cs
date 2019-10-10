//using Google.Apis.Storage.v1.Data;
//using Google.Cloud.Storage.V1;
//using Microsoft.AspNetCore.Http;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Threading.Tasks;
//using SonicState.Contracts;

//namespace SonicState.CloudStorage
//{
//    public class GoogleCloud : FileStorage
//    {
//        private const string bucketName = "sonicstate";
//        private readonly string defaultURL = "https://storage.googleapis.com/sonicstate/";

//        private readonly StorageClient storageClient;

//        public GoogleCloud()
//        {
//            storageClient = StorageClient.Create();
//        }

//        public void UploadFromUrl(string fileUrl)
//        {
//            FileStream fileStream = File.OpenRead(fileUrl);
//            string fileName = fileUrl.Substring(fileUrl.LastIndexOf("\\"));
//            storageClient.UploadObject(bucketName, fileName, null, fileStream);
//            MakePublic(bucketName, fileName);
//        }
//        public async Task Upload(IFormFile file, string storageName)
//        {
//            await storageClient.UploadObjectAsync(bucketName, storageName, null, file.OpenReadStream());
//            MakePublic(bucketName, storageName);
//        }
//        public async Task<string> GenerateURL(string objectName)
//        {
//            // var storageObject = await storageClient.GetObjectAsync(bucketName, objectName);
//            return defaultURL + objectName;
//        }
//        private void MakePublic(string bucketName, string objectName)
//        {
//            var storageObject = storageClient.GetObject(bucketName, objectName);
//            storageObject.Acl = storageObject.Acl ?? new List<ObjectAccessControl>();
//            storageClient.UpdateObject(storageObject, new UpdateObjectOptions
//            {
//                PredefinedAcl = PredefinedObjectAcl.PublicRead
//            });

//            Console.WriteLine(objectName + " is now public and can be fetched from " +
//                storageObject.MediaLink);
//        }

//    }
//}
