using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAdder : MonoBehaviour
{
    [SerializeField] private int addvalue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ScoreManager.instance.AddScore(addvalue);
            
            GetComponentInParent<ObstacleRandomizer>().ObstacleApparition();
        }
    }
}
