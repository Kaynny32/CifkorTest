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


    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        PopaplWeather.GetComponent<AnimUI>().ShowUI(false);
    }
}
