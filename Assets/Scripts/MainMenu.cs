using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    [SerializeField] private GameObject player;
    private PlayerMenuController playerMenuScript;

    private void Start()
    {
        playerMenuScript = player.GetComponent<PlayerMenuController>();
    }
    public void PlayGame()
    {

        playerMenuScript.playPressed = true;

        Invoke("LoadMainLevel", .5f);

    }

    void Update()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    private void LoadMainLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
