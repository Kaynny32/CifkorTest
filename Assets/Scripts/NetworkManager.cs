using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Serialization;
using System;


public class NetworkManager : MonoBehaviour
{
    [SerializeField]
    string urlWeather;
    [SerializeField]
    string urlDog;
    [SerializeField]
    List<BreedClass> _breeds;
    [SerializeField]
    List<Period> _period;
    [SerializeField]
    WeatherClass _weatherClass;


    private void Start()
    {
        _breeds = new List<BreedClass>();
        _period = new List<Period>();
    }


    public void StartCorutineMessageToBackand_Weather()
    {
        StartCoroutine(SendMessageToBackand_Weather());
    }

    public void StartCorutineMessageToBackand_Dog()
    {
        StartCoroutine(SendMessageToBackand_Dogs());
    }

    IEnumerator SendMessageToBackand_Weather(/*Action<List<Period>> callback*/)
    {
        using (var request = UnityWebRequest.Get(urlWeather))
        {
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success)
            {
                string errorMessage;
                try
                {
                    JObject jOBject = JObject.Parse(request.downloadHandler.text);
                    errorMessage = jOBject["message"].Value<string>();
                    Debug.Log(jOBject);
                }
                catch
                {
                    errorMessage = request.error;
                    Debug.Log(errorMessage);
                }
            }
            else
            {
                //Debug.Log(request.downloadHandler.text);
                JObject jsonObject = JObject.Parse(request.downloadHandler.text);

                JArray _jArray = jsonObject["properties"]["periods"].Value<JArray>();

                _period.Clear();

                foreach (JObject _elem in _jArray)
                {                    

                    int _number = _elem["number"].Value<int>();
                    string _neme = _elem["name"].Value<string>();
                    DateTime _startTime = _elem["startTime"].Value<DateTime>();
                    DateTime _endTime = _elem["endTime"].Value<DateTime>();
                    bool _isDaytime = _elem["isDaytime"].Value<bool>();
                    int _temperature = _elem["temperature"].Value<int>();
                    string _temperatureUnit = _elem["temperatureUnit"].Value<string>();
                    string _temperatureTrend = _elem["temperatureTrend"].Value<string>();

                    JObject _probabilityOfPrecipitation = _elem["probabilityOfPrecipitation"].Value<JObject>();

                    string _unitCode = _probabilityOfPrecipitation["unitCode"].Value<string>();
                    //int _value = _probabilityOfPrecipitation["value"].Value<int>();

                    string _windSpeed = _elem["windSpeed"].Value<string>();
                    string _windDirection = _elem["windDirection"].Value<string>();
                    string _icon = _elem["icon"].Value<string>();
                    string _shortForecast = _elem["shortForecast"].Value<string>();
                    string _detailedForecast = _elem["detailedForecast"].Value<string>();

                    ProbabilityOfPrecipitation probabilityOfPrecipitation = new ProbabilityOfPrecipitation(_unitCode/*, _value*/);                   
                    Period period = new Period(_number, _neme, _startTime, _endTime, _isDaytime, _temperature, _temperatureUnit, _temperatureTrend, probabilityOfPrecipitation, _windSpeed, _windDirection, _icon, _shortForecast, _detailedForecast);    
                    _period.Add(period);
                }

                string _units = jsonObject["properties"]["units"].Value<string>();
                string _forecastGenerator = jsonObject["properties"]["forecastGenerator"].Value<string>();

                DateTime _generatedAt = jsonObject["properties"]["generatedAt"].Value<DateTime>();
                DateTime _updateTime = jsonObject["properties"]["updateTime"].Value<DateTime>();
                string _validTimes = jsonObject["properties"]["validTimes"].Value<string>();

                _weatherClass = new WeatherClass(_units, _forecastGenerator, _generatedAt, _updateTime, _validTimes);
                WeatherUiManager.instance.InstatiateItem(_period);                
            }
        }
    }
    
    IEnumerator SendMessageToBackand_Dogs()
    {
        using (var request = UnityWebRequest.Get(urlDog))
        {

            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success)
            {
                string errorMessage;
                try
                {
                    JObject jOBject = JObject.Parse(request.downloadHandler.text);
                    errorMessage = jOBject["message"].Value<string>();
                }
                catch
                {
                    errorMessage = request.error;
                }
            }
            else
            {
                 Debug.Log(request.downloadHandler.text);
                JObject jsonObject = JObject.Parse(request.downloadHandler.text);

                JArray _jArray = jsonObject["data"].Value<JArray>();

                _breeds.Clear();

                foreach (JObject _elem in _jArray)
                {
                    string _id = _elem["id"].Value<string>();
                    string _type = _elem["type"].Value<string>();

                    JObject _attributesJobj = _elem["attributes"].Value<JObject>();

                    string _name = _attributesJobj["name"].Value<string>();
                    string _description = _attributesJobj["description"].Value<string>();

                    JObject _lifeJobj = _attributesJobj["life"].Value<JObject>();

                    int _lifeMin = _lifeJobj["min"].Value<int>();
                    int _lifeMax = _lifeJobj["max"].Value<int>();

                    JObject male_weightJobj = _attributesJobj["male_weight"].Value<JObject>();

                    int _mWeightMin = male_weightJobj["min"].Value<int>();
                    int _mWeightMax = male_weightJobj["max"].Value<int>();

                    JObject female_weightJobj = _attributesJobj["female_weight"].Value<JObject>();

                    int _fWeightMin = female_weightJobj["min"].Value<int>();
                    int _fWeightMax = female_weightJobj["max"].Value<int>();

                    bool _hypoallergenic = _attributesJobj["hypoallergenic"].Value<bool>();

                    JObject _relationshipsJobj = _elem["relationships"].Value<JObject>();

                    string _rs_id = _relationshipsJobj["group"]["data"]["id"].Value<string>();
                    string _rs_type = _relationshipsJobj["group"]["data"]["type"].Value<string>();

                    Life _life = new Life(_lifeMin, _lifeMax);
                    MaleWeight _maleWeight = new MaleWeight(_mWeightMin, _mWeightMax);
                    FemaleWeight _femaleWeight = new FemaleWeight(_fWeightMin, _fWeightMax);
                    Relationships _relationship = new Relationships(_rs_id, _rs_type);
                    Attributes _attributes = new Attributes(_name, _description, _life, _maleWeight, _femaleWeight, _hypoallergenic);

                    BreedClass _tempBreed = new BreedClass(_id, _type, _attributes, _relationship);

                    _breeds.Add(_tempBreed);
                }
                BreedUiManager.instance.InstatiateItem(_breeds.Count, _breeds);
            }
        }
    }
}
