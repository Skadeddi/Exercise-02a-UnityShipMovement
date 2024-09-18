using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed;
    public GameObject asteroid;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6 && transform.localScale.x / 2.0f >= 0.5f)
        {
            for (int i = 0; i < 2; i++)
            {
                GameObject newSteroid = Instantiate(asteroid, transform.position, Quaternion.Euler(0, 0, 0));
                newSteroid.transform.localScale = new Vector3(transform.localScale.x / 2.0f, transform.localScale.y / 2.0f, 1);
                newSteroid.GetComponent<Asteroid>().speed *= 1.5f;
            }
        }
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
