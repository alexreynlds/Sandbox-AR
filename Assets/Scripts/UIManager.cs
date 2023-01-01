using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private bool menuOpen;

    public AnimationClip openMenuAnimation;

    public AnimationClip closeMenuAnimation;

    public Animation anim;

    public bool SubMenuOpen;

    public GameObject currentlyOpenMenu;

    public GameObject XROrigin;

    // Start is called before the first frame update
    void Start()
    {
        menuOpen = false;
        anim = GetComponent<Animation>();
        SubMenuOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void toggleSubMenu(GameObject menu)
    {
        if (menu.activeSelf)
        {
            menu.GetComponent<SubMenuManager>().CloseMenu();
        }
        if (!menu.activeSelf)
        {
            menu.SetActive(true);
            menu.GetComponent<SubMenuManager>().OpenMenu();
        }
    }

    public void toggleScan()
    {
        if (XROrigin.GetComponent<ScanningScript>().Scanning)
        {
            XROrigin.GetComponent<ScanningScript>().StopScanning();
        }
        else
        {
            if (currentlyOpenMenu != null)
            {
                currentlyOpenMenu.GetComponent<SubMenuManager>().CloseMenu();
            }
            XROrigin.GetComponent<ScanningScript>().StartScanning();
        }
    }

    public void toggleMenu()
    {
        if (menuOpen)
        {
            closeMenu();
        }
        else
        {
            openMenu();
        }
    }

    private void openMenu()
    {
        anim.Play("OpenMenu");
        menuOpen = true;
    }

    private void closeMenu()
    {
        anim.Play("CloseMenu");
        menuOpen = false;
    }
}
