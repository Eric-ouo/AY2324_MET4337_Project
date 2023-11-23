using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask groundLayer;

    private float horizontalMove;
    private bool isJumping = false;
    private bool isGrounded = false;
    private Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }

        horizontalMove = Input.GetAxis("Horizontal") * speed;
        animator.SetBool("run", Mathf.Abs(horizontalMove) > 0f);
        animator.SetBool("Jump", isJumping);
    }

    private void FixedUpdate()
    {
        MovePlayer(horizontalMove);

        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    void MovePlayer(float horizontalMove)
    {
        Vector3 targetVelocity = new Vector2(horizontalMove, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
    }

    public void KickAnimation()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("kick"); ;
        }
    }
}