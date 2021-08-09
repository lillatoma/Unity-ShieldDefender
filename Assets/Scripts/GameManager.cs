using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text highscoreText;

    [HideInInspector]
    public int score = 0;
    [HideInInspector]
    public int highscore = 0;


    void SaveHighscore()
    {
        if(score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("Highscore", score);
        }    
    }

    void LoadHighscore()
    {
        highscore = PlayerPrefs.GetInt("Highscore", 0);
    }

    void UpdateUI()
    {
        scoreText.text = score.ToString();
        highscoreText.text = "Best: " + highscore;
    }

    public void ResetGame()
    {
        SaveHighscore();
        score = 0;
        UpdateUI();
    }

    public void AddScore(int sc)
    {
        score += sc;
        UpdateUI();
    }

    void Start()
    {
        LoadHighscore();
        UpdateUI();
    }

}
