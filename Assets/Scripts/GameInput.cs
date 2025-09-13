using UnityEngine;
using System.Collections;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    private InputActions inputActions;

    private void Awake()
    {
        Instance = this;

        inputActions = new InputActions();

        inputActions.Enable();

    }

    public Vector2 GetMoveInput()
    {
        return inputActions.Movement.Direction.ReadValue<Vector2>();
    }

    public bool IsRunPressed()
    {
        return inputActions.Movement.Run.IsPressed();
    }
    public bool IsMovePressed()
    {
        return inputActions.Movement.Direction.IsPressed();
    }
}
