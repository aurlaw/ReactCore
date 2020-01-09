using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using ReactCore.Services;

namespace ReactCore.Hubs
{

    public class NotificationHub : Hub
    {
        private readonly string SubGroup = "NotificationGroup";
        private readonly ILogger<NotificationHub> _logger;
        private readonly IWeatherService _weatherService;

        public NotificationHub(ILogger<NotificationHub> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }
        public async Task Subscribe(string name)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, SubGroup);
            await Clients.Caller.SendAsync("SubscriberAdded", name);
        }

        public async Task GetWeather()
        {
            await _weatherService.GetWeatherAsync(Context, async(hub, data) => 
            {
                if(data.Error != null)
                {
                    await hub.Proxy.SendAsync("WeatherError", data.Error.Message);
                }
                if(data.WeatherData != null)
                {
                    await hub.Proxy.SendAsync("WeatherReceive", data.WeatherData);
                }
            });
        }
    }
}