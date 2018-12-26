using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParentCollider : MonoBehaviour {

    public BoxCollider2D boxCollider;
    public Image image;

// Use this for initialization
void Start()
{
    boxCollider = gameObject.GetComponent<BoxCollider2D>();
    image = transform.parent.GetComponent<Image>();
}

// Update is called once per frame
void Update()
{
    if (image.enabled)
    {
        boxCollider.enabled = true;
    }
    else
    {
        boxCollider.enabled = false;
    }
}
}
