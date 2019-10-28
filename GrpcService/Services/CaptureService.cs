using Grpc.Core;
using GrpcService.Protos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcService.Services
{
    public class CaptureService : Capture.CaptureBase
    {
        private readonly ILogger<CaptureService> _logger;
        private readonly IStorage _storageService;
        private readonly IScreenService _screenService;

        public CaptureService(ILogger<CaptureService> logger, IScreenService screenService, IStorage storage)
        {
            _logger = logger;
            _screenService = screenService;
            _storageService = storage;
        }

        public override Task<CaptureReply> Perform(CaptureRequest request, ServerCallContext context)
        {
            return Task.FromResult(new CaptureReply
            {
                Message = $"Capture: {request.Name}"
            });
        }

    }
}
