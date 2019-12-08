using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    private float moveSpeed;
    private float maxSpeed = -2f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = Random.Range(0f, maxSpeed);
        rb.velocity = new Vector2(moveSpeed, 0);
    }

}
