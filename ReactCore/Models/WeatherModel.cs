using System;
using GrpcService.Protos;

namespace ReactCore.Models 
{
    public class WeatherModel 
    {
        public WeatherModel (WeatherData weatherData, Exception error) 
        {
            this.WeatherData = weatherData;
            this.Error = error;
        }
        public WeatherModel (WeatherData weatherData): this( weatherData, null) {}
        public WeatherModel (Exception error): this( null, error) {}
        public WeatherData WeatherData { get; private set; }
        public Exception Error { get; private set; }

    }
}