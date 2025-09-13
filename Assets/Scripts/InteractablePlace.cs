using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class InteractablePlace : MonoBehaviour
{
    [SerializeField]
    private Backpack backpack;
    [SerializeField] private Canvas canvas;
    [SerializeField] private Button interactButton;
    [SerializeField] private Minigame minigame;

    private bool canInteract = true;
    private bool isInteracting = false;


    private void Awake()
    {
        interactButton.onClick.AddListener(OnInteractClicked);
        canvas.enabled = false;
    }

    private void Start()
    {
        minigame.minigameEndedEvent.AddListener(OnMinigameEnded);
        backpack.ToggleBackpack(false);
    }

    private void OnMinigameEnded(bool bWon)
    {
        if (bWon)
        {
            Debug.Log("WIN!", gameObject);
            //Do the Cambalache
            //remove item from backpack
            List<Item> PlaceItems = backpack.GetItems();
            int idxToTrade = Random.Range(0, PlaceItems.Count);
            while (true)
            {
                if (GameManager.Instance.GetPlayer().IdxUsedInLoop.Contains(idxToTrade))
                    idxToTrade = Random.Range(0, PlaceItems.Count);
                else
                {
                    GameManager.Instance.GetPlayer().IdxUsedInLoop.Add(idxToTrade);
                    break;
                }
            }
            Item itemToTrade = PlaceItems[idxToTrade];

            Item PlayerItemToReplace = GameManager.Instance.GetPlayer().backpack.GetItemAt(idxToTrade);
            PlayerItemToReplace.Trade(
                itemToTrade.GetItemVisual().GetTitle(),
                itemToTrade.GetItemVisual().GetDesc(),
                itemToTrade.GetItemVisual().GetSprite());


            backpack.RemoveItem(idxToTrade);

            Destroy(itemToTrade.gameObject, 1f);
        }
        else
        {
            Debug.Log("Lose", gameObject);
        }
        // cannot interact till interact with other place
        SetCanInteract(false);
    }

    private void OnInteractClicked()
    {
        GameManager.Instance.interactedWithPlaceEvent.Invoke(this);

        //interactButton.enabled = false;
        canvas.enabled = false;
        minigame.StartMinigame();
    }

    public void OnPlayerEnterTrigger()
    {
        //Debug.Log("Player Enter Trigger Place");

        // TODO: popup saying to look other places
        if (!canInteract)
            return;

        isInteracting = true;
        backpack.ToggleBackpack(true);
        backpack.ItemImageOnly();

        canvas.enabled = true;
    }

    public void SetCanInteract(bool value) => canInteract = value;


    public void OnPlayerExitTrigger()
    {
        //Debug.Log("Player Exit Trigger Place");
        backpack.ToggleBackpack(false);
        canvas.enabled = false;
    }


    public void EndInteraction()
    {
        isInteracting = false;
    }

}
