using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager instance;

    [SerializeField]
    GameObject PopaplWeather;
    [SerializeField]
    GameObject PopaplDog;
    [SerializeField]
    GameObject InfoPopapBreed;


    [SerializeField]
    GameObject blockBtnWeather;
    [SerializeField]
    GameObject blockBtnBreed;


    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        PopaplWeather.GetComponent<AnimUI>().ShowUI(false);
    }

    public GameObject GetInfoPopapBreed()
    {
        return InfoPopapBreed;
    }
    public void GetInfoPopapWeather()
    {
      //  return InfoPopapWeather;
    }

    public GameObject GetBlockBtnWeather()
    {
        return blockBtnWeather;
    }
    public GameObject GetBlockBtnBreedr()
    {
        return blockBtnBreed;
    }

    public void UnBlockBtn(GameObject go)
    { 
        go.SetActive(false);
    }
}
