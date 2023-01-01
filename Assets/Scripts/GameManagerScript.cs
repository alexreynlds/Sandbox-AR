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

    [Header("Placement")]
    [SerializeField]
    public bool PlacementMode;

    [SerializeField]
    public GameObject PlacementPlanePrefab;

    private ARPlaneManager arPlaneManager;

    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<PlacementManager>().enabled = false;
        PlacementMode = false;
    }

    // Update is called once per frame
    public void ResetCollection()
    {
        ownedCards = new List<DinoCard>();
    }

    public void UnlockAll()
    {
        ResetCollection();
        this.gameObject.GetComponent<CardManager>().AddCard("T. Rex");
        this.gameObject.GetComponent<CardManager>().AddCard("Triceratops");
        this.gameObject.GetComponent<CardManager>().AddCard("Pyroraptor");
        this.gameObject.GetComponent<CardManager>().AddCard("Therizinisaurus");
        this.gameObject.GetComponent<CardManager>().AddCard("Quetzalcoatlus");
    }

    public void TogglePlacement()
    {
        if (PlacementMode)
        {
            StopPlacement();
        }
        else
        {
            StartPlacement();
        }
    }

    public void StartPlacement()
    {
        arPlaneManager =
            GameObject.Find("XROrigin").AddComponent<ARPlaneManager>();
        arPlaneManager.planePrefab = PlacementPlanePrefab;

        arPlaneManager.enabled = true;
        GetComponent<PlacementManager>().enabled = true;
        GameObject.Find("PlaceButton").GetComponent<Image>().color =
            Color.green;
        PlacementMode = true;
    }

    public void StopPlacement()
    {
        foreach (ARPlane plane in arPlaneManager.trackables)
        {
            Destroy(plane.gameObject);
        }
        Destroy (arPlaneManager);
        GameObject.Find("AR Session").GetComponent<ARSession>().Reset();
        GetComponent<PlacementManager>().enabled = false;
        GameObject.Find("PlaceButton").GetComponent<Image>().color =
            Color.white;
        PlacementMode = false;
    }
}
