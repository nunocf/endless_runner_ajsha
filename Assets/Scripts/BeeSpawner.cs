using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeSpawner : MonoBehaviour
{

    [SerializeField] private ObjectPooler objectPool;

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
            int beeAmount = Random.Range(1, 4);

            for (int i = 0; i < beeAmount; i++)
            {
                Vector3 position = transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(0.3f, 1.2f), 0);
                GameObject bee = objectPool.GetPooledObject();
                bee.transform.position = position;
                bee.transform.rotation = Quaternion.identity;
                bee.SetActive(true);
            }
            timeBetweenSpawn = startTimeBetweenSpawn;
            if (startTimeBetweenSpawn > minTime)
            {
                startTimeBetweenSpawn -= Time.deltaTime;
            }

        }
    }

    public void StopMovement()
    {
        foreach (GameObject b in objectPool.GetAll())
        {
            Bee bee = b.GetComponent<Bee>();
            Debug.Log(bee);
            if (bee != null) { bee.SetMovement(false); }
        }
    }
}
