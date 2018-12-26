using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallEffect : MonoBehaviour {

    public VisibleManager visibleManager;
    public LevelManager levelManager;
    public TabManager tabManager;
    public Text text;
    public float timer;
    public float timeBeforeDestroy;
    public float xSpeedMax;
    public float ySpeedMax;
    public float rotateSpeedMax;
    public float rotateSpeed;
    public float rotateVelocity;
    public float xSpeed;
    public float ySpeed;
    public float yDropSpeed;
    public float yDropVelocity;
    public float yDeleteAmount;
    public bool falling;
    public bool enemy;


    // Use this for initialization
    void Start ()
    {
        if (enemy)
        {
            xSpeed = Random.Range(xSpeedMax/2, xSpeedMax);
        }
        else
        {
            xSpeed = Random.Range(-xSpeedMax, xSpeedMax);
        }
        levelManager = GetComponentInParent<LevelManager>();
        text = GetComponent<Text>();
        ySpeed = Random.Range(0, ySpeedMax);
        rotateSpeed = Random.Range(-rotateSpeedMax, rotateSpeedMax);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (falling)
        {
            timer += Time.deltaTime;
            transform.position = new Vector3(transform.position.x + xSpeed, transform.position.y + ySpeed - yDropSpeed);
            transform.rotation *= Quaternion.Euler(0, 0, rotateSpeed);
            rotateSpeed -= Time.deltaTime / rotateVelocity;
            yDropSpeed += yDropVelocity * Time.deltaTime;
        }
        if(timer >= timeBeforeDestroy || levelManager.levelActive == false)
        {
            Destroy(gameObject);
        }
	}
}
