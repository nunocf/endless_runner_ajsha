
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] float restartDelay = 1f;
    private bool gameHasEnded = false;
    public void GameOver()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            FindObjectOfType<PlayerController>().SetMovement(false);
            FindObjectOfType<BeeSpawner>().StopMovement();
            Invoke("RestartGame", restartDelay);
        }

    }

    public void RestartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}