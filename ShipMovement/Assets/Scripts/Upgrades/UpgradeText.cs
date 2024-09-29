using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeText : MonoBehaviour
{
    public float speed;
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
        Destroy(gameObject, 3);
    }
}
