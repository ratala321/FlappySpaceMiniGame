using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstacleRandomizer : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclesUp; //for the upper side of the obstacle
    [SerializeField] private GameObject[] obstaclesDown; // for the downward side of the obstacle

    [Header("References")]
    [SerializeField] private GameObject player;
    // [SerializeField] private float despawnTime; // time until the obstacle disappear

    private Transform[] initalpositionObstaclesUp;
    private Transform[] initalpositionObstaclesDown;

    private int obstaclenumber; //for the random selection of an obstacle
    private int lastobstaclenumber;
    
    private int secondlastnumber; // not working properly yet*

    private void Awake()
    {
        

    }

    public void ObstacleApparition()
    {
        obstaclenumber = ObstacleNumberCheck();

        obstaclesUp[obstaclenumber].SetActive(true);
        obstaclesDown[obstaclenumber].SetActive(true);
        
    }

    private int ObstacleNumberCheck() //to not get the same number twice
    {
        obstaclenumber = Random.Range(0, obstaclesUp.Length - 1);

        if (obstaclenumber == lastobstaclenumber || obstaclenumber == secondlastnumber)
        {
            for (int i = 0; i < obstaclesUp.Length; i++)
            {
                if (!obstaclesUp[i].activeInHierarchy)
                    obstaclenumber = i;

                //secondlastnumber = lastobstaclenumber;

                lastobstaclenumber = obstaclenumber;
            }
        }
        else
        {
            //secondlastnumber = lastobstaclenumber;

            lastobstaclenumber = obstaclenumber;
        }
            return obstaclenumber;
        
    }

    public void GameRestart()
    {
        for (int i = 0; i < obstaclesUp.Length; i++)
        {
            //reset of Obstacle
            obstaclesUp[i].SetActive(false);
            obstaclesDown[i].SetActive(false);

            //reset of Obstacle Speed
            obstaclesUp[i].GetComponent<ObstacleMovement>().SpeedIncrease(0);
            obstaclesDown[i].GetComponent<ObstacleMovement>().SpeedIncrease(0);
            
        }
        
        player.SetActive(true);

        player.transform.position = new Vector3(-3, 0, 0); //reset player position
        
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero; // reset player speed
        
        ObstacleApparition();
        
        SceneManager.instance.GameOverScreenAppear(false); // take off game over screen
        SceneManager.instance.StartinGameAppear(false);

        ScoreManager.instance.ResetScore();
        ScoreManager.instance.ResetScoreAtWhichSpeedIncrease();
    }

    public void SpeedIncreaseObstacleSelector(float _speedIncreaseIntermediateValue)
    {
        for (int i = 0; i < obstaclesUp.Length; i++)
        {
            obstaclesUp[i].GetComponent<ObstacleMovement>().SpeedIncrease(_speedIncreaseIntermediateValue);
            obstaclesDown[i].GetComponent<ObstacleMovement>().SpeedIncrease(_speedIncreaseIntermediateValue);
        }
    }
}
