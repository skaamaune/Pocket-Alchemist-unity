using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventurerHealth : MonoBehaviour {
    public Adventurer adventurer;
    public LevelManager levelManager;
    public TabManager tabManager;
    public Stats stats;
    public Text health;
    private int currentHealth;
    private int maxHealth;
    public int height;
    public int xOffest;

    // Use this for initialization
    void Start ()
    {
        stats = adventurer.stats;
        health.enabled = false;
        maxHealth = adventurer.stats.maxHealth;
        currentHealth = adventurer.stats.maxHealth;
    }
	
	// Update is called once per frame
	void Update ()
    {
        currentHealth = adventurer.stats.currentHealth;
        health.text = currentHealth.ToString() + "HP/" + maxHealth.ToString() + "HP";
        if(currentHealth >= maxHealth / 2)
        {
            health.color = new Vector4((((-currentHealth) /(maxHealth / 2f))+2f), 255, 0, 255);
        }
        else
        {
            health.color = new Vector4(255f, (currentHealth * 2f / maxHealth), 0, 255);
        }
        if (levelManager.levelActive == true && tabManager.tabClicked == 0)
        {
            health.enabled = true;
            transform.position = new Vector3(adventurer.transform.position.x +xOffest, height, 0);
        }
        else
        {
            health.enabled = false;
        }
    }
}
