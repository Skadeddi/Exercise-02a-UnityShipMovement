using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed, yvar;
    public int scoreValue;
    public GameObject explosion, bullet, player, respawnHandler;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Ship");
        respawnHandler = GameObject.Find("PlayerRespawnController");
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
            respawnHandler.GetComponent<Scorekeeper>().addScore(scoreValue);
            Instantiate(explosion, new Vector3(transform.position.x, transform.position.y + 1, -1), Quaternion.Euler(0, 0, 0));
            Destroy(gameObject);
        }
    }

    private IEnumerator shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            GameObject newBullet = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), Quaternion.Euler(0, 0, 0));
            try
            {
                newBullet.transform.up = player.transform.position - transform.position;
            }
            catch (Exception e)
            {
                if(e == null)
                {
                    //idk i just hate the error its so annoying
                }
            }
        }
    }
}
