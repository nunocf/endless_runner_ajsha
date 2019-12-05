using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    [SerializeField] private GameObject ground;
    [SerializeField] private Transform generationPoint;
    [SerializeField] private float gap;
    private float width;
    // Start is called before the first frame update
    void Start()
    {
        width = ground.GetComponent<BoxCollider2D>().size.x;
        Debug.Log(width);
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < generationPoint.position.x)
        {
            transform.position += new Vector3(width + gap, 0, 0);
            Instantiate(ground, transform.position, Quaternion.identity);
        }
    }
}
