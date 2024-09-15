using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool canShoot = true, canDash = true;

    public float speed, rotSpeed, shootTime, dashMod, dashTime;
    public GameObject laser, lp1, lp2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up * Input.GetAxis("Vertical") * speed;
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + Input.GetAxisRaw("Horizontal") * rotSpeed * -1);

        if (Input.GetKey(KeyCode.Space) && canShoot)
        {
            StartCoroutine(shootCD());
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(dash());
        }

        wrap();
    }

    private IEnumerator dash()
    {
        canDash = false;
        speed *= dashMod;
        yield return new WaitForSeconds(dashTime);
        speed /= dashMod;
        canDash = true;
    }

    private void wrap()
    {
        if (transform.position.x < -11.5f)
        {
            transform.position = new Vector3(11.4f, transform.position.y);
        }
        else if (transform.position.x > 11.5f)
        {
            transform.position = new Vector3(-11.4f, transform.position.y);
        }
        if (transform.position.y > 5.3f)
        {
            transform.position = new Vector3(transform.position.x, -5.2f);
        }
        else if (transform.position.y < -5.3f)
        {
            transform.position = new Vector3(transform.position.x, 5.2f);
        }
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

}
