using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrpcService.Config;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.Storage;
using Microsoft.Extensions.Options;

namespace GrpcService.Services
{
    public class StorageService : IStorage
    {
        private readonly StorageOptions options;
        private ILogger<StorageService> logger;

        public StorageService(ILogger<StorageService>  logger, IOptions<StorageOptions> options) 
        {
            this.options = options.Value;
            this.logger  = logger;
        }
        public async Task<string> SaveDocument(string fileName, byte[] data)
        {
            logger.LogInformation($"connection: {options.ConnectionString}");
            logger.LogInformation($"container: {options.Container}");
            var storageAccount = CloudStorageAccount.Parse(options.ConnectionString);
            var client = storageAccount.CreateCloudBlobClient();
            var blobContainer = client.GetContainerReference(options.Container);
            BlobContainerPermissions permissions = new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            };
            await blobContainer.SetPermissionsAsync(permissions);
            var blockBlob = blobContainer.GetBlockBlobReference(fileName);
            await blockBlob.UploadFromByteArrayAsync(data, 0, data.Length);
            return blockBlob.Uri.AbsoluteUri;
        }
    }
}