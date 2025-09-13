using UnityEngine;
using System.Collections.Generic;

public class InteractablePlace : MonoBehaviour
{
    [SerializeField]
    private List<ItemTrade> Trades;

    [SerializeField]
    private GameObject tradesObject;

    private void Awake()
    {
        
    }

    private void Start()
    {
        tradesObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player))
        {
            Debug.Log("Trading");
            tradesObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D  other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player))
        {
            Debug.Log("Trading");
            tradesObject.SetActive(false);
        }
    }

}
