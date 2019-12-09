using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] GameObject pooledObject;
    [SerializeField] int pooledAmount;
    private List<GameObject> objectPool;
    // Start is called before the first frame update
    void Start()
    {
        objectPool = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            objectPool.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        GameObject foundObj = objectPool.Find(go => go.activeInHierarchy == false);

        if (foundObj) return foundObj;

        // instantiate a new one if all are taken.
        GameObject obj = (GameObject)Instantiate(gameObject);
        obj.SetActive(false);
        objectPool.Add(obj);
        return obj;
    }

    public List<GameObject> GetAll()
    {
        return objectPool;
    }
}
