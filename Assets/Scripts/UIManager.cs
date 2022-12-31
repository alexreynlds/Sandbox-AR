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

    // Start is called before the first frame update
    void Start()
    {
        menuOpen = false;
        anim = GetComponent<Animation>();
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
        else
        {
            menu.SetActive(true);
            menu.GetComponent<SubMenuManager>().OpenMenu();
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
        // anim.clip = openMenuAnimation;
        // anim.Play();
        anim.Play("OpenMenu");
        menuOpen = true;
    }

    private void closeMenu()
    {
        // anim.clip = closeMenuAnimation;
        // anim.Play();
        anim.Play("CloseMenu");
        menuOpen = false;
    }
}
