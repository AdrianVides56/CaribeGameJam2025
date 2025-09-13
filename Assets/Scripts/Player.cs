using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour
{
    private CharacterController characterController;
    private Rigidbody2D rigidBody;
    private Vector2 MoveDir;
    [SerializeField] private float MoveSpeed = 10f;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        rigidBody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        PlayerInput();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.TryGetComponent<InteractablePlace>(out InteractablePlace interactablePlace))
        {
            Debug.Log("Trading");
        }
    }

    private void PlayerInput()
    {
        //MoveDir = new Vector2();

        if (GameInput.Instance.IsUpPressed())
        {
            rigidBody.AddForce(transform.up * MoveSpeed * Time.deltaTime);
            MoveDir.y = 1;
        }

        if (GameInput.Instance.IsDownPressed())
        {
            rigidBody.AddForce(-transform.up * MoveSpeed * Time.deltaTime);
            //MoveDir.y = -1;
        }
        if (GameInput.Instance.IsLeftPressed())
        {
            rigidBody.AddForce(-transform.right * MoveSpeed * Time.deltaTime);
            //MoveDir.x = -1;
        }
        if (GameInput.Instance.IsRightPressed())
        {
            rigidBody.AddForce(transform.right * MoveSpeed * Time.deltaTime);
            //MoveDir.x = 1;
        }


        //characterController.Move(MoveDir * Time.deltaTime * MoveSpeed);
    }

}
