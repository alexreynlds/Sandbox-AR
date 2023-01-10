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

    public AnimationClip SuccessMenuShow;

    public AnimationClip SuccessMenuHide;

    public Animation anim;

    public bool SubMenuOpen;

    public GameObject currentlyOpenMenu;

    public GameObject XROrigin;

    [Header("Scanning Screens")]
    public GameObject successScreen;

    public GameObject failureScreen;

    public GameObject successPopup;

    public GameObject failurePopup;

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
            XROrigin.GetComponent<ScanningScript>().StopScanning(0);
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

    public void showSuccessPopup()
    {
        var newSuccessPopup =
            Instantiate(successPopup,
            new Vector3(transform.position.x,
                transform.position.y,
                transform.position.z),
            Quaternion.identity);
        newSuccessPopup.transform.SetParent(this.gameObject.transform);
    }

    public void showFailurePopup()
    {
        var newFailurePopup =
            Instantiate(failurePopup,
            new Vector3(transform.position.x,
                transform.position.y,
                transform.position.z),
            Quaternion.identity);
        newFailurePopup.transform.SetParent(this.gameObject.transform);
    }
}
