using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageEffect : MonoBehaviour {
    public LevelManager levelManager;
    public TabManager tabManager;
    public FallEffect fallEffect;
    public Combat combat;
    public Adventurer adventurer;
    public AdventurerHealth adventurerHealth;
    public Health enemyHealth;
    public Text damageAmount;
    public float spawnOffsetXAdventurer;
    public float spawnOffsetXEnemy;
    public float textSize;

    public void Damage() {
        enemyHealth = levelManager.activeEnemy.health;
        Text newText = Instantiate(damageAmount);
        newText.transform.SetParent(levelManager.transform, false);
        fallEffect = newText.gameObject.GetComponent<FallEffect>();
        fallEffect.tabManager = tabManager;
        fallEffect.visibleManager = levelManager.GetComponent<VisibleManager>();
        if (combat.enemyDamaged)
        {
            newText.transform.position = new Vector3(enemyHealth.transform.position.x + spawnOffsetXEnemy /*+ enemyHealth.health.text.Length * textSize*/, enemyHealth.transform.position.y, 0);
            newText.text = (adventurer.stats.strBase + adventurer.stats.strMod).ToString();
            newText.color = enemyHealth.GetComponent<Text>().color;
        }
        else
        {
            newText.transform.position = new Vector3(adventurerHealth.transform.position.x + spawnOffsetXAdventurer /* + enemyHealth.health.text.Length * textSize*/, adventurerHealth.transform.position.y, 0);
            newText.text = (combat.enemy.stats.strBase).ToString();
            newText.color = adventurerHealth.GetComponent<Text>().color;
        }
    }
}
