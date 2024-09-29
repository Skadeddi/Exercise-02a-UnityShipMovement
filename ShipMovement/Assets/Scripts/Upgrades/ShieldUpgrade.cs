using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class ShieldUpgrade : MonoBehaviour
{
    private GameObject player;
    private PlayerStatHandler psh;
    private Canvas can;
    private Camera cam;
    private GameObject texttext;
    public GameObject text;
    private PlayerShield ps;

    private void Start()
    {
        psh = GameObject.Find("PlayerRespawnController").GetComponent<PlayerStatHandler>();
        can = GameObject.Find("Canvas").GetComponent<Canvas>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        player = GameObject.Find("Ship");
        if (player == null)
        {
            SpriteRenderer[] onlyInactive = GameObject.FindObjectsOfType<SpriteRenderer>(true).Where(sr => !sr.gameObject.activeInHierarchy).ToArray();
            player = onlyInactive[0].gameObject;
        }
        ps = player.GetComponent<PlayerShield>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            if (ps.enabled && ps.waitTime > 5)
            {
                ps.waitTime--;
            }
            else if (!ps.enabled)
            {
                ps.enabled = true;
            }

            texttext = Instantiate(text, cam.WorldToScreenPoint(transform.position), Quaternion.Euler(0, 0, 0));
            texttext.transform.SetParent(can.gameObject.transform);
            texttext.GetComponent<TextMeshProUGUI>().text = "Player Shield";
            Destroy(gameObject);
        }
    }
}
