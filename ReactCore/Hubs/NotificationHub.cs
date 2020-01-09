using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace ReactCore.Hubs
{

    public class NotificationHub : Hub
    {
        private readonly ILogger<NotificationHub> _logger;

        public NotificationHub(ILogger<NotificationHub> logger)
        {
            _logger = logger;
        }
        public async Task Subscribe(string name)
        {
            await Clients.All.SendAsync("SubscriberAdded", name);
        }
    }
}