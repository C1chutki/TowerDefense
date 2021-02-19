using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInfoPanelSlide : MonoBehaviour
{
    public GameObject PanelMenu;

    public void ShowHideMenu()
    {
        if (PanelMenu != null)
        {
            Animator animator = PanelMenu.GetComponent<Animator>();
            if (animator != null)
            {
                bool isOpen = animator.GetBool("SlideOut");
                animator.SetBool("SlideOut", !isOpen);
            }
        }
    }
}
