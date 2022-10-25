using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private float initalpositionx;

    private float direction = 1; // obstacle will always go to the left

    private void OnEnable()
    {
        initalpositionx = transform.position.x;
    }

    private void OnDisable()
    {
        transform.position = new Vector3 (initalpositionx, transform.position.y, transform.position.z);
    }
    private void Update()
    {
        transform.Translate(0f, (direction * speed * Time.deltaTime), 0f); // translate on Y axis positive because of the rotation of the obstacle

        //position reset + object desactivation
        if (transform.position.x <= -9f)
        {
            transform.position = new Vector3 (initalpositionx, transform.position.y, transform.position.z);
            gameObject.SetActive(false);
        }
    }
}
