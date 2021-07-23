using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using eStore.AzureBlob;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace eStore
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobClient;

        public BlobService(BlobServiceClient blobServiceClient)
        {
            _blobClient = blobServiceClient;
        }

        public async Task<IEnumerable<string>> AllBlobs(string containerName)
        {
            //Allow to access the data inside the container
            var containerClient = _blobClient.GetBlobContainerClient(containerName);

            var files = new List<string>();
            var blobs = containerClient.GetBlobsAsync();

            await foreach (var item in blobs)
            {
                files.Add(item.Name);
            }

            return files;
        }

        public async Task<bool> DeleteBlob(string name, string containerName)
        {
            var containerClient = _blobClient.GetBlobContainerClient(containerName);
            var blogClient = containerClient.GetBlobClient(name);

            return await blogClient.DeleteIfExistsAsync();
        }

        public async Task<string> GetBlob(string name, string containerName)
        {
            var containerClient = _blobClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(name);
            return blobClient.Uri.AbsoluteUri;
        }

        public async Task<bool> UploadBlob(string name, IFormFile file, string containerName)
        {
            var containerClient = _blobClient.GetBlobContainerClient(containerName);

            var blobClient = containerClient.GetBlobClient(name);

            var httpHeader = new BlobHttpHeaders()
            {
                ContentType = file.ContentType
            };

            var result = await blobClient.UploadAsync(file.OpenReadStream(), httpHeader);

            if (result != null) return true;
            return false;
        }
    }
}
