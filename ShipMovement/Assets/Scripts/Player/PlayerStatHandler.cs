using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatHandler : MonoBehaviour
{
    public GameObject player, bullet;
    public PlayerMovement pm;
    public PlayerRespawn pr;
    public float shootTime, cameraSize, pierce;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        pr = GameObject.Find("PlayerRespawnController").GetComponent<PlayerRespawn>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        pm = player.GetComponent<PlayerMovement>();
        shootTime = pm.shootTime;
        cameraSize = cam.orthographicSize;
    }

    public void ShootSpeedUp()
    {
        if(shootTime > 0.01f)
        {
            shootTime -= 0.01f;
            pm.shootTime = shootTime;
        }
    }

    public void BulletSpeedUp()
    {
        pm.bulletSpeedMod *= 1.1f;
    }

    public void BulletSizeUp()
    {
        pm.bulletSizeMod += 0.1f;
    }

    public void CameraSizeUp()
    {
        if (cam.orthographicSize < 20)
        {
            StartCoroutine(cameraLerp());
        }
    }

    private IEnumerator cameraLerp()
    {
        cameraSize += 0.5f;
        float lcs = cam.orthographicSize;
        float time = 0;
        while(cam.orthographicSize < cameraSize)
        {
            time += Time.deltaTime;
            cam.orthographicSize = Mathf.Lerp(lcs, cameraSize, time);
            yield return new WaitForSeconds(0.01f);
        }   
    }

    public void repair()
    {
        pr.Repair();
    }

    public void PierceUp()
    {
        pierce++;
        pm.bulletPierce = pierce;
    }

    public void Airburst()
    {
        pm.CanAirburst();
    }
}
