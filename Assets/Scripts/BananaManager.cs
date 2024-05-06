using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaManager : MonoBehaviour
{
    Vector2 spawnPosition;

    [SerializeField]
    float spawnTime;

    [SerializeField]
    GameObject banana;

    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = this.transform.position;
        spawnPosition.y += 20;
        StartCoroutine(SpawnBanana(spawnTime));
    }

    IEnumerator SpawnBanana(float spawnTimer)
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTimer);
            //Spawn New Banana
            Instantiate(banana, spawnPosition, Quaternion.identity);
        }
    }
}
