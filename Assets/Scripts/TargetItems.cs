using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetItems : MonoBehaviour
{
    public static TargetItems Instance { get; private set; }

    [SerializeField]
    private Backpack backpack;

    [SerializeField] private List<Image> itemChecks;
    [SerializeField] private List<Image> itemIcons;

    [SerializeField]
    private List<EItem> itemsToCollect;

    [SerializeField]
    private List<bool> collectedItems;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        int i = 0;
        foreach (Image check in itemChecks)
        {
            check.enabled = false;
            if (GameManager.Instance.GetItemDataDict().TryGetValue(itemsToCollect[i], out ItemData data))
            {
                if (i < itemIcons.Count)
                    itemIcons[i].sprite = data.image;
            }
        }
    }

    public List<EItem> GetTargetItems() => itemsToCollect;

    public void TargetItemFound(int idx)
    {
        if (idx < itemChecks.Count)
        {
            itemChecks[idx].enabled = true;
            collectedItems[idx] = true;
        }

        CheckWinGame();

    }

    private void CheckWinGame()
    {
        foreach (bool check in collectedItems)
        {
            if (check == false)
                return;
        }

        EndScreen.Instance.GameEnded();
    }

    public List<bool> GetCollectedItems() => collectedItems;
}
