using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    [SerializeField] private float capacity = 4;

    [SerializeField] private List<Item> items = new List<Item>();


    public void ItemImageOnly()
    {
        foreach (Item item in items)
        {
            item.GetItemVisual().ToggleProperties(false, true, false);
        }
    }

    public void ToggleBackpack(bool enable)
    {
        gameObject.SetActive(enable);
    }

    public List<Item> GetItems() => items;

    public Item GetItemAt(int idx) => items[idx];

    public void RemoveItem(int idx)
    {
        items.RemoveAt(idx);
    }

    public void InsertItem(Item item, int idx)
    {
        items.Add(item);
    }
}
