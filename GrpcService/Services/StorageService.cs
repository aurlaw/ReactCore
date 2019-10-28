using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcService.Services
{
    public class StorageService : IStorage
    {
        public async Task<string> SaveDocument(byte[] data)
        {
            return await Task.FromResult("https://localhost");
        }
    }
}
