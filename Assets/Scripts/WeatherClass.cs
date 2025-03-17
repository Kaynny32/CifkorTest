using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class WeatherClass
{
    public WeatherClass(string units, string forecastGenerator, DateTime generatedAt, DateTime updateTime, string validTimes)
    { 
        this.units = units;
        this.forecastGenerator = forecastGenerator;
        this.generatedAt = generatedAt;
        this.updateTime = updateTime;
        this.validTimes = validTimes;
    }

    public string units { get; set; }
    public string forecastGenerator { get; set; }
    public DateTime generatedAt { get; set; }
    public DateTime updateTime { get; set; }
    public string validTimes { get; set; }
}
[Serializable]
public class Period
{
    public Period(int number, string name, DateTime startTime, DateTime endTime, bool isDaytime, int temperature, string temperatureUnit, string temperatureTrend, ProbabilityOfPrecipitation probabilityOfPrecipitation, string windSpeed, string windDirection, string icon, string shortForecast, string detailedForecast)
    {
        this.number = number;
        this.name = name;
        this.startTime = startTime;
        this.endTime = endTime;
        this.isDaytime = isDaytime;
        this.temperature = temperature;
        this.temperatureUnit = temperatureUnit;
        this.temperatureTrend = temperatureTrend;
        this.probabilityOfPrecipitation = probabilityOfPrecipitation;
        this.windSpeed = windSpeed;
        this.windDirection = windDirection;
        this.icon = icon;
        this.shortForecast = shortForecast;
        this.detailedForecast = detailedForecast;
    }

    public int number { get; set; }
    public string name { get; set; }
    public DateTime startTime { get; set; }
    public DateTime endTime { get; set; }
    public bool isDaytime { get; set; }
    public int temperature { get; set; }
    public string temperatureUnit { get; set; }
    public string temperatureTrend { get; set; }
    public ProbabilityOfPrecipitation probabilityOfPrecipitation { get; set; }
    public string windSpeed { get; set; }
    public string windDirection { get; set; }
    public string icon { get; set; }
    public string shortForecast { get; set; }
    public string detailedForecast { get; set; }
}

public class ProbabilityOfPrecipitation
{
    public ProbabilityOfPrecipitation(string unitCode) //int value)
    {
        this.unitCode = unitCode;
       // this.value = value;
    }

    public string unitCode { get; set; }
    //public int value { get; set; }
}