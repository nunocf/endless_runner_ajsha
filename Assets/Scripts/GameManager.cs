
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] float restartDelay = 0.5f;
    private bool gameHasEnded = false;
    private AudioManager audioManager;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    public void GameOver()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            FindObjectOfType<PlayerController>().SetMovement(false);
            FindObjectOfType<BeeSpawner>().StopMovement();

            audioManager.StopMainLevelSounds();
            Invoke("GameOverMenu", restartDelay);
        }

    }

    public void GameOverMenu()
    {
        int score = FindObjectOfType<Score>().GetScore();

        StaticScore.score = score;

        // If current score is highest so far, update highScore.
        if (score > StaticScore.highScore)
        {
            StaticScore.highScore = score;
        }



        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}