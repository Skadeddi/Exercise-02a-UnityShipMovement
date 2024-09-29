using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed, scaleMod, speedMod, pierce, abCount;
    public bool airburst;
    public GameObject laser;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
        StartCoroutine(color());
        StartCoroutine(Airburst());
        Destroy(gameObject, 1);
    }

    private IEnumerator color()
    {
        float time = 0;
        while(time < 1)
        {
            time += 0.1f;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(Mathf.Lerp(1, 0, time), 0, Mathf.Lerp(0, 1, time));
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void damaged()
    {
        pierce--;
        if(pierce <= 0)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator Airburst()
    {
        yield return new WaitForSeconds(0.6f - abCount * 0.05f);
        if (airburst)
        {
            GameObject tempLas = Instantiate(laser, transform.position, Quaternion.Euler(0, 0, transform.eulerAngles.z + 5));
            tempLas.transform.localScale = transform.localScale;
            Laser tempLasScript = tempLas.GetComponent<Laser>();
            tempLasScript.speed = speed;
            tempLasScript.pierce = pierce;
            tempLasScript.airburst = false;
            tempLas = Instantiate(laser, transform.position, Quaternion.Euler(0, 0, transform.eulerAngles.z - 5));
            tempLas.transform.localScale = transform.localScale;
            tempLasScript = tempLas.GetComponent<Laser>();
            tempLasScript.speed = speed;
            tempLasScript.pierce = pierce;
            tempLasScript.airburst = false;
        }
    }
}
