using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteThis : MonoBehaviour {
    public Image image;
    public float countdown;

    private void Start()
    {
        image = gameObject.GetComponent<Image>();
        image.enabled = true;
    }

    void Update () {
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0.0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
