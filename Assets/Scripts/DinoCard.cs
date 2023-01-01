using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DinoCard
{
    public string name;

    public string desc;

    public string type;

    public string height;

    public Sprite image;

    public string clade;

    public string location;

    public DinoCard(
        string name,
        string description,
        Sprite image,
        string type,
        string height,
        string clade,
        string location
    )
    {
        this.type = type;
        this.name = name;
        this.desc = description;
        this.image = image;
        this.height = height;
        this.clade = clade;
        this.location = location;
    }
}
