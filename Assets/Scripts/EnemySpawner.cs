using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTime(spawnTime));
    }

    IEnumerator SpawnTime(float spawnTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            Instantiate(enemy, this.transform.position, Quaternion.identity);
        }
    }
}
