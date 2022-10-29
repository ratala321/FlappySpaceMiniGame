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

    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }

    private void OnEnable()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
