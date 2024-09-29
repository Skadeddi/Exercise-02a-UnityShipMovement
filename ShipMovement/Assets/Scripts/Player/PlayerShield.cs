using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    public GameObject shield;
    public float waitTime;
    // Start is called before the first frame update

    private void OnEnable()
    {
        StartCoroutine(SpawnShield());
    }
    IEnumerator SpawnShield()
    {
        while (true)
        {
            Instantiate(shield, new Vector3(transform.position.x, transform.position.y, 1), Quaternion.Euler(0, 0, 0));
            yield return new WaitForSeconds(waitTime);
        }
    }
}
