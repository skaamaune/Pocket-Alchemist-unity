using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ingredient : MonoBehaviour {

    public Inventory inventory;
    public LevelManager levelManager;
    public TabManager tabManager;
    public Sprite sprite;
    public int number;
    public bool obtained;
    public string ingredientName;
    public string description;
    public int worth;
    public bool obtainable;
    public float obtainSpot;

    void Update()
    {
        if (tabManager.tabClicked == 0)
        {
            GetComponent<Image>().enabled = true;
        }
        else
        {
            GetComponent<Image>().enabled = false;
        }
        if (levelManager.combatActive == false)
        {
            transform.SetPositionAndRotation(new Vector3(transform.position.x - levelManager.activeLevel.levelScrollSpeedActual * levelManager.adventurer.stats.movementSpeed, transform.position.y, transform.position.z), transform.localRotation);
        }
        if (transform.position.x <= obtainSpot)
        {
            inventory.ingredientAmount[number]++;
            Destroy(gameObject);
        }
        if (levelManager.levelActive == false)
        {
            Destroy(gameObject);
        }
    }
}
