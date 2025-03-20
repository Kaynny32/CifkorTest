using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    #region Variables Breed
    [SerializeField]
    string _idBreed;
    [SerializeField]
    string _description;
    [SerializeField]
    string _name;
    [SerializeField]
    List<string> _life = new List<string>();
    [SerializeField]
    List<string> _male_weight = new List<string>();
    [SerializeField]
    List<string> _female_weight = new List<string>();
    [SerializeField]
    bool _hypoallergenic;
    #endregion
    #region SetBreed
    public void SetId(string id)
    {
        _idBreed = id;
    }

    string GetId()
    {
        return _idBreed;
    }
    public void SetDescription(string description)
    {
        _description = description;
    }

    public void SetName(string name)
    {
        _name = name;
    }
    public void Set_life(string Lifemin, string LifeMax)
    {
        _life.Add(Lifemin);
        _life.Add(LifeMax);
    }

    public void Set_male_weight(string MaleMin, string MaleMax)
    {
        _male_weight.Add(MaleMin);
        _male_weight.Add(MaleMax);
    }

    public void Set_female_weight(string FamaleMin, string FamaleMax)
    {
        _female_weight.Add(FamaleMin);
        _female_weight.Add(FamaleMax);
    }

    public void Set_Hypoallergenic(bool hypoallergenic)
    {
        _hypoallergenic = hypoallergenic;
    }


    #endregion
    #region Variables Weather
    [SerializeField]
    int indexItem = 0;

    int temperature, temperature_Night;
    string temperatureUnit, windSpeed, windDirection, shortForecast, detailedForecast, temperatureUnit_Night, windSpeed_Night, windDirection_Night, shortForecast_Night, detailedForecast_Night;
    #endregion
    #region SetWeather
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
    #endregion


    public void AddClick(int indexBtn, GameObject go)
    {
        transform.GetChild(indexBtn).GetComponent<Button>().onClick.AddListener(() =>
        {
            ClickBtnBreed(go);
        });
    }

    public void ClickBtnBreed(GameObject go)
    {
        UI_Manager.instance.GetInfoPopapBreed().transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = _name;
        UI_Manager.instance.GetInfoPopapBreed().transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = _description;

        UI_Manager.instance.GetInfoPopapBreed().transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text = $"Min: {_life[0]}";
        UI_Manager.instance.GetInfoPopapBreed().transform.GetChild(3).GetChild(1).GetComponent<TextMeshProUGUI>().text = $"Max: {_life[1]}";

        UI_Manager.instance.GetInfoPopapBreed().transform.GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text = $"Min: {_male_weight[0]}";
        UI_Manager.instance.GetInfoPopapBreed().transform.GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text = $"Max: {_male_weight[1]}";

        UI_Manager.instance.GetInfoPopapBreed().transform.GetChild(5).GetChild(0).GetComponent<TextMeshProUGUI>().text = $"Min: {_female_weight[0]}";
        UI_Manager.instance.GetInfoPopapBreed().transform.GetChild(5).GetChild(1).GetComponent<TextMeshProUGUI>().text = $"Max: {_female_weight[1]}";

        UI_Manager.instance.GetInfoPopapBreed().transform.GetChild(6).GetChild(0).GetComponent<Toggle>().isOn = _hypoallergenic;

        UI_Manager.instance.GetBlockBtnBreedr().SetActive(true);
        go.GetComponent<AnimUI>().ShowUI(false);
    }

    public void ClickBtnWeather()
    {
        FileDownloader.instance.StartLoadImage(WeatherUiManager.instance.GetPeriodsDayLink(indexItem), WeatherUiManager.instance.GetPeriodsNightLink(indexItem));
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
    }
}
