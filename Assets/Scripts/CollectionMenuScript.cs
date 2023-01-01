using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectionMenuScript : MonoBehaviour
{
    public TMP_Text cardList;

    public GameObject DisplayBox;

    public GameObject DisplayButtons;

    public GameObject GameManager;

    public int CardIndex;

    void Awake()
    {
        GameManager = GameObject.Find("GameManager");
        CardIndex = 0;
    }

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
        if (GameManager.GetComponent<GameManagerScript>().ownedCards.Count > 0)
        {
            DisplayBox.SetActive(true);
            DisplayButtons.SetActive(true);
            cardList.enabled = false;
            DisplayBox
                .GetComponent<DisplayBoxScript>()
                .DisplayCard(GameManager
                    .GetComponent<GameManagerScript>()
                    .ownedCards[0]);
        }
        else
        {
            cardList.enabled = true;
            DisplayBox.SetActive(false);
            DisplayButtons.SetActive(false);
            cardList.text = "No cards yet!";
        }
    }

    public void ShowNextCard()
    {
        CardIndex++;
        if (
            CardIndex >=
            GameManager.GetComponent<GameManagerScript>().ownedCards.Count
        )
        {
            CardIndex = 0;
        }
        DisplayBox
            .GetComponent<DisplayBoxScript>()
            .DisplayCard(GameManager
                .GetComponent<GameManagerScript>()
                .ownedCards[CardIndex]);
    }

    public void ShowPrevCard()
    {
        CardIndex--;
        if (CardIndex < 0)
        {
            CardIndex =
                GameManager.GetComponent<GameManagerScript>().ownedCards.Count -
                1;
        }
        DisplayBox
            .GetComponent<DisplayBoxScript>()
            .DisplayCard(GameManager
                .GetComponent<GameManagerScript>()
                .ownedCards[CardIndex]);
    }
}
