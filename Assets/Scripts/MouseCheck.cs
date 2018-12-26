using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCheck : MonoBehaviour
{
    public bool mouseDown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MouseDown()
    {
        mouseDown = true;
    }

    public void MouseUp()
    {
        mouseDown = false;
    }
}
