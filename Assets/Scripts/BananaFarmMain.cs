using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaFarmMain : MonoBehaviour
{
    Vector2 spawn;

    public GameObject banana;
    public float spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        float posY = transform.position.y;
        spawn = new Vector2(transform.position.x, posY - 0.3f);

        StartCoroutine(SpawnBanana(spawnTimer));
    }

    IEnumerator SpawnBanana(float spawnTimer)
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTimer);
            Instantiate(banana, spawn, Quaternion.identity);
        }
    }
}
