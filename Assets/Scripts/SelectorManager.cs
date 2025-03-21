using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorManager : MonoBehaviour
{
    [SerializeField]
    SelectorBtnAnimator[] _btns;



    public void BntOnClick(int index)
    {
        foreach (SelectorBtnAnimator btn in _btns)
        {
            btn.OnDeselect();
        }
        _btns[index].OnSelect();
    }


}
