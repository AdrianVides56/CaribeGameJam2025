using TMPro;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemVisual itemVisual;

    public ItemVisual GetItemVisual() => itemVisual;

    public void Trade(TextMeshPro newTitle, TextMeshPro newDesc, Sprite newImage)
    {
        itemVisual.Changevisuals(newTitle, newDesc, newImage);
    }
}

public struct ItemTrade
{
    public Item item;
    public Item tradeFor;
}
