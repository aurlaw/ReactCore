using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcService.Services
{
    public interface IStorage
    {
        Task<string> SaveDocument(string fileName, byte[] data);
    }
}
