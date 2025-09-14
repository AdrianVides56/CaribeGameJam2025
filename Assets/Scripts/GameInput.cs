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

    void OnDestroy()
    {
        inputActions.Disable();
    }

    public void ToggleMovementInput(bool enable)
    {
        if (enable)
        {
            inputActions.Enable();
            inputActions.Player.Direction.Enable();
        }
        else
        {
            inputActions.Player.Direction.Disable();
        }
    }

    public Vector2 GetMoveInput()
    {
        return inputActions.Player.Direction.ReadValue<Vector2>();
    }

    public bool IsRunPressed()
    {
        return inputActions.Player.Run.IsPressed();
    }
    public bool IsMovePressed()
    {
        return inputActions.Player.Direction.IsPressed();
    }

    public bool IsSpacePressed()
    {
        return inputActions.Player.Space.IsPressed();
    }

    public bool IsPausePressed()
    {
        return inputActions.Player.Pause.IsPressed();
    }
}
