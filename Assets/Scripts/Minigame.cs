using System;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Events;

public class Minigame : MonoBehaviour
{
    public UnityEvent<bool> minigameEndedEvent;

    protected bool canPressKey = false;

    void Start()
    {
        minigameEndedEvent = new UnityEvent<bool>();
    
        this.enabled = false;
    }


    public virtual void StartMinigame()
    {
        GameInput.Instance.ToggleMovementInput(false);
        gameObject.SetActive(true);
        this.enabled = true;
        Initialize();
    }

    public virtual void EndMinigame()
    {
        GameInput.Instance.ToggleMovementInput(true);
        gameObject.SetActive(false);
        this.enabled = false;
    }
    protected virtual void Initialize() { }

    protected void TriggerEnd(bool didWin)
    {
        minigameEndedEvent.Invoke(didWin);

        EndMinigame();
    }
}
