using System;
using Grpc.Net.Client;
using Microsoft.Extensions.Options;
using ReactCore.Config;

namespace ReactCore.Services.Grpc
{
    public abstract class ClientBase
    {
        protected readonly GrpcChannel _channel;
        protected readonly GrpcOptions _options;

        public ClientBase( IOptions<GrpcOptions> options) 
        {       
             _options = options.Value;
            // This switch must be set before creating the GrpcChannel/HttpClient.
            AppContext.SetSwitch(
                "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            _channel = GrpcChannel.ForAddress(_options.Connection);        }
        
    }
}