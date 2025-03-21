using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;


public class WeatherDayClass 
{
   public int _dayTemp;
    public string _dayWindSpd = "-", _dayWindDirection = "-", _dayShort = "-", _dayLong = "-";
    public DateTime _date;
    public string _dayName = "-";
    public string _temperatureUnit = "-";

    public bool _isDayExist = false;

    public int _nightTemp;
    public string _nightWindSpd = "-", _nightWindDirection = "-", _nightShort = "-", _nightLong = "-";

    public string _urlDay, _urlNight;

    public Sprite _dayImage, _nightImage;

    public DateTime _updateTime;
}
