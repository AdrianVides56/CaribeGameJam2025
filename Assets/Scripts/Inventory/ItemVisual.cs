using TMPro;
using UnityEngine;

public class ItemVisual : MonoBehaviour
{
    [SerializeField] private SpriteRenderer itemImage;
    [SerializeField] private TextMeshPro itemTitle;
    [SerializeField] private TextMeshPro itemDescription;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        ToggleAll(false);
    }

    public void ToggleAll(bool enable)
    {
        itemImage.enabled = enable;
        itemTitle.enabled = enable;
        itemDescription.enabled = enable;
    }

    public void ToggleProperties(bool enableTitle, bool enableImage, bool enableDesc)
    {
        if (itemTitle != null)
            itemTitle.enabled = enableTitle;

        if (itemImage != null)
            itemImage.enabled = enableImage;

        if (itemDescription != null)
            itemDescription.enabled = enableDesc;
    }
    public void Changevisuals(TextMeshPro newTitle, TextMeshPro newDesc, Sprite newImage)
    {
        if (itemImage != null)
            itemImage.sprite = newImage;
        if (itemTitle != null)
            itemTitle.text = newTitle.text;
        if (itemDescription != null)
            itemDescription.text = newDesc.text;
    }
    public void Changevisuals(string newTitle, string newDesc, Sprite newImage)
    {
        if (itemImage != null)
            itemImage.sprite = newImage;
        if (itemTitle != null)
            itemTitle.text = newTitle;
        if (itemDescription != null)
            itemDescription.text = newDesc;
    }

    public TextMeshPro GetTitle() => itemTitle;
    public TextMeshPro GetDesc() => itemDescription;
    public Sprite GetSprite() => itemImage.sprite;
}
