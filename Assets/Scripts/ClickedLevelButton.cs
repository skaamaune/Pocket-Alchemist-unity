using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickedLevelButton : MonoBehaviour {
    public LevelManager levelManager;
    public TabManager tabMananager;
    public Image visible;
    public bool justClicked;
    public bool activeLevel;

    private void Start()
    {
        visible = GetComponent<Image>();
        levelManager = gameObject.GetComponentInParent<LevelManager>();
        tabMananager = levelManager.tabManager;
    }
    // Update is called once per frame

    private void Update()
    {
        if (levelManager.levelActive == false && tabMananager.tabClicked == 0)
        {
            //justClicked = false;
            visible.enabled = true;
        }
        else
        {
            visible.enabled = false;
        }
    }

    public void Clicked()
    {
        justClicked = true;
    }
}
