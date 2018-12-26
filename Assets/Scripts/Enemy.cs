using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour{

    [Header("References")]
    public Image enemyVisible;
    public LevelManager levelManager;
    public TabManager tabManager;
    public EnemyLoader enemyLoader;
    public Health health;
    public Stats stats;
    
    [Header("Variables")]
    public float combatActivePoint;
    public bool test;
    public bool activeEnemy;
    public float HPHeight;
    public float HPXAlignment;
    private int currentTab;
    public bool bossMonster;
    public float tokenYOffset;
    public float tokenXOffest;
    public bool dead;
    

    public void Start()
    {
        tabManager = GetComponentInParent<LevelManager>().tabManager;
        stats = GetComponent<Stats>();
        enemyVisible = GetComponent<Image>();
        stats.currentHealth = stats.maxHealth;
    }
    
    // Update is called once per frame
    public void Update()
    {
        if (levelManager.levelActive == false)
        {
            Destroy(gameObject);
        }
        else
        {
        EnemyMovement();
        EnemyDestroy();
        }


        //makes enemy only visible on the combat tab
        if (tabManager.tabClicked != 0)
        {
            enemyVisible.enabled = false;
        }
        else
        {
            enemyVisible.enabled = true;
        }
    }

    public void EnemyMovement() {
        if (transform.position.x <= combatActivePoint && !dead)
        {
            levelManager.combatActive = true;
            activeEnemy = true;
            enemyLoader.activeEnemy = this;
        }
        else
        {
            if (levelManager.combatActive == false && !dead)
            {
                transform.position -= new Vector3 (stats.movementSpeed + levelManager.activeLevel.levelScrollSpeedActual, 0, 0);
            }
        }
    }

    public void EnemyDestroy()
    {
        if ( stats.currentHealth <= 0)
        {
            if (!dead) { 
                levelManager.combatActive = false;
                if (levelManager.activeLevel.beaten)
                {

                }
                if (stats.currentHealth <= 0)
                {
                    levelManager.tokenAmount = Random.Range(stats.worthMin, stats.worthMax);
                    Token newToken = Instantiate(levelManager.tokenToSpawn, levelManager.transform);
                    newToken.transform.position = new Vector3(transform.position.x + tokenXOffest, transform.position.y + tokenYOffset, transform.position.z);
                    if (bossMonster)
                    {
                        levelManager.activeLevel.beaten = true;
                    }
                }
                dead = true;
                GetComponent<FallEffect>().falling = true;
                GetComponent<CharacterRotation>().rotating = false;

            }
        }
    }
}
