using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour {

    public Image image;
    public LevelManager levelManager;
    public TabManager tabManager;
    public Adventurer adventurer;
    public bool active;
    public bool beaten;
    public float introSpeed;
    public float levelScrollSpeedInput;
    public float levelScrollSpeedActual;
    public float levelLength;
    public float levelEnd;
    public float introStopPosition;

    private void Start()
    {
        image = GetComponentInParent<Image>();
        levelManager = GetComponentInParent<LevelManager>();
        tabManager = levelManager.tabManager;
    }

    void Update() {
        {
            if (active)
            {
                levelScrollSpeedActual = levelScrollSpeedInput * adventurer.stats.movementSpeed;
                if (adventurer.transform.position.x < introStopPosition)
                {
                    adventurer.transform.position += new Vector3(introSpeed * adventurer.stats.movementSpeed, 0, 0);
                }
                if (levelManager.combatActive == false && adventurer.transform.position.x >= introStopPosition)
                {
                    transform.SetPositionAndRotation(new Vector3(transform.position.x - levelScrollSpeedActual * adventurer.stats.movementSpeed, transform.position.y, transform.position.z), transform.localRotation);
                }
                if (transform.position.x < levelEnd) //-5.5
                {
                    transform.SetPositionAndRotation(new Vector3(transform.position.x + levelLength, transform.position.y, transform.position.z), transform.localRotation);
                }
                if(tabManager.tabClicked == 0)
                {
                    image.enabled = true;
                }
                else
                {
                    image.enabled = false;
                }
            }
            else
            {
                image.enabled = false;
            }
        }
    }
}
