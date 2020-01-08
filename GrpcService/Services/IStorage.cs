using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcService.Services
{
    public interface IStorage
    {
        Task<string> SaveDocument(string fileName, string contentType, byte[] data);
    }
}
