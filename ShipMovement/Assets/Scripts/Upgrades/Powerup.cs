using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Powerup : MonoBehaviour
{
    private PlayerStatHandler psh;
    public GameObject text;
    private Camera cam;
    private Canvas can;
    private GameObject texttext;

    private void Start()
    {
        psh = GameObject.Find("PlayerRespawnController").GetComponent<PlayerStatHandler>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        can = GameObject.Find("Canvas").GetComponent<Canvas>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            int randPow = Random.Range(0, 5);
            switch (randPow)
            {
                case 0:
                    psh.repair();
                    texttext = Instantiate(text, cam.WorldToScreenPoint(transform.position), Quaternion.Euler(0, 0, 0));
                    texttext.transform.SetParent(can.gameObject.transform);
                    texttext.GetComponent<TextMeshProUGUI>().text = "Repaired Ship";
                    break;
                case 1:
                    psh.ShootSpeedUp();
                    texttext = Instantiate(text, cam.WorldToScreenPoint(transform.position), Quaternion.Euler(0, 0, 0));
                    texttext.transform.SetParent(can.gameObject.transform);
                    texttext.GetComponent<TextMeshProUGUI>().text = "Shoot speed up";
                    break;
                case 2:
                    psh.BulletSpeedUp();
                    texttext = Instantiate(text, cam.WorldToScreenPoint(transform.position), Quaternion.Euler(0, 0, 0));
                    texttext.transform.SetParent(can.gameObject.transform);
                    texttext.GetComponent<TextMeshProUGUI>().text = "Bullet speed up";
                    break;
                case 3:
                    psh.BulletSizeUp();
                    texttext = Instantiate(text, cam.WorldToScreenPoint(transform.position), Quaternion.Euler(0, 0, 0));
                    texttext.transform.SetParent(can.gameObject.transform);
                    texttext.GetComponent<TextMeshProUGUI>().text = "Bullet size up";
                    break;
                case 4:
                    psh.CameraSizeUp();
                    texttext = Instantiate(text, cam.WorldToScreenPoint(transform.position), Quaternion.Euler(0, 0, 0));
                    texttext.transform.SetParent(can.gameObject.transform);
                    texttext.GetComponent<TextMeshProUGUI>().text = "Camera size up";
                    break;
            }
            Destroy(gameObject);
        }
    }
}
