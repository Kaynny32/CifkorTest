using DG.Tweening;
using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectorBtnAnimator : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _btnText;

  
    Image _btnBg;

    [SerializeField]
    Color _textIdleColor, _textSelectColor, _bgIdleColor, _bgSelectColor;

    private void Start()
    {
        _btnBg = GetComponent<Image>();
    }

    public void OnSelect()
    {
        _btnText.DOKill();
        _btnText.DOColor(_textSelectColor, 0.2f);

        _btnBg.DOKill();
        _btnBg.DOColor(_bgSelectColor, 0.2f);

        
        GetComponent<Button>().interactable = false;
    }


    public void OnDeselect()
    {
        _btnText.DOKill();
        _btnText.DOColor(_textIdleColor, 0.2f);

        _btnBg.DOKill();
        _btnBg.DOColor(_bgIdleColor, 0.2f);

        GetComponent<Button>().interactable = true;
    }


}
