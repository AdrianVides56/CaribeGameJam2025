using UnityEngine;

public class PrecisionBar : Minigame
{
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private RectTransform bar;
    [SerializeField]
    private RectTransform sweetSpot;
    [SerializeField]
    private RectTransform handle;
    [SerializeField]
    private float speed;

    private float edge;
    private float winSpace;
    private bool movingRight = true;

    void Awake()
    {
        canvas.enabled = false;
    }

    void OnEnable()
    {
        Debug.Log("Precision Bar Enabled");
    }

    void OnDisable()
    {
        Debug.Log("Precision Bar Disabled!");
    }

    // Update is called once per frame
    void Update()
    {
        MoveHandle();

        if (canPressKey && GameInput.Instance.IsSpacePressed())
        {
            canPressKey = false;

            if (CheckStopHandle())
            {
                TriggerEnd(true);
            }
            else
            {
                TriggerEnd(false);
            }

            this.enabled = false;
        }
    }

    bool CheckStopHandle()
    {
        if (Mathf.Abs(handle.anchoredPosition.x) < winSpace)
            return true;

        return false;
    }

    private void MoveHandle()
    {
        float step = speed * Time.deltaTime;

        if (movingRight)
            handle.anchoredPosition += new Vector2(step, 0);
        else
            handle.anchoredPosition -= new Vector2(step, 0);

        // Go Right
        if (movingRight && handle.anchoredPosition.x >= edge)
            movingRight = false;
        // Go Left
        else if (!movingRight && handle.anchoredPosition.x <= -edge)
            movingRight = true;
    }


    public override void StartMinigame()
    {
        base.StartMinigame();

        canvas.enabled = true;
        
        canPressKey = true;
    }

    protected override void Initialize()
    {
        base.Initialize();

        edge = bar.rect.width / 2;
        winSpace = sweetSpot.rect.width / 2;
    }
}
