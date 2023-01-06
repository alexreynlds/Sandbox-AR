using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayBoxScript : MonoBehaviour
{
    public DinoCard currentCard;

    public void DisplayCard(DinoCard card)
    {
        currentCard = card;
        this.transform.Find("DinoImage").GetComponent<Image>().sprite =
            card.image;
        this.transform.Find("DinoName").GetComponent<TMP_Text>().text =
            card.name;
        this.transform.Find("DinoType").GetComponent<TMP_Text>().text =
            card.type;

        if (card.type == "Herbivore")
        {
            this.transform.Find("DinoType").GetComponent<TMP_Text>().color =
                Color.green;
        }
        else if (card.type == "Carnivore")
        {
            this.transform.Find("DinoType").GetComponent<TMP_Text>().color =
                Color.red;
        }
        else if (card.type == "Omnivore")
        {
            this.transform.Find("DinoType").GetComponent<TMP_Text>().color =
                Color.yellow;
        }
        else
        {
            this.transform.Find("DinoType").GetComponent<TMP_Text>().color =
                Color.white;
        }

        this.transform.Find("DinoHeight").GetComponent<TMP_Text>().text =
            card.height;

        this.transform.Find("DinoClade").GetComponent<TMP_Text>().text =
            card.clade;

        this.transform.Find("DinoLocation").GetComponent<TMP_Text>().text =
            card.location;

        this.transform.Find("DinoDescription").GetComponent<TMP_Text>().text =
            card.desc;
    }

    public void spawnDino()
    {
        Handheld.Vibrate();
        GameObject
            .Find("GameManager")
            .GetComponent<GameManagerScript>()
            .TogglePlacement(currentCard.prefab);
        GameObject
            .Find("CollectionMenu")
            .GetComponent<SubMenuManager>()
            .CloseMenu();
    }
}
