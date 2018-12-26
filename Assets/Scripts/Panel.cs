using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour {
    public LevelManager levelManager;
    public Inventory inventory;
    public Sprite panelUnselected;
    public Sprite panelSelected;
    public PotionBox potionBox;
    public Image image;
    public bool currentPanel;
    public Image potionImage;
    public Text potionNameText;
    public Text descriptionText;
    public List<Text> ingredientsText;
    public Ingredient[] ingredients;
    public Button buton;
    public Color green;
    public Color red;
    public int panelNumber;
    public bool test;

	// Use this for initialization
	void Start () {
        image = gameObject.GetComponent<Image>();
        inventory = levelManager.inventory;
        potionBox.panels.Add(this);
	}

    // Update is called once per frame
    public void Update () {
        if (currentPanel)
        {
            image.sprite = panelSelected;
        }
        else
        {
            image.sprite = panelUnselected;
        }
        for (int i = 0; i < levelManager.inventory.potion[panelNumber].ingredients.Length; i++)
        {
            ingredientsText[i].text = ingredients[i].name.ToString() + " x" + levelManager.inventory.ingredientAmount[i].ToString();
        }
        for (int i = 0; i < ingredients.Length; i++)
        {
            if (inventory.ingredientAmount[ingredients[i].number] >= inventory.potion[panelNumber].ingredientAmountsNeeded[i])
            {
                ingredientsText[i].color = green;
            }
            else
            {
                ingredientsText[i].color = red;
            }
        }
    }
    public void panelSelect()
    {
        potionBox.PanelClear();
        currentPanel = true;
        potionBox.selectedPanel = this;
        test = true;
    }
    public void checkAmounts()
    {
        //if
    }
}
