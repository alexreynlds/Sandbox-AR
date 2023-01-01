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

    public DinoCard(
        string name,
        string description,
        Sprite image,
        string type,
        string height
    )
    {
        this.type = type;
        this.name = name;
        this.desc = description;
        this.image = image;
        this.height = height;
    }
}
