using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static SceneManager instance;

    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject startingGameUI; 
    private void Awake()
    {
        Application.targetFrameRate = 60;
        instance = this;
    }

    public void GameOverScreenAppear(bool _conditionGameOver)
    {
        gameOverUI.SetActive(_conditionGameOver);
    }

    public void StartinGameAppear(bool _conditionStartingGame)
    {
        startingGameUI.SetActive(_conditionStartingGame);
    }
}
