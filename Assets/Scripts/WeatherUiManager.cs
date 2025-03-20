using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class WeatherUiManager : MonoBehaviour
{
    public static WeatherUiManager instance;

    [SerializeField]
    List<GameObject> DaysOfTheWeek = new List<GameObject>();
    [SerializeField]
    List<Period> periodsDay;
    [SerializeField]
    List<Period> periodsNight;



    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        periodsDay = new List<Period>();
        periodsNight = new List<Period>();
    }

    public string GetPeriodsDayLink(int i)
    {
        string url = periodsDay[i].icon;
        return url;
    }
    public string GetPeriodsNightLink(int i)
    {
        string url = periodsNight[i].icon;
        return url;
    }

    public void SortDataWeather(List<Period> _periods, WeatherClass _weatherClass)
    {
        periodsDay.Clear();
        periodsNight.Clear();
        for (int i = 0; i < _periods.Count; i++)
        {
            if (_periods[i].isDaytime)
                periodsDay.Add(_periods[i]);
            else
                periodsNight.Add(_periods[i]);
        }
        AddDataUI(_weatherClass);
    }

    void AddDataUI(WeatherClass _weatherClass)
    {
        if (_weatherClass.generatedAt.TimeOfDay.Hours < 18 )
        {
            for (int i = 0; i < periodsDay.Count; i++)
            {
                DaysOfTheWeek[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = periodsDay[i].name;
                DaysOfTheWeek[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = $"Temp: {periodsDay[i].temperature.ToString()} {periodsDay[i].temperatureUnit}";
                DaysOfTheWeek[i].transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = $"Speed: {periodsDay[i].windSpeed.ToString()} {periodsDay[i].windDirection}";
            }
        }
        else 
        {
            for (int i = 0; i < periodsNight.Count; i++)
            {
                DaysOfTheWeek[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = periodsNight[i].name;
                DaysOfTheWeek[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = $"Temp: {periodsNight[i].temperature.ToString()} {periodsNight[i].temperatureUnit}";
                DaysOfTheWeek[i].transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = $"Speed: {periodsNight[i].windSpeed.ToString()} {periodsNight[i].windDirection}";
            }
        }
        InfoPopap();
    }

    void InfoPopap()
    {
        for (int i = 0; i< DaysOfTheWeek.Count; i++)
        {
            DaysOfTheWeek[i].GetComponent<Item>().SetInfoDayAndNight(periodsDay[i].temperature, 
                periodsDay[i].temperatureUnit, 
                periodsDay[i].windSpeed,
                periodsDay[i].windDirection,
                periodsDay[i].shortForecast, 
                periodsDay[i].detailedForecast, 
                periodsNight[i].temperature, 
                periodsNight[i].temperatureUnit, 
                periodsNight[i].windSpeed, 
                periodsNight[i].windDirection, 
                periodsNight[i].shortForecast, 
                periodsNight[i].detailedForecast);
        }
    }
}