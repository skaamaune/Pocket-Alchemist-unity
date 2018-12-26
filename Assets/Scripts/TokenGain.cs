using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenGain : MonoBehaviour
{
    public int tokenQueue;
    public float speed;
    public float timer;

    // Update is called once per frame
    void Update()
    {
        if (tokenQueue > 0)
        {
            timer += Time.deltaTime;
            if(timer >= speed)
            { 
                timer -= speed;
                tokenQueue--;
                GetComponent<Token>().tokens++;
            }
        }
    }
}
