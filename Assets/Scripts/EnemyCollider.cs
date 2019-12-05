using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.GetType());
        if (other.GetType() == typeof(PolygonCollider2D))
        {
            other.GetComponent<PlayerController>().setDead(true);
        }
    }
}
