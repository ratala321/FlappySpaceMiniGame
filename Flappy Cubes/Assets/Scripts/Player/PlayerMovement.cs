using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float sideSpeed;

    private Rigidbody2D rbd;

    private void Awake()
    {
        rbd = GetComponent<Rigidbody2D>();
        gameObject.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            Jump();


        //Cut the speed of a Jump if Space is not hold -> holding Space = bigger jump, quick pressing Space = small jump
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            rbd.velocity = new Vector2(rbd.velocity.x, rbd.velocity.y / 2);
        }

        rbd.velocity = new Vector2 (Input.GetAxis("Horizontal") * sideSpeed, rbd.velocity.y); // side movement

        //condition de défaite selon la positon à ajouter!
        GameOverCondition();

    }

    private void Jump()
    {
        rbd.velocity = new Vector3 (0f, jumpSpeed, 0f);

    }

    private void GameOverCondition()
    {
        if (transform.position.x <= -8.78 || transform.position.y <= -7)
        {
            SceneManager.instance.GameOverScreenAppear(true);

            ScoreManager.instance.SetHighScore();
            
            gameObject.SetActive(false);
        }
    }
}
