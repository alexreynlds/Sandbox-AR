using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public List<Sprite> dinoImages;

    public List<GameObject> dinoPrefabs;

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
                    "King of the tyrant lizards!",
                    dinoImages[0],
                    "Carnivore",
                    "12 feet",
                    "Threopod",
                    "Western NA",
                    dinoPrefabs[0]));
        }

        if (cardName == "Triceratops")
        {
            Debug.Log("Adding card: Trike");
            GameObject
                .Find("GameManager")
                .GetComponent<GameManagerScript>()
                .ownedCards
                .Add(new DinoCard("Triceratops",
                    "Three-horned face!",
                    dinoImages[1],
                    "Herbivore",
                    "9 feet",
                    "Chasmosaurinae",
                    "NA",
                    dinoPrefabs[1]));
        }

        if (cardName == "Pyroraptor")
        {
            GameObject
                .Find("GameManager")
                .GetComponent<GameManagerScript>()
                .ownedCards
                .Add(new DinoCard("Pyroraptor",
                    "Fire Thief!",
                    dinoImages[2],
                    "Carnivore",
                    "5.57 feet",
                    "Theropod",
                    "S France",
                    dinoPrefabs[3]));
        }

        if (cardName == "Therizinisaurus")
        {
            GameObject
                .Find("GameManager")
                .GetComponent<GameManagerScript>()
                .ownedCards
                .Add(new DinoCard("Therizinisaurus",
                    "Scythe Lizard!",
                    dinoImages[3],
                    "Herbivore",
                    "9.8 feet",
                    "Theropod",
                    "Mongolia",
                    dinoPrefabs[2]));
        }

        if (cardName == "Quetzalcoatlus")
        {
            GameObject
                .Find("GameManager")
                .GetComponent<GameManagerScript>()
                .ownedCards
                .Add(new DinoCard("Quetzalcoatlus",
                    "Aztec Feathered Serpent God!",
                    dinoImages[4],
                    "Carnivore",
                    "16 feet",
                    "Pterosaur",
                    "Southern NA",
                    dinoPrefabs[4]));
        }
    }
}
