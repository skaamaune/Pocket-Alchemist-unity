using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionContent : MonoBehaviour
{
    public PotionBox potionBox;
    public LevelManager levelManager;
    public Panel panelReference;
    public List<Panel> panels;
    public List<Potion> potions;
    public float ingredientYDifference;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<potions.Count; i++)
        {
            //if (potions[i].unlocked)
            //{
                panels.Add(Instantiate(panelReference, transform));
                panels[i].levelManager = levelManager;
                panels[i].potionImage.sprite = potions[i].image;
                panels[i].potionNameText.text = potions[i].potionName;
                panels[i].potionNameText.color = potions[i].color;
                panels[i].descriptionText.text = potions[i].description;
                panels[i].ingredients = potions[i].ingredients;
                panels[i].panelNumber = i;
                panels[i].potionBox = potionBox;
            for (int f = 1; f < potions[i].ingredients.Length; f++)
                {
                    panels[i].ingredientsText.Add(Instantiate(panelReference.ingredientsText[0], panels[i].transform));
                    panels[i].ingredientsText[f].transform.position -= new Vector3(0, ingredientYDifference * f, 0);                    
                }
            }
        }


    // Update is called once per frame
    void Update()
    {
        
    }
}
