
using UnityEngine;
using TMPro;

public static class StaticScore
{
    public static string score { get; set; }
}
public class FinalScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    void Start()
    {
        scoreText.text = StaticScore.score;
    }
}
