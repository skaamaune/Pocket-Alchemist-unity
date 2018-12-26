using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TokenGet : MonoBehaviour
{
    public LevelManager levelManager;
    public int tokenGetAmount;
    public float upSpeed;
    public float timeBeforeOpaque;
    public float opaqueSpeed;
    public float timer;

    private void Start()
    {
        levelManager = GetComponentInParent<LevelManager>();
        GetComponent<Token>().tokens = levelManager.tokenAmount;
        levelManager.GetToken();
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z) + new Vector3(0, Time.deltaTime * upSpeed, 0);
        if(timer >= timeBeforeOpaque)
        {
            GetComponentInChildren<Image>().CrossFadeAlpha(0, opaqueSpeed, false);
            GetComponent<Text>().CrossFadeAlpha(0, opaqueSpeed, false);
        }
        if(timer >= timeBeforeOpaque + opaqueSpeed*5)
        {
            Destroy(gameObject);
        }
    }
}
