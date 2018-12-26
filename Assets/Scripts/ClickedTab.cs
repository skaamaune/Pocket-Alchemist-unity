using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ClickedTab : MonoBehaviour
{
    public RectTransform rect;
    public Image image;
    public Text text;

    public bool unlocked;
    public bool activeTab;

    public float offsetYMaxY;
    public float offsetMinY;
    public float moveSpeed;
    public bool justClicked;
    public int tabNumber;

    // On click set tabset to this number tab

    private void Start()
    {
        rect = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        text = GetComponentInChildren<Text>();
    }

    void Update()
    {
        if (unlocked)
        {
            image.enabled = true;
            text.enabled = true;
        }
        else
        {
            image.enabled = false;
            text.enabled = false;
        }
        if (activeTab == true)
        {
            if(rect.offsetMax.y <= offsetYMaxY)
            {
                rect.offsetMax += new Vector2 (0, +moveSpeed);
            }
        }
        else
        {
            if (rect.offsetMax.y >= offsetMinY)
            {
                rect.offsetMax += new Vector2(0, -moveSpeed);
            }
        }
    }

    public void gotClicked()
    {
        justClicked = true;
    }
}
