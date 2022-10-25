using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text ScoreUI;

    public static ScoreManager instance;
    private int currentScore;


    private void Awake()
    {
        instance = this;
    }
    public void AddScore(int _addvalue)
    {
        currentScore += _addvalue;
        ScoreUI.text = "Score : " + currentScore;
    }
}
