using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotation : MonoBehaviour
{
    public LevelManager levelManager;
    public Stats stats;

    [Header("Rotation Variables")]

    public bool rotating;

    public bool adventurer;
    public bool activeEnemy;

    public float cycleSpeed;
    public float time;

    public float rotateMax;
    public float rotateOffset;
    public float rotateSpeed;

    public float bounceMax;

    public float baseY;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = GetComponentInParent<LevelManager>();
        stats = GetComponent<Stats>();
    }

    // Update is called once per frame
    private void Update()
    {
        rotation();
    }

    void rotation()
    {
        if (rotating)
        {
            transform.position = (new Vector3(transform.position.x, baseY + Mathf.Abs(Mathf.Cos(Time.realtimeSinceStartup * cycleSpeed) * bounceMax), transform.position.z));

            {
                if (levelManager.combatActive == true)
                {
                    if (adventurer)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, -Mathf.Abs(Mathf.Cos(Time.realtimeSinceStartup * stats.movementSpeed * rotateSpeed) * rotateMax));
                    }
                    else if (levelManager.activeEnemy == gameObject.GetComponent<Enemy>())
                    {
                        transform.rotation = Quaternion.Euler(0, 0, Mathf.Abs(Mathf.Cos(Time.realtimeSinceStartup * stats.movementSpeed * rotateSpeed) * rotateMax));
                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(0, 0, Mathf.Cos(Time.realtimeSinceStartup * stats.movementSpeed * rotateSpeed) * rotateMax);
                    }
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 0, Mathf.Cos(Time.realtimeSinceStartup * stats.movementSpeed * rotateSpeed) * rotateMax);
                }
            }
        }
    }
}
