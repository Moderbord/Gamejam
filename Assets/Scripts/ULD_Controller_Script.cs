using UnityEngine;
using System.Collections;

public class ULD_Controller_Script : MonoBehaviour
{
    public float maxSpeed = 15f;
    public float jumpForce = 500f, jumpForceTwo = 500f;
    float groundRadius = 0.2f;
    float move;
    bool facingRight = true;
    bool grounded = false;
    bool doubleJump = false;

    public LayerMask whatIsGround;
    public Transform groundCheck;
    public Rigidbody2D body;
    public Animator animator;

    void Start()
    {
        Debug.Log("Mrs Fabulousa Unicorn is live!");
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        animator.SetBool("Ground", grounded);
        animator.SetBool("FaceRight", facingRight);
        animator.SetBool("DblJump", doubleJump);

        animator.SetFloat("vSpeed", body.velocity.y);
        animator.SetFloat("xSpeed", body.velocity.x);

        move = Input.GetAxis("Unicorn_hor");
        animator.SetFloat("Speed", Mathf.Abs(move));

        body.velocity = new Vector2(move * maxSpeed, body.velocity.y);

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }

    }

    void Update()
    {
        if (!grounded && doubleJump && Input.GetKeyDown(KeyCode.UpArrow))
        {
            doubleJump = false;
            body.velocity = new Vector2(body.velocity.x, 0);
            body.AddForce(new Vector2(0, jumpForceTwo));

        }

        if (grounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            doubleJump = true;
            animator.SetBool("Ground", false);
            body.AddForce(new Vector2(0, jumpForce));
        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 flipScale = transform.localScale;
        flipScale.x *= -1;
        //flipScale.y += 5;
        transform.localScale = flipScale;
    }

}
