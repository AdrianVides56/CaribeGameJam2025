using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    [SerializeField]
    private Player player;
    private Animator _animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D playerRB;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (player.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigidbody2D))
        {
            playerRB = rigidbody2D;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //_animator.SetBool("IsWalking", player.GetIsPlayerWalking());
        _animator.SetBool("IsWalking", GameInput.Instance.IsMovePressed());
        _animator.SetBool("IsRunning", GameInput.Instance.IsRunPressed());

        if (playerRB != null && spriteRenderer != null)
        {
            spriteRenderer.flipX = playerRB.linearVelocityX < 0 ? false : true;
        }
    }
}
