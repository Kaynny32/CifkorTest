using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimUI : MonoBehaviour
{
    public void ShowUI(bool delayActive = false)
    {
       if (delayActive)
            gameObject.GetComponent<CanvasGroup>().DOFade(1,0.75F).SetDelay(0.1f).SetEase(Ease.InOutExpo);
       else
            gameObject.GetComponent<CanvasGroup>().DOFade(1, 0.75F).SetEase(Ease.InOutExpo);
        gameObject.GetComponent<CanvasGroup>().interactable = true;
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void HideUI()
    {
        gameObject.GetComponent<CanvasGroup>().DOFade(0, 0.1F).SetEase(Ease.InOutExpo);
        gameObject.GetComponent<CanvasGroup>().interactable = false;
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
}
