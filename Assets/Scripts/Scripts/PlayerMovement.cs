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
    private bool hasJumped = false;
    private Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    private Animator animator;
    private AudioSource audioSource;

    private bool leftButton;
    private bool rightButton;
    private bool jumpButton;
    private bool kickButton;


    public LayerMask ballLayer; // used to detect the ball layermask
    public float kickRadius; // where the kick will be detected
    public float kickForce; // force of the kick

    AudioManager audioManager = AudioManager.instance;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        // Ensure the AudioManager is found
        if (AudioManager.instance != null)
        {
            audioManager = AudioManager.instance;
        }
        else
        {
            Debug.LogWarning("AudioManager not found in the scene.");
        }
    }

    private void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        // Reset jumping ability when grounded
        if (isGrounded)
        {
            hasJumped = false;
        }

        // Jump if the jump button is pressed and the player is grounded
        if (!hasJumped && isGrounded && jumpButton)
        {
            isJumping = true;
            hasJumped = true;
        }

        // Move left
        if (leftButton)
        {
            horizontalMove = -speed;
            ReflectCharacter(true);
        }
        // Move right
        else if (rightButton)
        {
            horizontalMove = speed;
            ReflectCharacter(false);
        }
        // No horizontal movement
        else
        {
            horizontalMove = 0;
        }

        // Play running sound if moving, otherwise stop
        audioSource.volume = Mathf.Abs(horizontalMove) > 0 ? 1f : 0f;
        AudioPlay();

        // Kick if the kick button is pressed
        if (kickButton)
        {
            PerformKick();
        }

        // Update animator states
        animator.SetBool("run", horizontalMove != 0);
        animator.SetBool("Jump", isJumping);
    }

    private void FixedUpdate()
    {
        // Apply movement and jumping forces
        MovePlayer(horizontalMove);
        if (isJumping)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = false;
        }
    }

    private void MovePlayer(float horizontalMove)
    {
        // Handle player movement
        Vector3 targetVelocity = new Vector2(horizontalMove, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
    }

    private void ReflectCharacter(bool isLeft)
    {
        // Reflect the character sprite based on movement direction
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * (isLeft ? -1 : 1);
        transform.localScale = scale;
    }

    public void SetLeftButton(bool press)
    {
        leftButton = press;
    }

    public void SetRightButton(bool press)
    {
        rightButton = press;
    }

    public void SetJumpButton(bool press)
    {
        jumpButton = press;
    }

    public void SetKickButton(bool press)
    {
        kickButton = press;
    }

    private void PerformKick()
    {
        // Perform kick action
        animator.SetTrigger("kick");
        Collider2D ball = Physics2D.OverlapCircle(transform.position, kickRadius, ballLayer);
        if (ball != null)
        {
            audioManager.PlayKickSound();
            Vector2 kickDirection = ball.transform.position - transform.position;
            kickDirection.Normalize();
            ball.GetComponent<Rigidbody2D>().AddForce(kickDirection * kickForce, ForceMode2D.Impulse);
        }
    }

    private void AudioPlay()
    {
        // Handle playing of the running sound
        if (Mathf.Abs(horizontalMove) > 0 && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
        else if (horizontalMove == 0)
        {
            audioSource.Stop();
        }
    }

    // Public methods to be called by UI button events
    public void OnLeftButtonPress(bool isPressed)
    {
        SetLeftButton(isPressed);
    }
}
