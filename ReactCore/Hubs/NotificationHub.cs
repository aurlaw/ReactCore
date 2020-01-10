using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using ReactCore.Services;

namespace ReactCore.Hubs
{

    public class NotificationHub : Hub
    {
        private readonly ILogger<NotificationHub> _logger;
        private readonly IWeatherService _weatherService;

        public NotificationHub(ILogger<NotificationHub> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }
        public async Task Subscribe(string name)
        {
            await Clients.Caller.SendAsync("SubscriberAdded", name);
        }

        public async Task GetWeather()
        {
            await _weatherService.GetWeatherAsync(async(data) => 
            {
                if(data.Error != null)
                {
                    await Clients.Caller.SendAsync("WeatherError", data.Error.Message);
                }
                if(data.WeatherData != null)
                {
                    await Clients.Caller.SendAsync("WeatherReceive", data.WeatherData);
                }
            });
        }
    }
}