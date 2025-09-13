using UnityEngine;
using System.Collections;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set;}

    private InputActions inputActions;


    private void Awake()
    {
        Instance = this;

        inputActions = new InputActions();

        inputActions.Enable();

    }

    public bool IsUpPressed() {
        return inputActions.Movement.Up.IsPressed();
    }

    public bool IsDownPressed() {
        return inputActions.Movement.Down.IsPressed();
    }

    public bool IsLeftPressed() {
        return inputActions.Movement.Left.IsPressed();
    }

    public bool IsRightPressed() {
        return inputActions.Movement.Right.IsPressed();
    }
}
