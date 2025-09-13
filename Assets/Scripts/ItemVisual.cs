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

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToggleAll(bool enable)
    {
        itemImage.enabled = enable;
        itemTitle.enabled = enable;
        itemDescription.enabled = enable;
    }

    public void ToggleProperties(bool enableTitle, bool enableImage, bool enableDesc)
    {
        itemTitle.enabled = enableTitle;
        itemImage.enabled = enableImage;
        itemDescription.enabled = enableDesc;
    }
}
