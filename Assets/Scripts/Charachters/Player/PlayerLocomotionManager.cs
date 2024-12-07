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
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {   
        playerInput = PlayerInputManager.Instance.MovementInput;
        //Flip();

        if(CutsceneManager.activeCutscene){
            rb.linearVelocity = Vector2.zero;
            return;
        } 

        rb.linearVelocity = playerInput * Time.fixedDeltaTime * speed * 100;

        if(playerInput.x > 0){
            anim.Play("run_right");
        }
        else if(playerInput.x < 0){
            anim.Play("run_left");
        }
        else if(playerInput.y > 0){
            anim.Play("run_backwards");
        }
        else if(playerInput.y < 0){
            anim.Play("run_forward");
        }
        else{
            anim.Play("idle");
        }
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
