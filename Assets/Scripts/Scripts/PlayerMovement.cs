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

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("kick");
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            horizontalMove = -speed;
            Reflect(1f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontalMove = speed;
            Reflect(-1f);
        }
        else
        {
            horizontalMove = 0;
        }

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

    private void Reflect(float direction)
    {
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * direction;
        transform.localScale = scale;
    }
}