using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed, yvar;
    public GameObject explosion, bullet, player;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Ship");
        StartCoroutine(shoot());
    }
    void Update()
    {
        rb.velocity = new Vector3(speed, Mathf.Sin(Time.realtimeSinceStartup) * yvar, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Instantiate(explosion, new Vector3(transform.position.x, transform.position.y + 1, -1), Quaternion.Euler(0, 0, 0));
            Destroy(gameObject);
        }
    }

    private IEnumerator shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            GameObject newBullet = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), Quaternion.Euler(0, 0, 0));
            newBullet.transform.up = player.transform.position - transform.position;
        }
    }
}
