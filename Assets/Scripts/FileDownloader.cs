using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class FileDownloader : MonoBehaviour
{
    public static FileDownloader instance;

    [SerializeField]
    RawImage _rawImageDay;
    [SerializeField]
    RawImage _rawImageNight;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void StartLoadImage(string urlDay, string urlNight)
    { 
        StartCoroutine(LoadImage(urlDay, _rawImageDay));
        StartCoroutine(LoadImage(urlNight, _rawImageNight));
    }

    IEnumerator LoadImage(string url, RawImage image)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();
        if (request.isDone == false)
            Debug.Log(request.error);
        else
        {
            Texture texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            image.texture = (Texture2D)texture;
        }
    }

    public void RestImageTexture(RawImage image)
    {
        image.texture = null;
    }
}
