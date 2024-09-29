using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenEnemyCleanup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(cleanup());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator cleanup()
    {
        while (true)
        {
            Asteroid[] asteroids;
            yield return new WaitForSeconds(5);
            asteroids = FindObjectsByType<Asteroid>(FindObjectsSortMode.None);
            for (int i = 0; i < asteroids.Length; i++)
            {
                if (asteroids[i] != null && asteroids[i].GetComponent<Asteroid>().enabled != true)
                {
                    Destroy(asteroids[i].gameObject);
                }
            }

        }
    }
}
