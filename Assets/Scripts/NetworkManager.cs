using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System;
using System.Net;
using System.Linq;

public class NetworkManager : MonoBehaviour
{
    [SerializeField]
    string urlWeather;
    [SerializeField]
    string urlDog;



    private void Update()
    {

    }

    public void StartCorutineMessageToBackand_Weather()
    {
        StartCoroutine(SendMessageToBackand_Weather());
    }

    public void StartCorutineMessageToBackand_Dog()
    {
        StartCoroutine(SendMessageToBackand_Dogs());
    }

    IEnumerator SendMessageToBackand_Weather()
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
                Debug.Log(request.downloadHandler.text);
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
                JObject data = JObject.Parse(request.downloadHandler.text);
                Debug.Log(data);

                DataManager.instance.AddData_Breeds(data["id"].Value<string>(),
                    data["type"].Value<string>(),
                    data["attributes"]["name"].Value<string>(),
                    data["attributes"]["description"].Value<string>(),
                    data["attributes"]["life"]["description"].Value<string>(),
                    data["attributes"]["life"]["description"].Value<string>(),
                    data["attributes"]["male_weight"]["description"].Value<string>(),
                    data["attributes"]["male_weight"]["description"].Value<string>(),
                    data["attributes"]["female_weight"]["description"].Value<string>(),
                    data["attributes"]["female_weight"]["description"].Value<string>(),
                    data["attributes"]["hypoallergenic"].Value<bool>(),
                    data["relationships"]["group"]["data"]["id"].Value<string>(),
                    data["relationships"]["group"]["data"]["type"].Value<string>());
                /*DataManager.instance.AddData_Breeds(DataManager.instance.GetStringFieldFromJsonData(data, "id","", true),
                    DataManager.instance.GetStringFieldFromJsonData(data, "type","",true),
                    DataManager.instance.GetStringFieldFromJsonData(data, "attributes", "name", false),
                    DataManager.instance.GetStringFieldFromJsonData(data, "attributes", "description", false),
                    DataManager.instance.GetStringFieldFromJsonData(data, "life","max", false),
                    DataManager.instance.GetStringFieldFromJsonData(data, "life","min",false),
                    DataManager.instance.GetStringFieldFromJsonData(data, "male_weight","max", false),
                    DataManager.instance.GetStringFieldFromJsonData(data, "male_weight","min", false),
                    DataManager.instance.GetStringFieldFromJsonData(data, "female_weight", "max", false),
                    DataManager.instance.GetStringFieldFromJsonData(data, "female_weight", "min", false),
                    DataManager.instance.GetBoolFieldFromJsonData(data, "hypoallergenic"),
                    data["relationships"]["group"]["data"]["id"].Value<string>(),
                    data["relationships"]["group"]["data"]["type"].Value<string>());*/
            }
        }
    }
}
