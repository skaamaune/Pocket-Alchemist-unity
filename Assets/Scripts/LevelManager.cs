using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour{

    [Header("References")]
    public Inventory inventory;
    public List<Level> levels;
    public Level activeLevel;
    public ClickedLevelButton[] levelButton;
    public Adventurer adventurer;
    public EnemyLoader enemyLoader;
    public LevelManager levelManager;
    public TabManager tabManager;
    public Enemy activeEnemy;
    public TokenGain tokenGain;
    public Token tokenToSpawn;
    public int levelSet;
    public int tokenAmount;
    public bool levelActive;
    public bool combatActive;
    

    // Update is called once per frame
    void Update ()
    {
        for (int i = 0; i < levels.Count; i++)
        {
            if (levelButton[i].justClicked == true)
            {
                LevelDisable();
                activeLevel = levels[i];
                enemyLoader = levels[i].GetComponent<EnemyLoader>();
                levels[i].active = true;
                levelButton[i].justClicked = false;
                levelButton[i].activeLevel = true;
                levelActive = true;
                break;
            }
        }
    }

    public void LevelDisable()
    {
        for (int f = 0; f < levels.Count; f++)
        {
            levelButton[f].activeLevel = false;
            levels[f].active = false;
            levelActive = false;
        }
        combatActive = false;
    }

    public void SpawnTimesClear()
    {
        if (levelManager.levelActive == false)
        {
            for (int i = 0; i < levels.Count; i++)
            {
                for (int f = 0; f < enemyLoader.spawnTimers.Length; f++)
                {
                    enemyLoader.spawnTimers[f] = 0;
                }
            }
        }
    }

    public void AdventureEnd()
    {
        for (int i = 0; i < activeLevel.GetComponent<EnemyLoader>().enemyAmountMax.Length; i++)
        {
            activeLevel.GetComponent<EnemyLoader>().enemyAmountCurrent[i] = 0;
        }
        LevelDisable();
        SpawnTimesClear();
    }

    public void GetToken()
    {
        tokenGain.tokenQueue += tokenAmount;
    }

    public void levelBeat()
    {
        adventurer.stats.levelsBeaten++;
    }
}
