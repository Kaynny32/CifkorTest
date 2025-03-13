using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class BreedUiManager : MonoBehaviour
{
    public static BreedUiManager instance;

    [SerializeField]
    GameObject _conteiner;
    [SerializeField]
    GameObject _itemPrefab;
    [SerializeField]
    List<GameObject> _cloneItem;


    int _countBreed;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void InstatiateItem(int count, List<BreedClass> id)
    {
        _countBreed = count;
        for (int i = 0; i< count; i++)
        {
            _cloneItem.Add(Instantiate(_itemPrefab, _conteiner.transform));
            _cloneItem[i].gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = id[i].id;
            _cloneItem[i].gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = (i + 1).ToString();
            _cloneItem[i].gameObject.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = id[i].attributes.name;
            _cloneItem[i].gameObject.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() => {
                UI_Manager.instance.InfoPopap.GetComponent<AnimUI>().ShowUI(false);
                //UI_Manager.instance.InfoPopap.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = $"id[{i}].attributes.description";
            }); 
        }        
    }

    public void DeleteItem()
    {
        --_countBreed;
        for (int i = 0; i< _countBreed; i++)        
        {
            Destroy(_cloneItem[i]);            
        }
        _cloneItem.Clear();
    }
}
