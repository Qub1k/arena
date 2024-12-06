using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLocomotionManager : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private bool isGrounded;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private InputActionReference jumpInput;
    [SerializeField] private Transform enemy;
    [SerializeField] private Transform groundCheck;


    private Rigidbody2D rb;
    private Vector2 playerInput;
    private bool isFacingRight = true;
    private Action onGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        PlayerInputManager.Instance.InputActions.Player.Jump.performed += i => Jump();
    }

    void FixedUpdate()
    {   
        playerInput = PlayerInputManager.Instance.MovementInput;
        Flip();

        rb.linearVelocity = playerInput * Time.fixedDeltaTime * speed * 100;
        if(CutsceneManager.activeCutscene) rb.linearVelocity = Vector2.zero;
        Debug.Log(CutsceneManager.activeCutscene == null);
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

    public void Jump(){
        if(isGrounded)
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Ground"){
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D col){
        if(col.gameObject.tag == "Ground"){
            isGrounded = false;
        }
    }
}
