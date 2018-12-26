using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Token : MonoBehaviour
{

    public Text text;
    public int tokens;
    public bool inventory;

    // Update is called once per frame
    void Update()
    {
        if (inventory)
        {
        text.text = ": " + tokens.ToString();
        }
        else
        {
            text.text = "+" + tokens.ToString();
        }
    }
}
