using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectionMenuScript : MonoBehaviour
{
    public TMP_Text cardList;

    // Start is called before the first frame update
    void Start()
    {
        RefreshCollection();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private string ListToText(List<DinoCard> list)
    {
        string result = "";

        foreach (var i in list)
        {
            result += i.name + ", ";
        }
        return result;
    }

    public void RefreshCollection()
    {
        cardList.text =
            ListToText(GameObject
                .Find("GameManager")
                .GetComponent<GameManagerScript>()
                .ownedCards);
    }
}
