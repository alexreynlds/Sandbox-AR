using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ScanningScript : MonoBehaviour
{
    [SerializeField]
    ARTrackedImageManager m_TrackedImageManager;

    [SerializeField]
    XRReferenceImageLibrary m_ReferenceLibrary;

    public List<Texture2D> cardImages = new List<Texture2D>();

    [SerializeField]
    private GameObject scanningUI;

    public bool Scanning;

    void Awake()
    {
        m_TrackedImageManager =
            gameObject.AddComponent<ARTrackedImageManager>();
        m_TrackedImageManager.referenceLibrary =
            m_TrackedImageManager.CreateRuntimeLibrary(m_ReferenceLibrary);
        m_TrackedImageManager.requestedMaxNumberOfMovingImages = 1;

        m_TrackedImageManager.enabled = false;
    }

    void Start()
    {
        Scanning = false;
    }

    // public void ToggleScan()
    // {
    //     if (Scanning)
    //     {
    //         StopScanning();
    //     }
    //     else
    //     {
    //         StartScanning();
    //     }
    // }
    public void StartScanning()
    {
        CreateLibrary();
        m_TrackedImageManager.enabled = true;
        Scanning = true;
        scanningUI.SetActive(true);

        m_TrackedImageManager.trackedImagesChanged += OnChanged;
    }

    public void StopScanning()
    {
        m_TrackedImageManager.trackedImagesChanged -= OnChanged;

        m_TrackedImageManager.enabled = false;
        Scanning = false;
        scanningUI.SetActive(false);
    }

    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var newImage in eventArgs.added)
        {
            bool found = false;

            if (
                GameObject
                    .Find("GameManager")
                    .GetComponent<GameManagerScript>()
                    .ownedCards
                    .Count >
                0
            )
            {
                foreach (DinoCard
                    card
                    in
                    GameObject
                        .Find("GameManager")
                        .GetComponent<GameManagerScript>()
                        .ownedCards
                )
                {
                    if (card.name == newImage.referenceImage.name)
                    {
                        found = true;
                    }
                }
            }

            if (!found)
            {
                Debug.Log("Debug >> Added: " + newImage.referenceImage.name);
                GameObject
                    .Find("GameManager")
                    .GetComponent<CardManager>()
                    .AddCard(newImage.referenceImage.name);

                StopScanning();
            }
            if (found)
            {
                Debug
                    .Log("Debug >> Already owned: " +
                    newImage.referenceImage.name);

                StopScanning();
            }
        }

        // FIGURE OUT A WAY TO REMOVE THE IMAGE FROM THE EVENT ARGS LIST
    }

    public void CreateLibrary()
    {
        var library = m_TrackedImageManager.CreateRuntimeLibrary();

        if (
            m_TrackedImageManager.referenceLibrary is
            MutableRuntimeReferenceImageLibrary mutableLibrary
        )
        {
            Debug.Log("Library Created");
            foreach (Texture2D image in cardImages)
            {
                mutableLibrary
                    .ScheduleAddImageWithValidationJob(image, image.name, 0.2f);
                Debug.Log("added>> " + image.name);
            }
            m_TrackedImageManager.referenceLibrary = mutableLibrary;
        }
    }
}
