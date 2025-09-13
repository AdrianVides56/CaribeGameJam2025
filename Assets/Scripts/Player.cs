using UnityEngine;
using System.Collections;
using System;


public class Player : MonoBehaviour
{
    private Rigidbody2D rigidBody;


    public EventHandler OnPlayerMove;

    [SerializeField] private float moveSpeed = 250f;
    [SerializeField] private float RunMultiplier = 2f;


    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        if (GameInput.Instance.IsMovePressed())
        {
            float xVelocity, yVelocity;
            if (GameInput.Instance.IsRunPressed())
            {
                xVelocity = GameInput.Instance.GetMoveInput().x * Time.deltaTime * moveSpeed * RunMultiplier;
                yVelocity = GameInput.Instance.GetMoveInput().y * Time.deltaTime * moveSpeed * RunMultiplier;
            }
            else
            {
                xVelocity = GameInput.Instance.GetMoveInput().x * Time.deltaTime * moveSpeed;
                yVelocity = GameInput.Instance.GetMoveInput().y * Time.deltaTime * moveSpeed;
            }

            rigidBody.linearVelocity = new Vector2(xVelocity, yVelocity);
            
        }

    }

}
