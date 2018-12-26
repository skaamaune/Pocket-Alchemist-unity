using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabUnlock1 : MonoBehaviour {
    public ClickedTab clickedTab;
    public Adventurer adventurer;
	// Use this for initialization
	void Start () {
        clickedTab = gameObject.GetComponent<ClickedTab>();
    }
	
	// Update is called once per frame
	void Update () {
        if (adventurer.stats.deathCount >= 1)
        {
            clickedTab.unlocked = true;
        }
	}
}
