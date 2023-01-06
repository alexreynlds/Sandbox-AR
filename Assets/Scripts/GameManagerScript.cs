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

    public GameObject testerPrefab;

    public GameObject placementUI;

    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<PlacementManager>().enabled = false;
        PlacementMode = false;
    }

    // Update is called once per frame
    public void ResetCollection()
    {
        Handheld.Vibrate();
        ownedCards = new List<DinoCard>();
    }

    public void UnlockAll()
    {
        Handheld.Vibrate();
        ResetCollection();
        this.gameObject.GetComponent<CardManager>().AddCard("T. Rex");
        this.gameObject.GetComponent<CardManager>().AddCard("Triceratops");
        this.gameObject.GetComponent<CardManager>().AddCard("Pyroraptor");
        this.gameObject.GetComponent<CardManager>().AddCard("Therizinisaurus");
        this.gameObject.GetComponent<CardManager>().AddCard("Quetzalcoatlus");
    }

    public void TogglePlacement(GameObject testerPrefab)
    {
        if (PlacementMode)
        {
            StopPlacement();
        }
        else
        {
            if (
                GameObject
                    .Find("UICanvas")
                    .GetComponent<UIManager>()
                    .currentlyOpenMenu !=
                null
            )
            {
                GameObject
                    .Find("UICanvas")
                    .GetComponent<UIManager>()
                    .currentlyOpenMenu
                    .GetComponent<SubMenuManager>()
                    .CloseMenu();
            }
            if (
                GameObject
                    .Find("XROrigin")
                    .GetComponent<ScanningScript>()
                    .Scanning
            )
            {
                GameObject
                    .Find("XROrigin")
                    .GetComponent<ScanningScript>()
                    .StopScanning();
            }
            StartPlacement (testerPrefab);
        }
    }

    public void StartPlacement(GameObject prefab)
    {
        placementUI.SetActive(true);
        arPlaneManager =
            GameObject.Find("XROrigin").AddComponent<ARPlaneManager>();
        arPlaneManager.planePrefab = PlacementPlanePrefab;

        arPlaneManager.requestedDetectionMode = PlaneDetectionMode.Horizontal;
        arPlaneManager.enabled = true;
        GetComponent<PlacementManager>().enabled = true;
        GetComponent<PlacementManager>().SetPrefab(prefab);
        GameObject.Find("PlaceButton").GetComponent<Image>().color =
            Color.green;
        PlacementMode = true;
    }

    public void StopPlacement()
    {
        placementUI.SetActive(false);
        foreach (ARPlane plane in arPlaneManager.trackables)
        {
            Destroy(plane.gameObject);
        }
        Destroy (arPlaneManager);
        Destroy(this.gameObject.GetComponent<PlacementManager>().spawnedObject);
        GameObject.Find("AR Session").GetComponent<ARSession>().Reset();
        GetComponent<PlacementManager>().enabled = false;
        GameObject.Find("PlaceButton").GetComponent<Image>().color =
            Color.white;
        PlacementMode = false;
    }
}
