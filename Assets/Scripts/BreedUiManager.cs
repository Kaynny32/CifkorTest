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


    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void InstatiateItem(int count, List<BreedClass> id)
    {
        for (int i = 0; i< count; i++)
        {
            _cloneItem.Add(Instantiate(_itemPrefab, _conteiner.transform));
            _cloneItem[i].GetComponent<Item>().SetId(id[i].id);
            _cloneItem[i].GetComponent<Item>().SetName(id[i].attributes.name);
            _cloneItem[i].GetComponent<Item>().SetDescription(id[i].attributes.description);

            _cloneItem[i].GetComponent<Item>().Set_life(id[i].attributes.life.min.ToString(), id[i].attributes.life.max.ToString());
            _cloneItem[i].GetComponent<Item>().Set_male_weight(id[i].attributes.male_weight.min.ToString(), id[i].attributes.male_weight.max.ToString());
            _cloneItem[i].GetComponent<Item>().Set_female_weight(id[i].attributes.female_weight.min.ToString(), id[i].attributes.female_weight.max.ToString());

            _cloneItem[i].GetComponent<Item>().Set_Hypoallergenic(id[i].attributes.hypoallergenic);

            _cloneItem[i].GetComponent<Item>().AddClick(1,UI_Manager.instance.GetInfoPopapBreed());
            _cloneItem[i].gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = (i + 1).ToString();
            _cloneItem[i].gameObject.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = id[i].attributes.name;           
        }        
    }

    public void DeleteItem()
    {
        for (int i = 0; i< _cloneItem.Count; i++)        
        {
            Destroy(_cloneItem[i]);            
        }
        _cloneItem.Clear();
    }
}