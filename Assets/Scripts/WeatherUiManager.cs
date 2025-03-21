using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WeatherUiManager : MonoBehaviour
{
    public static WeatherUiManager instance;

    List<ItemWeather> _items = new List<ItemWeather>();

    List<WeatherDayClass> _daysData = new List<WeatherDayClass>();

    [SerializeField]
    GameObject _itemPrefab, _itemParent;

    [SerializeField]
    List<Period> periods;

    [SerializeField]
    AnimUI InfoPopapWeatherDay, InfoPopapWeatherNight, _closeBtn;



    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        periods = new List<Period>();
    }

    public string GetPeriodLink(int i)
    {
        string url = periods[i].icon;
        return url;
    }
 

    public void AddDataWeather(List<Period> _periods, WeatherClass _weatherClass)
    {
        periods.Clear();

        periods = _periods;

        AddDataUI(_weatherClass);
    }

    void AddDataUI(WeatherClass _weatherClass)
    {

        int _dayCount = 0;
        Period _tempDayTimePeriod = new Period();
        bool isDayForecastExist = false;
        ItemWeather _tempItem;


        for (int i = 0; i < periods.Count; i++)
            {

            if (periods[i].isDaytime)
            {
                isDayForecastExist = true;
                _tempDayTimePeriod = periods[i];
            } else
            {

                WeatherDayClass _tempDayData = new WeatherDayClass();

                _tempItem = Instantiate(_itemPrefab, _itemParent.transform).GetComponent<ItemWeather>();
             
                

                if (isDayForecastExist)
                {

                    _tempDayData._dayName = _tempDayTimePeriod.name;
                    _tempDayData._date = _tempDayTimePeriod.startTime;
                    _tempDayData._temperatureUnit = _tempDayTimePeriod.temperatureUnit;
                    _tempDayData._dayTemp = _tempDayTimePeriod.temperature;
                    _tempDayData._dayWindSpd = _tempDayTimePeriod.windSpeed;
                    _tempDayData._dayWindDirection = _tempDayTimePeriod.windDirection;
                    _tempDayData._dayShort = _tempDayTimePeriod.shortForecast;
                    _tempDayData._dayLong = _tempDayTimePeriod.detailedForecast;
                    _tempDayData._isDayExist = true;
                    _tempDayData._urlDay = _tempDayTimePeriod.icon;

                    _tempItem.SetMainInfo(_dayCount, _tempDayTimePeriod.name, _tempDayTimePeriod.startTime, _tempDayTimePeriod.temperatureUnit);
                    _tempItem.SetDayInfo(_tempDayTimePeriod.temperature, _tempDayTimePeriod.windSpeed, _tempDayTimePeriod.windDirection, _tempDayTimePeriod.shortForecast);
               
                }
                else
                {
                    _tempDayData._dayName = periods[i].name;
                    _tempDayData._date = periods[i].startTime;
                    _tempDayData._temperatureUnit = periods[i].temperatureUnit;
                    
                    _tempItem.SetMainInfo(_dayCount, periods[i].name, periods[i].startTime, periods[i].temperatureUnit, false);
                }

                _tempDayData._nightTemp = periods[i].temperature;
                _tempDayData._nightWindSpd = periods[i].windSpeed;
                _tempDayData._nightWindDirection = periods[i].windDirection;
                _tempDayData._nightShort = periods[i].shortForecast;
                _tempDayData._nightLong = periods[i].detailedForecast;
                _tempDayData._urlNight = periods[i].icon;

                _tempItem.SetNightInfo(periods[i].temperature, periods[i].windSpeed, periods[i].windDirection, periods[i].shortForecast);

                _dayCount++;
                _daysData.Add(_tempDayData);
                _items.Add(_tempItem);

            }
            }
      
            
        
        
    }

    [SerializeField]
    TextMeshProUGUI _puDayTemp, _puDayWindSpd, _puDayShort, _puDayLong, _puDate;

    [SerializeField]
    TextMeshProUGUI _puNightTemp, _puNightWindSpd, _puNightShort, _puNightLong;

    [SerializeField]
    RawImage _dayImage, _nightImage;


    public void ShowPopUpById(int index)
    {
        
        _closeBtn.ShowUI();

        WeatherDayClass itemWeather = _daysData[index];
        

        _puDate.text = itemWeather._dayName + ", " + itemWeather._date.ToString("d.MM");
        if (itemWeather._isDayExist)
        {
            FileDownloader.instance.StartLoadImage(itemWeather._urlDay, _dayImage);
            InfoPopapWeatherDay.ShowUI();
            _puDayTemp.text = itemWeather._dayTemp.ToString() + itemWeather._temperatureUnit;
                _puDayWindSpd.text = itemWeather._dayWindSpd;
            _puDayShort.text = itemWeather._dayShort;
            _puDayLong.text = itemWeather._dayLong;
            
        }
        FileDownloader.instance.StartLoadImage(itemWeather._urlNight, _nightImage);
        InfoPopapWeatherNight.ShowUI();
        _puNightTemp.text = itemWeather._nightTemp.ToString() + itemWeather._temperatureUnit;
        _puNightWindSpd.text = itemWeather._nightWindSpd;
        _puNightShort.text = itemWeather._nightShort;
        _puNightLong.text = itemWeather._nightLong;
    }

}