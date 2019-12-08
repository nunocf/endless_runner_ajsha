using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    [SerializeField] private GameObject ground;
    [SerializeField] private Transform generationPoint;
    [SerializeField] private ObjectPooler objectPool;
    private float width;
    // Start is called before the first frame update
    void Start()
    {
        width = ground.GetComponent<BoxCollider2D>().size.x;
    }


    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            transform.position += new Vector3(width - 1, 0, 0);

            GameObject newGround = objectPool.GetPooledObject();
            newGround.transform.position = transform.position;
            newGround.transform.rotation = transform.rotation;
            newGround.SetActive(true);
        }
    }
}
