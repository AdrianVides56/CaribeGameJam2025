using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private Dictionary<EItem, ItemData> itemDataDict;
    [SerializeField]
    private List<ValuePair<EItem, ItemData>> itemData = new List<ValuePair<EItem, ItemData>>();

    [SerializeField]
    private Player player;

    private InteractablePlace lastPlaceInteracted;

    public UnityEvent<InteractablePlace> interactedWithPlaceEvent;
    private bool IsPaused = false;
    [SerializeField]
    private OptionsMenu optionsMenu;

    void Awake()
    {
        Instance = this;

        itemDataDict = itemData.ToDictionary(pair => pair.Key, pair => pair.Value);
    }

    private void Start()
    {
        Application.targetFrameRate = 60;

        interactedWithPlaceEvent = new UnityEvent<InteractablePlace>();

        interactedWithPlaceEvent.AddListener(OnInteractedWithPlace);
    }

    void Update()
    {
        if (!IsPaused && GameInput.Instance.IsPausePressed())
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        optionsMenu.gameObject.SetActive(true);
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1f;
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

    public Dictionary<EItem, ItemData> GetItemDataDict() => itemDataDict;
}

[System.Serializable]
public class ValuePair<TKey, TValue>
{
    public TKey Key;
    public TValue Value;

    public ValuePair(TKey key, TValue value)
    {
        Key = key;
        Value = value;
    }
}