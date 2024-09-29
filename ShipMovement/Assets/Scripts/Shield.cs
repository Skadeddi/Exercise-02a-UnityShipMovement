using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localScale.x > 0)
        {
            transform.localScale -= new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7 && collision.isTrigger)
        {
            Destroy(collision.gameObject);
        }
    }
}
