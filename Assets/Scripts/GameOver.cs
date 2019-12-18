
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void PlayAgain()
    {
        Invoke("LoadMainLevel", .5f);
    }
    public void BackToMainMenu()
    {
        Invoke("LoadMainMenu", .5f);
    }

    private void LoadMainLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
