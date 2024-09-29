using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AirburstUpgrade : MonoBehaviour
{
    private PlayerStatHandler psh;
    private Canvas can;
    private Camera cam;
    private GameObject texttext;
    public GameObject text;

    private void Start()
    {
        psh = GameObject.Find("PlayerRespawnController").GetComponent<PlayerStatHandler>();
        can = GameObject.Find("Canvas").GetComponent<Canvas>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            psh.Airburst();
            texttext = Instantiate(text, cam.WorldToScreenPoint(transform.position), Quaternion.Euler(0, 0, 0));
            texttext.transform.SetParent(can.gameObject.transform);
            texttext.GetComponent<TextMeshProUGUI>().text = "Airburst Lasers";
            Destroy(gameObject);
        }
    }
}
