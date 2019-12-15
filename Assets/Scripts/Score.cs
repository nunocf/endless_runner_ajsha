using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = (player.position.x + 5).ToString("0");
    }

    public int GetScore()
    {
        return int.Parse(scoreText.text);
    }
}
