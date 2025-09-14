using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    public EItem eItem;
    public string title;
    public string description;
    public Sprite image;
}
