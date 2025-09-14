using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;
using System.Collections;

public class PopupManager : MonoBehaviour
{
    public static PopupManager Instance { get; private set; }


    [SerializeField]
    private float popupTime = 3f;
    [SerializeField]
    private List<ValuePair<EPopups, Image>> popups;
    Dictionary<EPopups, Image> popupsDict;

    private bool isCoroutineRunning = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        popupsDict = popups.ToDictionary(pair => pair.Key, pair => pair.Value);

        foreach (Image popup in popupsDict.Values)
        {
            popup.enabled = false;
        }
    }

    public void Push(EPopups ePopup)
    {
        foreach (KeyValuePair<EPopups, Image> entry in popupsDict)
        {
            if (entry.Key == ePopup)
                entry.Value.enabled = true;
            else
                entry.Value.enabled = false;
        }

        if (isCoroutineRunning)
            popupTime += 2f;
        else
            StartCoroutine(HidePopupTimer(popupTime));
    }

    IEnumerator HidePopupTimer(float duration)
    {
        float elapsedTime = 0f;
        isCoroutineRunning = true;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        foreach (KeyValuePair<EPopups, Image> entry in popupsDict)
        {
            entry.Value.enabled = false;
        }

        isCoroutineRunning = false;
    }
}

public enum EPopups
{
    loseMinigame,
    winTargetItem,
    winOtherItem,
    cannotInteract,
    arrivedMalecon,
    arrivedBarrioAbajo,
    arrivedEstadio
}
