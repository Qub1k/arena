using UnityEngine;

public class PlayerLocomotionManager : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D rb;
    private Vector2 playerInput;
    private bool isFacingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        playerInput = PlayerInputManager.Instance.MovementInput;
        Flip();

        rb.linearVelocityX = playerInput.x * Time.fixedDeltaTime * speed * 100;
    }

    private void Flip()
    {
        if(isFacingRight && playerInput.x < 0 || !isFacingRight && playerInput.x > 0)
        {
            isFacingRight = !isFacingRight;
            Vector2 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
