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


    /*

    public void SetInfoDayAndNight(int i, string _temperatureUnit, string _windSpeed, string _windDirection, string _shortForecastt, string _detailedForecast, int i_Night, string _temperatureUnit_Night, string _windSpeed_Night, string _windDirection_Night, string _shortForecastt_Night, string _detailedForecast_Night)
    {

        


        temperature = i;
        temperatureUnit = _temperatureUnit;
        windSpeed = _windSpeed;
        windDirection = _windDirection;
        shortForecast = _shortForecastt;
        detailedForecast = _detailedForecast;

        temperature_Night = i_Night;
        windSpeed_Night = _windSpeed_Night;
        windDirection_Night = _windDirection_Night;
        shortForecast_Night = _shortForecastt_Night;
        detailedForecast_Night = _detailedForecast_Night;
    }

    public void AddClick(int indexBtn, GameObject go)
    {
        transform.GetChild(indexBtn).GetComponent<Button>().onClick.AddListener(() =>
        {
       //     ClickBtnBreed(go);
        });
    }


    public void ClickBtnWeather()
    {
     //   FileDownloader.instance.StartLoadImage(WeatherUiManager.instance.GetPeriodsDayLink(indexItem), WeatherUiManager.instance.GetPeriodsNightLink(indexItem));
        AddDataUI(UI_Manager.instance.GetInfoPopapWeather(),1,0,$"Temperature: {temperature} {temperatureUnit}");
        AddDataUI(UI_Manager.instance.GetInfoPopapWeather(),1,1,$"Wind Speed: {windSpeed} {windDirection}");
        AddDataUI(UI_Manager.instance.GetInfoPopapWeather(),1,2,$"Short Forecast: {shortForecast}");
        AddDataUI(UI_Manager.instance.GetInfoPopapWeather(),1,3,$"Detailed Forecast: {detailedForecast}");

        AddDataUI(UI_Manager.instance.GetInfoPopapWeather(), 3, 0, $"Temperature: {temperature_Night} {temperatureUnit_Night}");
        AddDataUI(UI_Manager.instance.GetInfoPopapWeather(), 3, 1, $"Wind Speed: {windSpeed_Night} {windDirection_Night}");
        AddDataUI(UI_Manager.instance.GetInfoPopapWeather(), 3, 2, $"Short Forecast: {shortForecast_Night}");
        AddDataUI(UI_Manager.instance.GetInfoPopapWeather(), 3, 3, $"Detailed Forecast: {detailedForecast_Night}");
        UI_Manager.instance.GetInfoPopapWeather().GetComponent<AnimUI>().ShowUI(false);
        UI_Manager.instance.GetBlockBtnWeather().SetActive(true);
    }

    public void AddDataUI(GameObject go, int childCon, int childText,string str)
    {
        go.transform.GetChild(childCon).GetChild(childText).GetComponent<TextMeshProUGUI>().text = str;
    }*/


}
