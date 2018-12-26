using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryTab : MonoBehaviour
{
    public Sprite clicked;
    public Sprite unclicked;
    public bool active;
    public InventoryTab consumablesTab;
    public InventoryTab equipmentTab;
    public InventoryTab keyItemTab;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            GetComponent<Image>().sprite = clicked;
        }
        else
        {
            GetComponent<Image>().sprite = unclicked;
        }
    }
    public void OnClick()
    {
        consumablesTab.active = false;
        equipmentTab.active = false;
        keyItemTab.active = false;
        active = true;
    }
}
