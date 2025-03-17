using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class WeatherUiManager : MonoBehaviour
{
    public static WeatherUiManager instance;

    [SerializeField]
    GameObject _conteiner;
    [SerializeField]
    GameObject _itemPrefab;
    [SerializeField]
    List<GameObject> _cloneItem;



    private void Awake()
    {
        if(instance == null) 
            instance = this;
    }

    public void InstatiateItem(List<Period> p) 
    {
        for (int i = 0; i < 7; i++)
        {
            _cloneItem.Add(Instantiate(_itemPrefab, _conteiner.transform));
            if (p[i].isDaytime)
            {
                _cloneItem[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = p[i].name;
                _cloneItem[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = $"Temp: {p[i].temperature} {p[i].temperatureUnit}";
                _cloneItem[i].transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = $"Speed: {p[i].windSpeed} {p[i].windDirection}";
            }
            _cloneItem[i].GetComponent<Item>().AddClick(4,UI_Manager.instance.GetInfoPopapWeather(), false);
        }
    }

    public void DeleteItem()
    {
        if (_cloneItem.Count !=0)
        {
            for (int i = 0; i < 7; i++)
            {
                Destroy(_cloneItem[i]);
            }
            _cloneItem.Clear();
        }        
    }
}
