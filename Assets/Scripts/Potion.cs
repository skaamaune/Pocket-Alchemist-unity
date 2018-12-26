using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Potion : MonoBehaviour {

    public int number;
    public Color color;
    public string potionName;
    public int worth;
    public Ingredient[] ingredients;
    public int[] ingredientAmountsNeeded;
    public string description;
    public int cooldown;
    public bool unlocked;
    public Sprite image;

    public Potion(int Amount)
    {
        //amount = newAmount;
    }
}
