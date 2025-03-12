using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
class DogData
{
    public string Id;
    public string Type;
    public string Name;
    public string Description;
    [Header("Life")]
    public string Max_life;
    public string Min_life;
    [Header("Male_weight")]
    public string Max_Male_weight;
    public string Min_Male_weight;
    [Header("female_weight")]
    public string Max_female_weight;
    public string Min_female_weight;

    public bool Hypoallergenic;
    [Header("Relationships")]
    public string Id_Relationships;
    public string Type_Relationships;

}

public class DataManager : MonoBehaviour
{
    public static DataManager instance;



    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void AddData_Breeds(string id, string type, string name, string description, string max_life, string min_life, string max_Male_weight, string min_Male_weight, string max_female_weight, string min_female_weight, bool Hypoallergenic, string id_Relationships, string type_Relationships)
    {
        DogData dt = new DogData();
        dt.Id = id;
        dt.Type = type;
        dt.Name = name;
        dt.Description = description;
        dt.Max_life = max_life;
        dt.Min_life = min_life;
        dt.Max_Male_weight = max_Male_weight;
        dt.Min_Male_weight = min_Male_weight;
        dt.Max_female_weight = max_female_weight;
        dt.Min_female_weight = min_female_weight;
        dt.Hypoallergenic = Hypoallergenic;
        dt.Id_Relationships = id_Relationships;
        dt.Type_Relationships = type_Relationships;
        Debug.Log(dt);
    }

    public string GetStringFieldFromJsonData(JObject data, string FieldName, string FieldNameTwo, bool isCay)
    {
        if (isCay)
        {
            try
            {
                return data[FieldName].Value<string>();
            }
            catch
            {
                return "none";
            }
        }
        else
        {
            try
            {
                return data[FieldName][FieldNameTwo].Value<string>();
            }
            catch
            {
                return "none";
            }
        }
    }
    public bool GetBoolFieldFromJsonData(JObject data, string FieldName)
    {
        try
        {
            return data[FieldName].Value<bool>();
        }
        catch
        {
            return false;
        }
    }
}
