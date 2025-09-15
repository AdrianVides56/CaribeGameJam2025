using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class InteractablePlace : MonoBehaviour
{
    [SerializeField]
    private Backpack backpack;
    [SerializeField] private Canvas interactCanvas;
    [SerializeField] private Button interactButton;
    [SerializeField] private Minigame minigame;

    [SerializeField] private AudioSource winMnigameAudio;
    [SerializeField] private AudioSource loseMnigameAudio;


    private bool canInteract = true;
    private bool isInteracting = false;

    /*
        TODO:
        Register the trigger collision for the notification
        Create notification manager
            - Will contain sets of notifications (images) for the different locations
            - Will contain sets depending on can interact
            - will contatin sets depending if won or lose
    */


    private void Awake()
    {
        interactButton.onClick.AddListener(OnInteractClicked);
        interactCanvas.enabled = false;
    }

    private void Start()
    {
        minigame.minigameEndedEvent.AddListener(OnMinigameEnded);
        backpack.ToggleBackpack(false);
    }

    private void OnEnable()
    {
        minigame.minigameEndedEvent.AddListener(OnMinigameEnded);       
        
    }

    private void OnDisable()
    {
        minigame.minigameEndedEvent.RemoveListener(OnMinigameEnded);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            //PopupManager.Instance.Push(EPopups.)
        }
    }

    private void OnMinigameEnded(bool bWon)
    {
        /* Debug.Log("LOG: OnMinigameEnded");
        Debug.LogError("OnMinigameEnded Called"); */
        if (bWon)
        {
            /* Debug.LogError("OnMinigameEnded: Won"); */
            winMnigameAudio.Play();
            //            Debug.Log("WIN!", gameObject);
            //Do the Cambalache
            //remove item from backpack
            List<Item> PlaceItems = backpack.GetItems();
            int idxToTrade = Random.Range(0, PlaceItems.Count);

            Player player = GameManager.Instance.GetPlayer();
            if (player.IdxUsedInLoop.Count < player.backpack.GetCapacity())
            {
                while (true)
                {
                    if (TargetItems.Instance.GetCollectedItems().Count > 0 && TargetItems.Instance.GetCollectedItems()[idxToTrade])
                        idxToTrade = Random.Range(0, PlaceItems.Count);
                    else
                    {
                        player.IdxUsedInLoop.Add(idxToTrade);
                        break;
                    }
                }
            }
            Item itemToTrade = PlaceItems[idxToTrade];

            if (GameManager.Instance.GetItemDataDict().TryGetValue(itemToTrade.GetEItem(), out ItemData tradeData))
            {
                //Debug.LogError("OnMinigameEnded: Cambalache");
                Item PlayerItemToReplace = player.backpack.GetItemAt(idxToTrade);

                // It's a target Item
                if (TargetItems.Instance.GetTargetItems().Contains(itemToTrade.GetEItem()))
                {
                    int idx = TargetItems.Instance.GetTargetItems().IndexOf(itemToTrade.GetEItem());
                    TargetItems.Instance.TargetItemFound(idx);
                    PopupManager.Instance.Push(EPopups.winTargetItem);
                }
                else // It's another Item
                {
                    PlayerItemToReplace.Trade(tradeData);
                    PopupManager.Instance.Push(EPopups.winOtherItem);
                }
            }


            backpack.RemoveItem(idxToTrade);

            Destroy(itemToTrade.gameObject, 1f);
        }
        else
        {
            //Debug.LogError("OnMinigameEnded: Lose");
            // TODO: lose sound
            //Debug.Log("Lose", gameObject);
            loseMnigameAudio.Play();
            PopupManager.Instance.Push(EPopups.loseMinigame);
        }
        // cannot interact till interact with other place
        SetCanInteract(false);
    }

    private void OnInteractClicked()
    {
        GameManager.Instance.interactedWithPlaceEvent.Invoke(this);

        //interactButton.enabled = false;
        interactCanvas.enabled = false;
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

        interactCanvas.enabled = true;
    }

    public void SetCanInteract(bool value) => canInteract = value;


    public void OnPlayerExitTrigger()
    {
        //Debug.Log("Player Exit Trigger Place");
        backpack.ToggleBackpack(false);
        interactCanvas.enabled = false;
    }


    public void EndInteraction()
    {
        isInteracting = false;
    }

}
