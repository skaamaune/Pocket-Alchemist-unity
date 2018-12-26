using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionBox : MonoBehaviour {
    public List<Panel> panels;
    public Panel selectedPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PanelClear()
    {
        for (int i = 0; i < panels.Count ; i++)
        {
            panels[i].currentPanel = false;
        }

    }
}
