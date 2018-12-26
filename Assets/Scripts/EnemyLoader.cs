using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoader : MonoBehaviour
{

    [Header("References")]
    public Canvas canvas;
    public Health health;
    public LevelManager levelManager;
    public Enemy[] differentEnemies;
    public List<Enemy> enemies;
    public Enemy activeEnemy;
    public TabManager tabManager;

    [Header("Enemy Stats")]
    public float[] defaultSpawnTimes;
    public float[] spawnTimes;
    public float[] spawnTimers;
    public float[] spawnRNG;
    public int enemyTypes;
    public int[] enemyAmountMax;
    public int[] enemyAmountCurrent;
    
    // Update is called once per frame
    void Update() {
        if (levelManager.levelActive == true)
        {
            for (int i = 0; i < enemyTypes; i++)
            {
                if (levelManager.combatActive == false)
                {
                    spawnTimers[i] += Time.deltaTime;
                }
                if (spawnTimers[i] >= spawnTimes[i] && enemyAmountCurrent[i] < enemyAmountMax[i])
                {
                    spawnTimers[i] = 0;
                    if( levelManager.activeLevel.beaten == true)
                    {
                        spawnTimes[i] = defaultSpawnTimes[i] + Random.Range(0, spawnRNG[i]);
                    }
                    else
                    {
                        spawnTimes[i] = defaultSpawnTimes[i];
                    }
                    Enemy newEnemy = Instantiate(differentEnemies[i], levelManager.transform);
                    newEnemy.levelManager = levelManager;
                    newEnemy.enemyLoader = this;
                    enemyAmountCurrent[i]++;
                    Health newHealth = Instantiate(health, levelManager.transform);
                    newHealth.enemy = newEnemy;
                    newHealth.levelManager = levelManager;
                    newEnemy.health = newHealth;
                }
            }
        }
    }
}
