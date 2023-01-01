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
        if (this.gameObject.name == "CollectionMenu")
        {
            this
                .gameObject
                .GetComponent<CollectionMenuScript>()
                .RefreshCollection();
        }
        GameObject.Find("UICanvas").GetComponent<UIManager>().SubMenuOpen =
            true;
        Anim.Play(animationNames[0]);
    }

    public void CloseMenu()
    {
        GameObject.Find("UICanvas").GetComponent<UIManager>().SubMenuOpen =
            false;
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
