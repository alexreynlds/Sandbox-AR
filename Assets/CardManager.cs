using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public List<Sprite> dinoImages;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AddCard(string cardName)
    {
        if (cardName == "T. Rex")
        {
            Debug.Log("Adding card: TREX");
            GameObject
                .Find("GameManager")
                .GetComponent<GameManagerScript>()
                .ownedCards
                .Add(new DinoCard("T. Rex",
                    "Big and scary",
                    dinoImages[0],
                    "Carnivore",
                    "12 feet"));
        }

        if (cardName == "Triceratops")
        {
            Debug.Log("Adding card: Trike");
            GameObject
                .Find("GameManager")
                .GetComponent<GameManagerScript>()
                .ownedCards
                .Add(new DinoCard("Triceratops",
                    "Triple the damage!",
                    dinoImages[1],
                    "Herbivore",
                    "9 feet"));
        }

        if (cardName == "Pyroraptor")
        {
            GameObject
                .Find("GameManager")
                .GetComponent<GameManagerScript>()
                .ownedCards
                .Add(new DinoCard("Pyroraptor",
                    "Small and deadly!",
                    dinoImages[2],
                    "Carnivore",
                    "5.57 feet"));
        }

        if (cardName == "Therizinisaurus")
        {
            GameObject
                .Find("GameManager")
                .GetComponent<GameManagerScript>()
                .ownedCards
                .Add(new DinoCard("Therizinisaurus",
                    "Bastard",
                    dinoImages[3],
                    "Herbivore",
                    "9.8 feet"));
        }

        if (cardName == "Quetzalcoatlus")
        {
            GameObject
                .Find("GameManager")
                .GetComponent<GameManagerScript>()
                .ownedCards
                .Add(new DinoCard("Quetzalcoatlus",
                    "As weird as its name",
                    dinoImages[4],
                    "Carnivore",
                    "16 feet"));
        }
    }
}
