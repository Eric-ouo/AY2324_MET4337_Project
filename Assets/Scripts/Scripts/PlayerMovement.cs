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
    private bool hasJumped = false; // new varbiable
	private bool leftButton;
	private bool rightButton;
	private bool jumpButton;
	private bool kickButton;
    private Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    private Animator animator;

    public LayerMask ballLayer; // used to detect the ball layermask
    public float kickRadius; // where the kick will be detected
    public float kickForce; // force of the kick

    //public AudioManager audioManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        if (isGrounded)
        {
            hasJumped = false; // character is grounded, allow to jump
        }

        if (!hasJumped && isGrounded && (Input.GetKeyDown(KeyCode.Space) || jumpButton))
        {
            isJumping = true;
            hasJumped = true; // after jump, set to true, not allow to jump again
        }

        if (Input.GetKey(KeyCode.A) || leftButton)
        {
            horizontalMove = -speed;
            Reflect(1f);
        }
        else if (Input.GetKey(KeyCode.D) || rightButton)
        {
            horizontalMove = speed;
            Reflect(-1f);
        }
        else
        {
            horizontalMove = 0;
        }

        if (Input.GetKey(KeyCode.J) || kickButton)
        {
            animator.SetTrigger("kick");
        }

        animator.SetBool("run", Mathf.Abs(horizontalMove) > 0f);
        animator.SetBool("Jump", isJumping);

        if (Input.GetKeyDown(KeyCode.J) || kickButton)
        {
            // check if the ball is in range
            Collider2D ball = Physics2D.OverlapCircle(transform.position, kickRadius, ballLayer);
            if (ball != null)
            {
                // calculate the direction of the kick
                Vector2 kickDirection = ball.transform.position - transform.position;
                kickDirection.Normalize();

                // to kick the ball, we need to add force to the ball
                ball.GetComponent<Rigidbody2D>().AddForce(kickDirection * kickForce, ForceMode2D.Impulse);

                //audioManager.PlayKickGround();
            }
        }
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
	
	public void leftButtonCheck(bool press)
	{
		leftButton = press;
	}
	public void rightButtonCheck(bool press)
	{
		rightButton = press;
	}
	public void jumpButtonCheck(bool press)
	{
		jumpButton = press;
	}
	public void kickButtonCheck(bool press)
	{
		kickButton = press;
	}
}