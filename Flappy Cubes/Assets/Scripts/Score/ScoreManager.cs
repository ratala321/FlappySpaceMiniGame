using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [Header ("Text references")]
    [SerializeField] private Text currentScoreUI;
    [SerializeField] private Text highScoreUI;

    [Header("Obstacle Speed Increase by Score references")]
    [SerializeField] private GameObject obstacleList;
    [SerializeField]private int scoreAtWhichSpeedIncrease;
    private int initialScoreAtWhichSpeedIncrease; // to reset the score at which speed increase
    [SerializeField] private int nextScoreAtWhichSpeedIncrease;
    [SerializeField] private float speedIncreaseValue;
    private float _speedIncreaseValueToSend;

    public static ScoreManager instance;
    private int currentScore;
    private int highScore;
    

    private void Awake()
    {
        instance = this;

        highScore = 0;

        initialScoreAtWhichSpeedIncrease = scoreAtWhichSpeedIncrease;
    }
    public void AddScore(int _addvalue)
    {
        currentScore += _addvalue;
        currentScoreUI.text = "Score : " + currentScore;

        if (currentScore == scoreAtWhichSpeedIncrease)
        {
            _speedIncreaseValueToSend += speedIncreaseValue;

            obstacleList.GetComponent<ObstacleRandomizer>().SpeedIncreaseObstacleSelector(_speedIncreaseValueToSend);

            scoreAtWhichSpeedIncrease += nextScoreAtWhichSpeedIncrease;
        }
    }

    public void ResetScore()
    {
        currentScore = 0;
        currentScoreUI.text = "Score : " + currentScore;
    }

    public void SetHighScore()
    {
        if (currentScore > highScore)
        {
            highScore = currentScore;
            highScoreUI.text = "High Score : " + highScore;
        }
            
    }

    public void ResetScoreAtWhichSpeedIncrease()
    {
        scoreAtWhichSpeedIncrease = initialScoreAtWhichSpeedIncrease;

        _speedIncreaseValueToSend = 0; // reset speed modifiyer to the starting value
    }
}
