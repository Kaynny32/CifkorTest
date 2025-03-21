using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemWeather : MonoBehaviour
{


    [SerializeField]
    TextMeshProUGUI _dayNameDate, _dayTemp, _dayWindspd, _dayWindDirection, _dayShortForecast;
    [SerializeField]
    TextMeshProUGUI _nightTemp, _nightWindspd, _nightWindDirection, _nightShortForecast;

    int _index = 0;

    string _temperatureUnit;

    bool _isDayExist = false;

    public void SetMainInfo(int _index, string _dayNameValue, DateTime _date, string _temperatureUnit, bool _isDayExist = true)
    {
        this._index = _index;
        _dayNameDate.text = _dayNameValue + ", " + _date.ToString("d.MM");
        this._temperatureUnit = _temperatureUnit;
        this._isDayExist = _isDayExist;
    }

    public void SetDayInfo(int _dayTempValue, string _dayWindspdValue, string _dayWindDirectionValue, string _dayShortForecastValue)
    {
        _dayTemp.text = _dayTempValue.ToString() + _temperatureUnit;
        _dayWindspd.text = _dayWindspdValue;
        _dayWindDirection.text = _dayWindDirectionValue;
        _dayShortForecast.text = _dayShortForecastValue;
            
            
    }
    
    
    public void SetNightInfo(int _nightTempValue, string _nightWindspdValue, string _nightWindDirectionValue, string _nightShortForecastValue)
    {
        _nightTemp.text = _nightTempValue.ToString() + _temperatureUnit;
        _nightWindspd.text = _nightWindspdValue;
        _nightWindDirection.text = _nightWindDirectionValue;
        _nightShortForecast.text = _nightShortForecastValue;
            
            
    }

    public void OnClick()
    {
        WeatherUiManager.instance.ShowPopUpById(_index);
    }

    public bool GetIsDayExistState()
    {
        return _isDayExist; 
    }
}
