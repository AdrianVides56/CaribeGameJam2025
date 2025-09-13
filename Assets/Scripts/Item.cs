using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemVisual itemVisual;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public ItemVisual GetItemVisual() => itemVisual;
}

public struct ItemTrade
{
    public Item item;
    public Item tradeFor;
}
