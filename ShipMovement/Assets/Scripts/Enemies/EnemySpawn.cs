using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject asteroidL, UFO, asteroidM;

    private int wave;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(enemySpawnLoop());
    }

    public GameObject randomEnemy()
    {
        int randInt = Random.Range(0, 10);
        if(randInt == 0)
        {
            return UFO;
        }
        else
        {
            if(Random.Range(0, 20) > wave)
            {
                return asteroidM;
            }
            else
            {
                return asteroidL;
            }
        }
    }

    public IEnumerator enemySpawnLoop()
    {
        while (true)
        {
            wave++;
            for (int i = 0; i < (wave / 2) + 1; i++)
                Instantiate(randomEnemy(), new Vector3(Random.Range(-11.5f, 11.5f), -20, 0), Quaternion.Euler(0, 0, 0));
            yield return new WaitForSeconds(15);
        }
    }
}
