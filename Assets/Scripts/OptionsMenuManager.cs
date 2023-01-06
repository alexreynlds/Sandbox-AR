using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuManager : MonoBehaviour
{
    public Toggle hapticToggle;

    // Start is called before the first frame update
    void Start()
    {
        hapticToggle = GameObject.Find("HapticToggle").GetComponent<Toggle>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ToggleHapticFeedback()
    {
        if (hapticToggle.isOn)
        {
            GameObject
                .Find("GameManager")
                .GetComponent<GameManagerScript>()
                .HapticFeedback = true;
        }
        else
        {
            GameObject
                .Find("GameManager")
                .GetComponent<GameManagerScript>()
                .HapticFeedback = false;
        }
    }
}
