using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public List<DinoCard> ownedCards = new List<DinoCard>();

    // Start is called before the first frame update
    void Awake()
    {
        // ownedCards.Add(new DinoCard("T-Rex", "Big and scary"));
    }

    // Update is called once per frame
    void Update()
    {
    }
}
