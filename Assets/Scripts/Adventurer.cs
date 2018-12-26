using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Adventurer : MonoBehaviour {

    [Header("References")]
    public LevelManager levelManager;
    public TabManager tabManager;
    private Image visible;

    public Stats stats;

    // Use this for initialization
    void Start () {
        visible = GetComponent<Image>();
        stats = GetComponent<Stats>();
        stats.currentHealth = stats.maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        if (levelManager.levelActive == true && tabManager.tabClicked == 0)
        {
            visible.enabled = true;
        }
        else
        {
            visible.enabled = false;
        }
        if(stats.currentHealth <= 0)
        {
            Die();
        }
    }

   
    public void Die()
    {
        levelManager.AdventureEnd();
        stats.deathCount++;
        transform.position = new Vector3(-4f, 0f, 0f);
        transform.rotation = Quaternion.Euler(0f, 0f, -15f);
        stats.currentHealth = stats.maxHealth;
        levelManager.combatActive = false;
    }
}
