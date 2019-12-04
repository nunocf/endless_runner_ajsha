using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeSpawner : MonoBehaviour
{
    public GameObject bee;
    public float startTimeBetweenSpawn;
    public float decreaseTime;
    public float minTime = 0.65f;
    private float timeBetweenSpawn;

    // Update is called once per frame
    void Update()
    {
        if (timeBetweenSpawn > 0)
        {
            timeBetweenSpawn -= Time.deltaTime;
        }
        else
        {
            int beeAmount = Random.Range(1, 5);

            for (int i = 0; i < beeAmount; i++)
            {
                Vector3 position = transform.position + new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), 0);
                Instantiate(bee, position, Quaternion.identity);
            }
            timeBetweenSpawn = startTimeBetweenSpawn;
            if (startTimeBetweenSpawn > minTime)
            {
                startTimeBetweenSpawn -= Time.deltaTime;
            }

        }
    }
}
