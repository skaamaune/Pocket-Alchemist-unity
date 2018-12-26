using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    public Enemy enemy;
    public Stats stats;
    public LevelManager levelManager;
    public TabManager tabManager;
    public Text health;
    private int currentHealth;
    private int maxHealth;

    // Use this for initialization
    void Start ()
    {
        tabManager = GetComponentInParent<LevelManager>().tabManager;
        stats = enemy.stats;
        maxHealth = enemy.stats.maxHealth;
    }

    // Update is called once per frame
    void Update ()
    {
        currentHealth = enemy.stats.currentHealth;
        if(enemy.dead == false)
        {
        health.text = currentHealth.ToString() + "HP/" + maxHealth.ToString() + "HP";
        }
        else
        {
            health.text = " HP/" + maxHealth.ToString() + "HP";
        }
        if (currentHealth >= maxHealth / 2)
        {
            health.color = new Vector4((((-currentHealth) / (maxHealth / 2f)) + 2f), 255, 0, 255);
        }
        else
        {
            health.color = new Vector4(255f, (currentHealth * 2f / maxHealth), 0, 255);
        }
        if (levelManager.levelActive == true && tabManager.tabClicked == 0)
        {
            health.enabled = true;
            if(enemy.dead == false)
            {
                transform.position = new Vector3(enemy.transform.position.x + enemy.HPXAlignment, enemy.HPHeight, 0);
            }
        }
        else
        {
            health.enabled = false;
        }
        if (enemy.stats.currentHealth <= 0 )
        {
            GetComponent<FallEffect>().falling = true;
        }
        if( levelManager.levelActive == false)
        {
            Destroy(gameObject);
        }
    }
}