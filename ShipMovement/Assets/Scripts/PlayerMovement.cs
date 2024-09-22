using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool canShoot = true, canDash = true;
    private GameObject respawnController;

    public float speed, rotSpeed, shootTime, dashMod, dashTime, defaultSpeed;
    public GameObject laser, lp1, lp2, explosion;

    // Start is called before the first frame update
    void Start()
    {
        defaultSpeed = speed;
        rb = GetComponent<Rigidbody2D>();
        respawnController = GameObject.Find("PlayerRespawnController");
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up * Input.GetAxis("Vertical") * speed;
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + Input.GetAxisRaw("Mouse X") * rotSpeed * -1);

        if (Input.GetKey(KeyCode.Space) && canShoot)
        {
            StartCoroutine(shootCD());
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(dash());
        }
    }

    private IEnumerator dash()
    {
        canDash = false;
        speed *= dashMod;
        yield return new WaitForSeconds(dashTime);
        speed /= dashMod;
        canDash = true;
    }

    private IEnumerator shootCD()
    {
        canShoot = false;
        Instantiate(laser, lp1.transform.position, lp1.transform.rotation);
        yield return new WaitForSeconds(shootTime);
        Instantiate(laser, lp2.transform.position, lp2.transform.rotation);
        yield return new WaitForSeconds(shootTime);
        canShoot = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            Instantiate(explosion, new Vector3(transform.position.x, transform.position.y + 1, -1), Quaternion.Euler(0, 0, 0));
            respawnController.GetComponent<PlayerRespawn>().StartRespawn();
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Instantiate(explosion, new Vector3(transform.position.x, transform.position.y + 1, 0), Quaternion.Euler(0, 0, 0));
            respawnController.GetComponent<PlayerRespawn>().StartRespawn();
            gameObject.SetActive(false);
        }
    }

}
