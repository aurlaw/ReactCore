using System;
using System.Threading.Tasks;
using GrpcService.Protos;
using Microsoft.AspNetCore.SignalR;
using ReactCore.Hubs;
using ReactCore.Models;

namespace ReactCore.Services
{
    public interface IWeatherService
    {
         Task GetWeatherAsync(Action<WeatherModel> action);
    }
}

