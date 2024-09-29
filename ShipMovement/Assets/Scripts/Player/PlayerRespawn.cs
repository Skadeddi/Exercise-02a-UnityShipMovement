using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    private GameObject player;
    private PlayerMovement pm;

    public Image uhoh;
    public float startingLives, lives;
    private void Start()
    {
        lives = startingLives;
        player = GameObject.Find("Ship");
        pm = player.GetComponent<PlayerMovement>();
}

    public void StartRespawn()
    {
        StartCoroutine(Respawn());
    }

    public IEnumerator Respawn()
    {
        lives--;
        player.transform.position = new Vector3(0, 0, -1);
        uhoh.fillAmount = 1.0f - (lives / startingLives);
        if (lives > 0)
        {
            yield return new WaitForSeconds(2f);
            player.SetActive(true);
            pm.canShoot = true;
            pm.canDash = true;
            pm.speed = pm.defaultSpeed;
        }
        else
        {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(2);
        }
    }

    public void Repair()
    {
        if (lives < startingLives)
        {
            lives++;
        }
        uhoh.fillAmount = 1.0f - (lives / startingLives);
    }
}
