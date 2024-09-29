using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapAround : MonoBehaviour
{
    public Camera cam;

    private void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    void Update()
    {
        float screenTop = cam.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        float screenRight = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        if (transform.position.x < -screenRight - transform.localScale.y / 2.0f)
        {
            transform.position = new Vector3(screenRight + transform.localScale.y / 2.0f, transform.position.y);
        }
        else if (transform.position.x > screenRight + transform.localScale.y / 2.0f)
        {
            transform.position = new Vector3(-screenRight - transform.localScale.y / 2.0f, transform.position.y);
        }
        if (transform.position.y > screenTop + transform.localScale.y / 2.0f)
        {
            transform.position = new Vector3(transform.position.x, -screenTop - transform.localScale.y / 2.0f);
        }
        else if (transform.position.y < -screenTop - transform.localScale.y / 2.0f)
        {
            transform.position = new Vector3(transform.position.x, screenTop + transform.localScale.y / 2.0f);
        }
    }
}
