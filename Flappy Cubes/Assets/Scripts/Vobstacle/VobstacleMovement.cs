using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VobstacleMovement : MonoBehaviour
{
    private Vector3 initialposition;
    [SerializeField] private float speed;
    private float lifeTimerCounter;
    [SerializeField] private float lifeTimer;
    private bool activity;
    [SerializeField] private float desactivationPosition;

    private void Awake()
    {
        initialposition = transform.position;
        activity = true;
    }

    private void Update()
    {
        transform.Translate(0f, speed * Time.deltaTime, 0f);

        if (transform.position.y >= desactivationPosition || transform.position.y <= -desactivationPosition)
        {
            activity = false;
            lifeTimerCounter = 0;
        }

        lifeTimerCounter += Time.deltaTime;

        if (!activity)
        {   
            if(lifeTimerCounter > lifeTimer)
            {
                transform.position = initialposition;
                activity = true;
            }
        }
    }
}
