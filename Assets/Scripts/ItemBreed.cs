using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemBreed : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _index, _name;
    [SerializeField]
    int _i;

    public void SetInfo(int _i,int _index, string _name)
    {
        this._i = _i;
        this._index.text = _index.ToString();
        this._name.text = _name;
    }
    public void OnClick()
    {
        BreedUiManager.instance.ShowPopUpById(_i);
    }
}
