using TMPro;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemVisual itemVisual;
    [SerializeField] private EItem eItem;

    public ItemVisual GetItemVisual() => itemVisual;

    public void Trade(TextMeshPro newTitle, TextMeshPro newDesc, Sprite newImage)
    {
        itemVisual.Changevisuals(newTitle, newDesc, newImage);
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
    Shopping
}