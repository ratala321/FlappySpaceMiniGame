using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCastPooling : MonoBehaviour
{
    [SerializeField] private ObstacleRandomizer obstacleRandomizer;

    [Header("Gizmos/Raycast Set Up")]
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private float positionBoxCast;
    [SerializeField] private float sizeBoxCast;

    private void Awake()
    {
    
    }
    private void Update()
    {
        if (CheckPlayerHit())
            obstacleRandomizer.ObstacleApparition();
    }

    private bool CheckPlayerHit()
    {
        RaycastHit2D playerHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.left, 1f, playerLayer);

        return playerHit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * positionBoxCast, boxCollider.bounds.size + transform.right * sizeBoxCast); 
    }
}
