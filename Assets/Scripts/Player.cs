using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;


public class Player : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    public Backpack backpack;

    [SerializeField] private float moveSpeed = 250f;
    [SerializeField] private float RunMultiplier = 2f;

    public List<int> IdxUsedInLoop = new List<int>();


    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<InteractablePlace>(out InteractablePlace interactablePlace))
        {
            interactablePlace.OnPlayerEnterTrigger();

            backpack.ToggleBackpack(true);
            backpack.ItemImageOnly();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<InteractablePlace>(out InteractablePlace interactablePlace))
        {
            interactablePlace.OnPlayerExitTrigger();

            backpack.ToggleBackpack(false);
        }
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
