using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class BreedClass
{
    public BreedClass()
    {
    }
    public BreedClass(string id, string type, Attributes attributes, Relationships relationships)
    {
        this.id = id;
        this.type = type;
        this.attributes = attributes;
        this.relationships = relationships;
    }

    public string id { get; set; }
    public string type { get; set; }
    public Attributes attributes { get; set; }
    public Relationships relationships { get; set; }
}

public class Attributes
{
    public Attributes(string name, string description, Life life, MaleWeight male_weight, FemaleWeight female_weight, bool hypoallergenic)
    {
        this.name = name;
        this.description = description;
        this.life = life;
        this.male_weight = male_weight;
        this.female_weight = female_weight;
        this.hypoallergenic = hypoallergenic;
    }

    public string name { get; set; }
    public string description { get; set; }
    public Life life { get; set; }
    public MaleWeight male_weight { get; set; }
    public FemaleWeight female_weight { get; set; }
    public bool hypoallergenic { get; set; }
}

public class Life
{
    public Life(int min, int max)
    {
        this.min = min;
        this.max = max;
    }

    public int min { get; set; }
    public int max { get; set; }
}

public class MaleWeight
{
    public MaleWeight(int min, int max)
    {
        this.min = min;
        this.max = max;
    }

    public int min { get; set; }
    public int max { get; set; }
}

public class FemaleWeight
{
    public FemaleWeight(int min, int max)
    {
        this.min = min;
        this.max = max;
    }

    public int min { get; set; }
    public int max { get; set; }
}

public class Relationships
{
    public Relationships(string id, string type)
    {
        this.id = id;
        this.type = type;
    }

    public string id { get; set; }
    public string type { get; set; }
}