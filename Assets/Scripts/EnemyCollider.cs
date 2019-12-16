using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    private GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetType() == typeof(PolygonCollider2D))
        {
            other.GetComponent<Animator>().enabled = false;
            other.GetComponent<PlayerController>().dead = true;
            gameManager.GameOver();
        }
    }
}
