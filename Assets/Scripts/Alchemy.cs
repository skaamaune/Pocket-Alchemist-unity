using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alchemy : MonoBehaviour {
    public Inventory inventory;
    public PotionBox potionBox;
    public MouseCheck mouseCheck;
    public bool test;
    public RectTransform rect;
    public Vector3 scale;
    public int counter;
    public int number;
    
    // Update is called once per frame
    private void Start()
    {
        scale = rect.transform.localScale;
    }
    void Update () {
		if(mouseCheck.mouseDown)
        {
            rect.transform.localScale = new Vector3(scale.x * .9f, scale.y * .9f, 1);
        }
        else
        {
            rect.transform.localScale = scale;
        }
	}
    public void PotionMake()
    {
        for(int i= 0; i < potionBox.selectedPanel.ingredients.Length; i++)
        {
        if (inventory.ingredientAmount[potionBox.selectedPanel.ingredients[i].number] >= inventory.potion[potionBox.selectedPanel.panelNumber].ingredientAmountsNeeded[i])
            {
                counter++;
            }
        }
        if(counter == potionBox.selectedPanel.ingredients.Length)
        {
            for (int i = 0; i < potionBox.selectedPanel.ingredients.Length; i++)
            {
                inventory.ingredientAmount[potionBox.selectedPanel.ingredients[i].number]--;
            }
            inventory.potionAmount[potionBox.selectedPanel.panelNumber]++;
        }
        counter = 0;
    }
    //if the amount of ingredients in the inventory is greater than or equal to the amount of ingredients needed for the potion...
}
