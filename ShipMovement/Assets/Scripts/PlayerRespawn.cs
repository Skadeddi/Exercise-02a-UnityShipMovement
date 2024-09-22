using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private GameObject player;
    private PlayerMovement pm;
    private void Start()
    {
        player = GameObject.Find("Ship");
        pm = player.GetComponent<PlayerMovement>();
}

    public void StartRespawn()
    {
        StartCoroutine(Respawn());
    }

    public IEnumerator Respawn()
    {
        player.transform.position = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(2f);
        player.SetActive(true);
        pm.canShoot = true;
        pm.canDash = true;
        pm.speed = pm.defaultSpeed;
    }
}
