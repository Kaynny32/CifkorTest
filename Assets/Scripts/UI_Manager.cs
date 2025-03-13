using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager instance;

    [SerializeField]
    GameObject PapelWeather;
    [SerializeField]
    GameObject PapelDog;

    public GameObject InfoPopap;


    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        PapelWeather.GetComponent<AnimUI>().ShowUI(false);
    }
}
