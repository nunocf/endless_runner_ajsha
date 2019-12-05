﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeSpawner : MonoBehaviour
{

    [SerializeField] private GameObject bee;

    [SerializeField] private float startTimeBetweenSpawn;

    [SerializeField] private float decreaseTime;

    [SerializeField] private float minTime = 0.65f;
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
            int beeAmount = Random.Range(1, 3);

            for (int i = 0; i < beeAmount; i++)
            {
                Vector3 position = transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(0f, 1.2f), 0);
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
