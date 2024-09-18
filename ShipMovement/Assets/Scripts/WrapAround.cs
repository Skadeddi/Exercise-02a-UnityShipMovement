using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapAround : MonoBehaviour
{
    void Update()
    {
        if (transform.position.x < -11.5f - transform.localScale.y / 2.0f)
        {
            transform.position = new Vector3(11.4f + transform.localScale.y / 2.0f, transform.position.y);
        }
        else if (transform.position.x > 11.5f + transform.localScale.y / 2.0f)
        {
            transform.position = new Vector3(-11.4f - transform.localScale.y / 2.0f, transform.position.y);
        }
        if (transform.position.y > 5.3f + transform.localScale.y / 2.0f)
        {
            transform.position = new Vector3(transform.position.x, -5.2f - transform.localScale.y / 2.0f);
        }
        else if (transform.position.y < -5.3f - transform.localScale.y / 2.0f)
        {
            transform.position = new Vector3(transform.position.x, 5.2f + transform.localScale.y / 2.0f);
        }
    }
}
