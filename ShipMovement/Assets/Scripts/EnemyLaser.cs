using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
        StartCoroutine(color());
        Destroy(gameObject, 1);
    }

    private IEnumerator color()
    {
        float time = 0;
        while(time < 1)
        {
            time += 0.1f;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(Mathf.Lerp(0, 1, time), 0, Mathf.Lerp(1, 0, time));
            yield return new WaitForSeconds(0.1f);
        }
    }
}
