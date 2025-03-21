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
    TextMeshProUGUI _lifeMin, _lifeMax, _maleMin, _maleMax, _femaleMin, _femaleMax, _description, _name;
    [SerializeField]
    Toggle _hypoallergenic;

    [SerializeField]
    GameObject _itemPrefab, _itemParent;

    [SerializeField]
    AnimUI _puInfo, _closeBtn;

    List<ItemBreedClass> itemBreedClasses = new List<ItemBreedClass>();
    [SerializeField]
    List<ItemBreed> itemBreeds = new List<ItemBreed>();
    

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }


    public void AddDataUI(List<BreedClass> breeds)
    {

        foreach (ItemBreed breed in itemBreeds) {
            Destroy(breed.gameObject);
        }

        itemBreeds.Clear();


        ItemBreed itemBreed;
        
        for (int i = 0; i< breeds.Count; i++)
        {
            ItemBreedClass itemBreedClass = new ItemBreedClass();
            itemBreed = Instantiate(_itemPrefab, _itemParent.transform).GetComponent<ItemBreed>();
            itemBreed.SetInfo(i,i+1, breeds[i].attributes.name);

            itemBreedClass._lifeMin = breeds[i].attributes.life.min.ToString();
            itemBreedClass._lifeMax = breeds[i].attributes.life.max.ToString();
            itemBreedClass._maleMin = breeds[i].attributes.male_weight.min.ToString();
            itemBreedClass._maleMax = breeds[i].attributes.male_weight.max.ToString();
            itemBreedClass._femaleMin = breeds[i].attributes.female_weight.min.ToString();
            itemBreedClass._femaleMax = breeds[i].attributes.female_weight.max.ToString();
            itemBreedClass._description = breeds[i].attributes.description.ToString();
            itemBreedClass._name = breeds[i].attributes.name.ToString();
            itemBreedClass._hypoallergenic = breeds[i].attributes.hypoallergenic;
            this.itemBreedClasses.Add(itemBreedClass);
            itemBreeds.Add(itemBreed);
        }
    }



    public void ShowPopUpById(int index)
    {        
        ItemBreedClass itemBreedClass = itemBreedClasses[index];
        _lifeMin.text = itemBreedClass._lifeMin;
        _lifeMax.text = itemBreedClass._lifeMax;
        _maleMin.text = itemBreedClass._maleMin;
        _maleMax.text = itemBreedClass._maleMax;
        _femaleMin.text = itemBreedClass._femaleMin;
        _femaleMax.text = itemBreedClass._femaleMax;
        _description.text = itemBreedClass._description;
        _name.text = itemBreedClass._name;
        _hypoallergenic.isOn = itemBreedClass._hypoallergenic;
        _closeBtn.ShowUI();
        _puInfo.ShowUI();
    }
}