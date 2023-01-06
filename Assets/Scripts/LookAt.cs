using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("XROrigin");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation =
            Quaternion
                .LookRotation(target.transform.position -
                this.transform.position);
    }
}
