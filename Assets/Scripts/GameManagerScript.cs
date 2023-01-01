using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class GameManagerScript : MonoBehaviour
{
    public List<DinoCard> ownedCards = new List<DinoCard>();

    // Start is called before the first frame update
    void Awake()
    {
        // ownedCards.Add(new DinoCard("T-Rex", "Big and scary"));
        this.gameObject.GetComponent<CardManager>().AddCard("T. Rex");
        this.gameObject.GetComponent<CardManager>().AddCard("Triceratops");
        this.gameObject.GetComponent<CardManager>().AddCard("Pyroraptor");
        this.gameObject.GetComponent<CardManager>().AddCard("Therizinisaurus");
        this.gameObject.GetComponent<CardManager>().AddCard("Quetzalcoatlus");
    }

    // Update is called once per frame
    public void ResetCollection()
    {
        ownedCards = new List<DinoCard>();
        // GameObject.Find("XROrigin").GetComponent<ScanningScript>().ResetTest();
    }
}
