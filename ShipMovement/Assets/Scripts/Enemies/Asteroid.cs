using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed;
    public int scoreValue;
    public GameObject asteroid, explosion, respawnHandler, upgrade, shield, airburst, pierce;
    private PolygonCollider2D coll;

    void Start()
    {
        coll = gameObject.GetComponent<PolygonCollider2D>();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        respawnHandler = GameObject.Find("PlayerRespawnController");
        transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            if (transform.localScale.x / 2.0f >= 0.5f)
            {
                for (int i = 0; i < 2; i++)
                {
                    GameObject newSteroid = Instantiate(asteroid, transform.position, Quaternion.Euler(0, 0, 0));
                    newSteroid.transform.localScale = new Vector3(transform.localScale.x / 2.0f, transform.localScale.y / 2.0f, 1);
                    newSteroid.GetComponent<Asteroid>().speed *= 1.5f;
                }
            }

            respawnHandler.GetComponent<Scorekeeper>().addScore(scoreValue);
            Instantiate(explosion, new Vector3(transform.position.x, transform.position.y + 1, -1), Quaternion.Euler(0, 0, 0));
            if(Mathf.Floor(Random.Range(0, 5)) == 0)
            {
                Instantiate(upgrade, new Vector3(transform.position.x, transform.position.y, 1), Quaternion.Euler(0, 0, 0));
            }
            else
            {
                switch (Mathf.Floor(Random.Range(0, 30)))
                {
                    case 0:
                        Instantiate(pierce, transform.position, Quaternion.Euler(0, 0, 0));
                        break;
                    case 1:
                        Instantiate(airburst, transform.position, Quaternion.Euler(0, 0, 0));
                        break;
                    case 2:
                        Instantiate(shield, transform.position, Quaternion.Euler(0, 0, 0));
                        break;
                }
            }
            if (collision.gameObject.CompareTag("Bullet"))
            {
                collision.gameObject.GetComponent<Laser>().damaged();
            }
            Destroy(gameObject);
        }
    }
}
