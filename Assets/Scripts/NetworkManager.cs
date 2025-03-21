using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System;


public class NetworkManager : MonoBehaviour
{
    public static NetworkManager instance;

    [SerializeField]
    QueueManager queueManager;

    [SerializeField]
    string urlWeather;
    [SerializeField]
    string urlDog;
    [SerializeField]
    List<BreedClass> _breeds;
    [SerializeField]
    List<Period> _periods;
    [SerializeField]
    WeatherClass _weatherClass;


    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        _breeds = new List<BreedClass>();
        _periods = new List<Period>();
       // StartCorutineMessageToBackand_Weather(false);
    }


    public void StartFetchingWeatherByInterval(float interval)
    {
        StartCoroutine(FetchWeather(interval));
    }

    public void SetActivePanel(int index)
    {

        queueManager.ClearQueue();
        StopAllCoroutines();

        switch (index)
        {
            case 0: {
                    StartFetchingWeatherByInterval(5f);
                } break;
            case 1:
                {
                    StartCorutineMessageToBackend_Dog(true);
                } break;
        }
    }

    private IEnumerator FetchWeather(float interval)
    {
        Debug.Log("Fetching Weather..");
        StartCorutineMessageToBackend_Weather(true);
        yield return new WaitForSeconds(interval);
        StartCoroutine(FetchWeather(interval));
    }


    private void StartCorutineMessageToBackend_Weather(bool inQueueCall)
    {
        if (!inQueueCall)
            StartCoroutine(SendMessageToBackend_Weather());
        else
            queueManager.AddMessageToQueue("Weather");
    }

    private void StartCorutineMessageToBackend_Dog(bool inQueueCall)
    {
        if(!inQueueCall)
            StartCoroutine(SendMessageToBackend_Dogs());
        else
            queueManager.AddMessageToQueue("Breed");
    }

    IEnumerator SendMessageToBackend_Weather()
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

                queueManager.ControlMessageSending(false);
            }
            else
            {
                //Debug.Log(request.downloadHandler.text);
                JObject jsonObject = JObject.Parse(request.downloadHandler.text);

                Debug.Log(jsonObject);

                JArray _jArray = jsonObject["properties"]["periods"].Value<JArray>();

                _periods.Clear();

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
                
                    Period period = new Period(_number, _neme, _startTime, _endTime, _isDaytime, _temperature, _temperatureUnit,
                        _temperatureTrend, _windSpeed, _windDirection, _icon, _shortForecast, _detailedForecast);    
                    _periods.Add(period);
                }

                string _units = jsonObject["properties"]["units"].Value<string>();
                string _forecastGenerator = jsonObject["properties"]["forecastGenerator"].Value<string>();

                DateTime _generatedAt = jsonObject["properties"]["generatedAt"].Value<DateTime>();
                DateTime _updateTime = jsonObject["properties"]["updateTime"].Value<DateTime>();
                string _validTimes = jsonObject["properties"]["validTimes"].Value<string>();

             //   _weatherClass = new WeatherClass(_units, _forecastGenerator, _generatedAt, _updateTime, _validTimes);
                _weatherClass = new WeatherClass(_units, _forecastGenerator, _generatedAt, DateTime.Now, _validTimes);
                WeatherUiManager.instance.AddDataWeather(_periods, _weatherClass);
                queueManager.ControlMessageSending(true);
            }
        }
    }
    
    IEnumerator SendMessageToBackend_Dogs()
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

                queueManager.ControlMessageSending(false);
            }
            else
            {
                //Debug.Log(request.downloadHandler.text);
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
                BreedUiManager.instance.AddDataUI(_breeds);
                queueManager.ControlMessageSending(true);
            }
        }
    }

    public void SendMessageInQueue(string message)
    {
        switch (message)
        {
            case "Weather":
                StartCorutineMessageToBackend_Weather(false);
                break;
            case "Breed":
                StartCorutineMessageToBackend_Dog(false);
                break;
        }
    }
}
