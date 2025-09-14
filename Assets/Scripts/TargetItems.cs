using System.Collections.Generic;
using UnityEngine;

public class TargetItems : MonoBehaviour
{
    [SerializeField]
    private Backpack backpack;

    [SerializeField] private List<SpriteRenderer> itemChecks;

    void Start()
    {
        foreach (SpriteRenderer check in itemChecks)
        {
            check.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
