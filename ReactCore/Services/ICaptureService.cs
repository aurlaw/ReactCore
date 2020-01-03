using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactCore.Services
{
    public interface ICaptureService
    {

        Task<string> TestAsync(string id);
        Task<string> ExecuteAsync(string url);
    }
}
