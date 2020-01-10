using System;
using GrpcService.Protos;

namespace ReactCore.Models {
    public class WeatherModel {
        public WeatherModel (WeatherData weatherData, Exception error) {
            this.WeatherData = new WeatherDataModel(weatherData);
            this.Error = error;
        }
        public WeatherModel (WeatherData weatherData) : this (weatherData, null) { }
        public WeatherModel (Exception error) : this (null, error) { }
        public WeatherDataModel WeatherData { get; private set; }
        public Exception Error { get; private set; }

    }

    public class WeatherDataModel {
        public WeatherDataModel (WeatherData weatherData) {
            this.WeatherData = weatherData;
            this.DateTime = weatherData?.DateTime.ToDateTime();

        }
        public WeatherData WeatherData { get; private set; }
        public DateTime? DateTime { get; private set; }
    }

}