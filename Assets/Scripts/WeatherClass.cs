using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class WeatherClass
{
    
}

public class Period
{
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
    public string unitCode { get; set; }
    public int? value { get; set; }
}

public class Properties
{
    public string units { get; set; }
    public string forecastGenerator { get; set; }
    public DateTime generatedAt { get; set; }
    public DateTime updateTime { get; set; }
    public string validTimes { get; set; }
    public List<Period> periods { get; set; }
}

public class Root
{
    public Properties properties { get; set; }
}