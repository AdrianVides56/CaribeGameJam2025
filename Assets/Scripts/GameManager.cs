using System;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    private Player player;

    private InteractablePlace lastPlaceInteracted;

    public UnityEvent<InteractablePlace> interactedWithPlaceEvent;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Application.targetFrameRate = 60;

        interactedWithPlaceEvent = new UnityEvent<InteractablePlace>();

        interactedWithPlaceEvent.AddListener(OnInteractedWithPlace);
    }

    private void OnInteractedWithPlace(InteractablePlace placeInteracted)
    {
        Debug.Log("Interacted with place");
        if (placeInteracted != lastPlaceInteracted && lastPlaceInteracted != null)
        {
            lastPlaceInteracted.SetCanInteract(true);
        }

        lastPlaceInteracted = placeInteracted;
    }

    public Player GetPlayer() => player;
}
