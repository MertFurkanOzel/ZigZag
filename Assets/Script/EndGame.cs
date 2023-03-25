using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGame : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI Highscore;

    private void Awake()
    {
        int Score = PlayerPrefs.GetInt("Score");
        int highScore = Score;
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore= PlayerPrefs.GetInt("HighScore");
        }
        if(Score>highScore||!PlayerPrefs.HasKey("HighScore"))
        {
            highScore = Score;
            PlayerPrefs.SetInt("HighScore",highScore);
        }
        score.text = Score.ToString();
        Highscore.text = highScore.ToString();
    }

    public void button_retry()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    public void button_quit()
    {
        Application.Quit();
    }
}
