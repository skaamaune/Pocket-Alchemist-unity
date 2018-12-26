using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabManager : MonoBehaviour {
    public int tabClicked;
    public ClickedTab[] tab;
    public Menu[] menu;
    public List<VisibleManager> visible;


    // make the tab (decided by tabset) stick out, actual game will refer to tabset for what tab is selected
    public void Click()
    {
        CheckTabs();
        VisibleManagerCheck();
	}

    public void CheckTabs()
    {
        for (int i = 0; i < tab.Length; i++)
        {
            if (tab[i].justClicked == true && tab[i].unlocked)
            {
                tabClicked = i;
                tab[i].justClicked = false;
                for (int f = 0; f < tab.Length; f++)
                {
                    tab[f].activeTab = false;
                    if (f != 0)
                    {
                        menu[f].gameObject.SetActive(false);
                    }
                }
                tab[i].activeTab = true;
                menu[i].gameObject.SetActive(true);
                break;
            }
        }

    }
    public void VisibleManagerCheck()
    {
        for (int i = 0; i < visible.Count; i++)
        { 
            for (int f = 0; f < visible[i].images.Count; f++)
            {
                if (visible[i].tabNumber == tabClicked)
                {
                    visible[i].images[f].enabled = true;
                }
                else
                {
                    visible[i].images[f].enabled = false;
                }
            }
        }
    }
}
