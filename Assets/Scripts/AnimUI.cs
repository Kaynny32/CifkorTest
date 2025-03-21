using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimUI : MonoBehaviour
{
    public void ShowUI(bool delayActive = false)
    {
        if (delayActive)
        {
            gameObject.GetComponent<CanvasGroup>().DOKill();
            gameObject.GetComponent<CanvasGroup>().DOFade(1f, 0.25F).SetDelay(0.1f).SetEase(Ease.InOutQuad);
        }
        else { 
            gameObject.GetComponent<CanvasGroup>().DOKill();
            gameObject.GetComponent<CanvasGroup>().DOFade(1f, 0.25F).SetEase(Ease.InOutQuad);
    }
        gameObject.GetComponent<CanvasGroup>().interactable = true;
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void HideUI()
    {
        gameObject.GetComponent<CanvasGroup>().DOKill();
        gameObject.GetComponent<CanvasGroup>().DOFade(0f, 0.25F).SetEase(Ease.InOutQuad);
        gameObject.GetComponent<CanvasGroup>().interactable = false;
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
}
