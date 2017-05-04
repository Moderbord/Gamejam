using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [Header("Action keys"), Tooltip("Set movement hotkeys")]
    public KeyCode moveLeft;
    public KeyCode moveRight;
    public KeyCode jump;

    [Header("Control"), Tooltip("What acts as ground and which point should be calculated for overlapping")]
    public LayerMask groundMask;
    public Transform groundCheck;
    public float maskRadius = 0.2f;

    [Header("Movement"), Tooltip("The strength of forces for movement"), Range(1f, 200f)]
    public float moveSpeed = 75f;
    [Range(100f, 1400f)]
    public float jumpForce = 760f;
    [Range(1f, 40f)]
    public float maxMoveSpeed = 3f;
    [Range(100f, 4000f)]
    public float dashForce = 750f;

    Rigidbody2D body;
    Animator animator;
    Vector2 lastPos;

    bool facingRight = true;
    bool movingRight;
    bool onGround;
    bool jumpPressed;
    bool dblJump;
    float lastTime;
    float lastFrameFixed;
    float horizontalSpeed;
    float verticalSpeed;

    //Dash
    int dashDirection = 0;
    bool dash = false;
    float lastDash;
    float dashThreshold = 0.2f;
    float dashCooldown = 1f;


    void Start () {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

#region DASHING

        // Dash right
        if (Input.GetKeyDown(moveRight))
        {
            dashDirection += 1;
            if (Time.fixedTime - lastTime < dashThreshold && dashDirection > 1 && Time.fixedTime - lastDash > 1)
            {
                dash = true;
                lastDash = Time.fixedTime;
            }
            dashDirection = 1;
            lastTime = Time.fixedTime;
        }

        // Dash left
        if (Input.GetKeyDown(moveLeft))
        {
            dashDirection -= 1;
            if (Time.fixedTime - lastTime < dashThreshold && dashDirection < -1 && Time.fixedTime - lastDash > dashCooldown)
            {
                dash = true;
                lastDash = Time.fixedTime;
            }
            dashDirection = -1;
            lastTime = Time.fixedTime;
        }

        #endregion

#region DOUBLE JUMP

        if (Input.GetKeyDown(jump))
        {
            jumpPressed = true;
        }

        #endregion

        animator.SetBool("FacingRight", facingRight);
        animator.SetBool("DblJump", dblJump);
    }

    void FixedUpdate()
    {

#region MOVEMENT

        // Move Right
        if (Input.GetKey(moveRight))
        {
            // Flip if facing wrong way
            if (!facingRight)
            {
                Flip();
            }

            if (horizontalSpeed <= maxMoveSpeed || !movingRight)
            {
                body.AddForce(new Vector2(moveSpeed, Physics2D.gravity.y));
            }

        }

        // Move Left
        if (Input.GetKey(moveLeft))
        {
            // Flip if facing wrong way
            if (facingRight)
            {
                Flip();
            }

            if (horizontalSpeed <= maxMoveSpeed || movingRight)
            {
                body.AddForce(new Vector2(-moveSpeed, Physics2D.gravity.y));
            }

        }

        #endregion

#region DASH ACTIVE

        if (dash && dashDirection > 0)
        {
            body.AddForce(new Vector2(dashForce, Physics2D.gravity.y));
            dash = false;
        }
        else if (dash)
        {
            body.AddForce(new Vector2(-dashForce, Physics2D.gravity.y));
            dash = false;
        }

#endregion

#region JUMPING

        // Check if the player is touching the ground and toggles a bool thereafter
        onGround = Physics2D.OverlapCircle(groundCheck.position, maskRadius, groundMask);
        animator.SetBool("OnGround", onGround);

        // Double jump
        if (jumpPressed && dblJump && !onGround)
        {
            body.AddForce(new Vector2(0f, jumpForce));
            dblJump = false;
        }
        // Jump
        if (jumpPressed && onGround)
        {
            body.AddForce(new Vector2(0f, jumpForce));
            onGround = false;
            dblJump = true;
        }
        jumpPressed = false;
        

        #endregion

#region CALCULATIONS

        // Refresh last updated frame
        lastFrameFixed = Time.fixedDeltaTime;

        // Sets horizontal speed
        horizontalSpeed = Mathf.Abs((body.position.x - lastPos.x) * 10);
        animator.SetFloat("HorizontalSpeed", horizontalSpeed);

        // Sets vertical speed
        verticalSpeed = Mathf.Abs((body.position.y - lastPos.y) * 10);
        animator.SetFloat("VerticalSpeed", verticalSpeed);

        // Calculates moving direction horizontal
        movingRight = body.position.x - lastPos.x < 0 ? false : true;

        // Saves current position for future calculation
        lastPos = new Vector2(body.position.x, body.position.y);

#endregion

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 flipScale = transform.localScale;
        flipScale.x *= -1;
        transform.localScale = flipScale;
    }

}
