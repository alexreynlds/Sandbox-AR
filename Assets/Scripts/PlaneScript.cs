using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        if (
            GameObject
                .Find("GameManager")
                .GetComponent<GameManagerScript>()
                .scanningVideo
                .activeSelf
        )
        {
            GameObject
                .Find("GameManager")
                .GetComponent<GameManagerScript>()
                .scanningVideo
                .SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
