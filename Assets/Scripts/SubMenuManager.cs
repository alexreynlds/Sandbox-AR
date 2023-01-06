using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMenuManager : MonoBehaviour
{
    public Animation Anim;

    private List<string> animationNames = new List<string>();

    void Awake()
    {
        Anim = GetComponent<Animation>();
        foreach (AnimationState state in Anim)
        {
            animationNames.Add(state.name);
        }
    }

    public void OpenMenu()
    {
        if (
            GameObject
                .Find("GameManager")
                .GetComponent<GameManagerScript>()
                .PlacementMode
        )
        {
            GameObject
                .Find("GameManager")
                .GetComponent<GameManagerScript>()
                .StopPlacement();
        }

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

        if (this.gameObject.name == "CollectionMenu")
        {
            this
                .gameObject
                .GetComponent<CollectionMenuScript>()
                .RefreshCollection();
        }
        Handheld.Vibrate();
        GameObject.Find("UICanvas").GetComponent<UIManager>().SubMenuOpen =
            true;
        GameObject
            .Find("UICanvas")
            .GetComponent<UIManager>()
            .currentlyOpenMenu = this.gameObject;
        Anim.Play(animationNames[0]);
    }

    public void CloseMenu()
    {
        GameObject.Find("UICanvas").GetComponent<UIManager>().SubMenuOpen =
            false;
        GameObject
            .Find("UICanvas")
            .GetComponent<UIManager>()
            .currentlyOpenMenu = null;
        Anim.Play(animationNames[1]);
    }

    public void SetMenuActive()
    {
        this.gameObject.SetActive(true);
    }

    public void SetMenuInactive()
    {
        this.gameObject.SetActive(false);
    }
}
