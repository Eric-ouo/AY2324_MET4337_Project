using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class PlayerMovement : NetworkBehaviour
{
    public float speed = 10f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask groundLayer;

    private float horizontalMove;
    private bool isJumping = false;
    private bool isGrounded = false;
    private bool hasJumped = false;
    private Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    private Animator animator;
    public float dashSpeed = 30f;
    public float dashDuration = 0.2f;
    private bool isDashing;
    private float dashTimeLeft;
    private float doubleTapTimeA;
    private float doubleTapTimeD;
    private float lastTapTimeA = -1f;
    private float lastTapTimeD = -1f;
    private int tapCountA = 0;
    private int tapCountD = 0;
    public float tapSpeed = 0.2f; 
    public LayerMask ballLayer;
    public float kickRadius;
    public float kickForce;
	
	private bool leftButton;
	private bool rightButton;
	private bool kickButton;
	private bool jumpButton;

    public AudioManager audioManager; //

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioManager = AudioManager.instance;//
    }

    private void Update()
    {
		/*
		if (!isLocalPlayer)
		{
			return;
		}
		*/
		
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        if (isGrounded)
        {
            hasJumped = false; // character is grounded, allow to jump
        }

        if (!hasJumped && isGrounded && (Input.GetKeyDown(KeyCode.Space) || jumpButton))
        {
            audioManager.PlayJump();
            isJumping = true;
            hasJumped = true; // after jump, set to true, not allow to jump again
        }

        if (Input.GetKey(KeyCode.A) || leftButton)
        {
            horizontalMove = -speed;
            Reflect(1f);
            audioManager.isRun = true;//
            audioManager.audioPlay();//
        }
        else if (Input.GetKey(KeyCode.D) || rightButton)
        {
            horizontalMove = speed;
            Reflect(-1f);
            audioManager.isRun = true;//
            audioManager.audioPlay();//
        }
        else
        {
            horizontalMove = 0;
            audioManager.isRun = false;//
            audioManager.audioPlay();//
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
                audioManager.PlayKickSound();//
                // calculate the direction of the kick
                Vector2 kickDirection = ball.transform.position - transform.position;
                kickDirection.Normalize();

                // to kick the ball, we need to add force to the ball
                ball.GetComponent<Rigidbody2D>().AddForce(kickDirection * kickForce, ForceMode2D.Impulse);
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (Time.time < lastTapTimeA + tapSpeed)
            {
                tapCountA++;
            }
            else
            {
                tapCountA = 1;
            }

            lastTapTimeA = Time.time;
        }

        // Double-tap logic for 'D' key (right dash)
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (Time.time < lastTapTimeD + tapSpeed)
            {
                tapCountD++;
            }
            else
            {
                tapCountD = 1;
            }

            lastTapTimeD = Time.time;
        }

        if (tapCountA == 2)
        {
            audioManager.PlayDash();
            Dash(-1); // Dash left
            tapCountA = 0; // Reset tap count after a dash has been initiated
        }

        if (tapCountD == 2)
        {
            audioManager.PlayDash();
            Dash(1); // Dash right
            tapCountD = 0; // Reset tap count after a dash has been initiated
        }
    }

    private void FixedUpdate()
    {
        if (!isDashing)
        {
            MovePlayer(horizontalMove * Time.fixedDeltaTime);
        }
        else if (dashTimeLeft > 0)
        {
            dashTimeLeft -= Time.fixedDeltaTime;
        }
        else
        {
            isDashing = false;
            rb.velocity = new Vector2(rb.velocity.x * 0.5f, rb.velocity.y); // Slow down after dashing
        }
        MovePlayer(horizontalMove);

        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }
    private void Dash(int direction)
    {
        if (!isDashing)
        {
            isDashing = true;
            dashTimeLeft = dashDuration;
            rb.velocity = new Vector2(dashSpeed * direction, rb.velocity.y);
            // Here you might want to add an animation trigger for dashing
            // animator.SetTrigger("dash");
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
	
	public void leftButtonClick(bool click)
    {
		leftButton = click;
    }
	
	public void rightButtonClick(bool click)
    {
		rightButton = click;
    }
	
	public void kickButtonClick(bool click)
    {
		kickButton = click;
    }
	
	public void jumpButtonClick(bool click)
    {
		jumpButton = click;
	}
}