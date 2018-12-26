using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour {

    [Header("References")]
    public DamageEffect damageEffect;
    public LevelManager levelManager;
    public EnemyLoader enemyLoader;
    public Adventurer adventurer;
    public Level level;
    public Enemy enemy;
    public bool enemyDamaged;


    [Header("Timers")]
    public float adventurerAttackTimer;
    public float enemyAttackTimer;
    public bool combatStarted;

    // Update is called once per frame
    void Update()
    {
        if (levelManager.combatActive)
        {
            CombatStart();
            adventurerAttackTimer -= Time.deltaTime;
            enemyAttackTimer -= Time.deltaTime;
            if (adventurerAttackTimer <= 0f)
            {
                enemy.stats.currentHealth -= adventurer.stats.strBase + adventurer.stats.strMod;
                adventurerAttackTimer += (1f - ((adventurer.stats.dexBase + adventurer.stats.dexMod) / 125f));
                enemyDamaged = true;
                damageEffect.Damage();
            }
            if (enemyAttackTimer <= 0f)
            {
                adventurer.stats.currentHealth -= enemy.stats.strBase;
                enemyAttackTimer += (1f - (enemy.stats.dexBase / 125f));
                enemyDamaged = false;
                damageEffect.Damage();
            }
        }
        else
        {
            combatStarted = false;
        }
    }

    public void CombatStart()
    {
        if (combatStarted == false)
        { 
            level = levelManager.activeLevel;
            enemyLoader = level.GetComponent<EnemyLoader>();
            enemy = enemyLoader.activeEnemy;
            combatStarted = true;
            adventurerAttackTimer = (1 - ((adventurer.stats.dexBase + adventurer.stats.dexMod) / 125f));
            enemyAttackTimer = (1 - (enemy.stats.dexBase / 125f));
            levelManager.activeEnemy = enemyLoader.activeEnemy;
        }
    }
}
