
using UnityEngine;
using TMPro;

public static class StaticScore
{
    public static int score { get; set; }
    public static int highScore
    {
        get { return PlayerPrefs.GetInt("HighScore", 0); }
        set { PlayerPrefs.SetInt("HighScore", value); }
    }


}
public class FinalScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    void Start()
    {
        scoreText.text = StaticScore.score.ToString();
        highScoreText.text = StaticScore.highScore.ToString();
    }
}
