using UnityEngine;

public class Backpack : MonoBehaviour
{
    [SerializeField] private float capacity = 4;

    [SerializeField] private Item[] items = new Item[4];

    void OnEnable()
    {
        Debug.Log("Enabled!");
    }

    void OnDisable()
    {
        Debug.Log("OnDisable"); ;
    }

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
}
