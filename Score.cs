using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [SerializeField] Text ScoreText;
    [SerializeField] Text HightScoreText;

    public static int score;
    public int hightScore;
    public static Score instance;

    private void Awake()
    {
        
        instance = this;

        if (PlayerPrefs.HasKey("SaveScore"))
        {
            hightScore = PlayerPrefs.GetInt("SaveScore");
        }

        score = 0;
    }
    private void Update()
    {
        ScoreText.text = "Очки: " + score.ToString();
        HightScoreText.text = "Рекорд: " + hightScore.ToString();

        if (Input.GetKeyDown(KeyCode.Backslash))
        {
            Invoke("RestartLevel", 1f);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ReserHightScore();
        }

        if (score < 0)
        {
            score = 0;
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void AddScore(int getScore)
    {
        score += getScore;

        instance.HightScore();
    }

    private void HightScore()
    {
        if (score > hightScore)
        {
            hightScore = score;

            PlayerPrefs.SetInt("SaveScore", hightScore);
        }
    }

    private void ReserHightScore()
    {           
            PlayerPrefs.DeleteKey("SaveScore");

            hightScore = 0;        
    }

}
