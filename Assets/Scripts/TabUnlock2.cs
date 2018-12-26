using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabUnlock2 : MonoBehaviour
{
    public ClickedTab clickedTab;
    public Adventurer adventurer;
    // Use this for initialization
    void Start()
    {
        clickedTab = gameObject.GetComponent<ClickedTab>();
    }

    // Update is called once per frame
    void Update()
    {
        if (adventurer.stats.levelsBeaten >= 1)
        {
            clickedTab.unlocked = true;
        }
    }
}
