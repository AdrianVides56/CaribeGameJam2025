using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemVisual itemVisual;
    [SerializeField] private EItem eItem;

    public ItemVisual GetItemVisual() => itemVisual;
    public EItem GetEItem() => eItem;

    private void Start()
    {
        var itemDataDict = GameManager.Instance.GetItemDataDict();
        if (itemDataDict.TryGetValue(eItem, out ItemData itemData))
        {
            itemVisual.Changevisuals(itemData.title, itemData.description, itemData.image);
            Debug.Log("Found Data! updating visuals");
        }
    }

    public void Trade(TextMeshPro newTitle, TextMeshPro newDesc, Sprite newImage)
    {
        itemVisual.Changevisuals(newTitle, newDesc, newImage);
    }

    public void Trade(ItemData newData)
    {
        itemVisual.Changevisuals(newData.title, newData.description, newData.image);
    }
}

public enum EItem
{
    CaimanDelRio,
    Shakira,
    VentanaDelMundo,
    RioBus,
    MoteDeQueso,
    Mojarra,
    ArrozDeCoco,
    Carimañola,
    PibeValderrama,
    CamisetaJunior,
    CopoNieve,
    Seleccion,
    Iglesia,
    SimonBolivar,
    Aduana,
    Shopping,
    Coca,
    Moneda,
    Silla,
    Gorra
}