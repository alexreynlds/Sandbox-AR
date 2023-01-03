using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementManager : MonoBehaviour
{
    public GameObject prefab;

    public GameObject spawnedObject;

    public ARRaycastManager arRaycastManager;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    public Camera arCamera;

    private Vector2 touchPosition = default;

    // Start is called before the first frame update
    void Awake()
    {
        arRaycastManager =
            GameObject.Find("XROrigin").GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            Debug.Log(Input.GetTouch(0).position);
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    public void SetPrefab(GameObject newPrefab)
    {
        prefab = newPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }
        if (
            arRaycastManager
                .Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon)
        )
        {
            var hitPose = hits[0].pose;

            Debug.Log (touchPosition);
            if (touchPosition.y > 300)
            {
                if (spawnedObject == null)
                {
                    spawnedObject =
                        Instantiate(prefab, hitPose.position, hitPose.rotation);
                }
                else
                {
                    spawnedObject.transform.position = hitPose.position;
                }
            }
        }
    }
}
