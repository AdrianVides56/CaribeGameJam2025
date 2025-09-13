using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class InteractablePlace : MonoBehaviour
{
    [SerializeField]
    private Backpack backpack;
    [SerializeField] private Canvas canvas;
    [SerializeField] private Button interactButton;

    private bool canInteract = true;
    private bool isInteracting = false;


    private void Awake()
    {
        interactButton.onClick.AddListener(OnInteractClicked);
        canvas.enabled = false;
    }

    private void Start()
    {
    }

    private void OnInteractClicked()
    {
        Debug.Log("Cambalacheando!");
    }

    public void OnPlayerEnterTrigger()
    {
        //Debug.Log("Player Enter Trigger Place");

        isInteracting = true;
        backpack.ToggleBackpack(true);
        backpack.ItemImageOnly();

        canvas.enabled = true;
    }

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
