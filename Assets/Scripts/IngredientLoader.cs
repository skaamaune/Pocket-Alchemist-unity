using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientLoader : MonoBehaviour
{

    [Header("References")]
    public Canvas canvas;
    public LevelManager levelManager;
    public List<Ingredient> ingredients;
    public Enemy[] differentEnemies;

    public float[] spawnTimes;
    public float[] timers;

    // Update is called once per frame
    void Update()
    {
        if (levelManager.levelActive)
        {
            for (int i = 0; i < timers.Length; i++)
            {
                if (levelManager.combatActive == false)
                {
                    timers[i] += Time.deltaTime;
                    for (int f = 0; f < ingredients.Count; f++)
                    {
                        if (timers[f] >= spawnTimes[f])
                        {
                            timers[f] = 0;
                            Ingredient newIngredient = Instantiate(ingredients[f], levelManager.transform);
                            newIngredient.levelManager = levelManager;
                            newIngredient.obtainable = true;
                            newIngredient.inventory = levelManager.inventory;
                            newIngredient.tabManager = levelManager.tabManager;
                        }
                    }
                }
            }
        }
    }
}
