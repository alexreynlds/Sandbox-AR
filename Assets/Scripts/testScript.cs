using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class testScript : MonoBehaviour
{
    [SerializeField]
    ARTrackedImageManager m_TrackedImageManager;

    void Awake()
    {
        m_TrackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    void OnEnable() => m_TrackedImageManager.trackedImagesChanged += OnChanged;

    void OnDisable() => m_TrackedImageManager.trackedImagesChanged -= OnChanged;

    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var newImage in eventArgs.added)
        {
            Debug.Log("Debug >> Added: " + newImage.referenceImage.name);
            GameObject
                .Find("GameManager")
                .GetComponent<GameManagerScript>()
                .ownedCards
                .Add(new DinoCard(newImage.referenceImage.name,
                    "Big and scary"));
        }

        foreach (var updatedImage in eventArgs.updated)
        {
            // Handle updated event
            Debug.Log("Debug >> Updated: " + updatedImage.referenceImage.name);
        }

        foreach (var removedImage in eventArgs.removed)
        {
            // Handle removed event
            Debug.Log("Debug >> Removed: " + removedImage.referenceImage.name);
        }
    }
}
