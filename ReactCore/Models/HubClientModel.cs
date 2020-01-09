using Microsoft.AspNetCore.SignalR;
using ReactCore.Hubs;

namespace ReactCore.Models {
    public class HubClientModel<T> where T : Hub {
        public HubClientModel (IHubContext<T> hubContext, string groupName) 
        {
            this.HubContext = hubContext;
            this.Proxy = hubContext.Clients.Group(groupName);

        }
        public IHubContext<T> HubContext { get; private set; }

        public IClientProxy Proxy { get; }
    }
}