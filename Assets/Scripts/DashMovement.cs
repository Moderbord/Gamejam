using UnityEngine;
using System.Collections;

public class DashMovement : MonoBehaviour {

    public float maxSpeed = 24f;
    public float jumpForce = 1000f, jumpForceTwo = 1000f;
    float groundRadius = 0.2f;
    bool facingRight = true;
    bool grounded = false;
    bool doubleJump = false;
//    float move = Input.GetAxis("Horizontal");

    public LayerMask whatIsGround;
    public Transform groundCheck;
    public Rigidbody2D body;
    public Animator animator;

    //dash
    public KeyCode tapLeft;
    public KeyCode tapRight;
    public KeyCode jump;
    //public Sprite dashpunch;
    //public Sprite jumpback;
    //public Sprite idleimage;
    public int leftTotal = 0;            //hur många tangenttryck
    public float leftTimeDelay = 0;      //hur lång tid emellan trycken
    public int rightTotal = 0;
    public float rightTimeDelay = 0;
    public int xVel = 0;
    public float dashDuration = 0;
    //avgöra om spelaren dashar eller inte
    // Use this for initialization
    void Start()
    {
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

        //  float move = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(xVel));

        //body.velocity = new Vector2(move * maxSpeed, body.velocity.y);


        if (body.velocity.x > 0.1 && !facingRight)
        {
            Flip();
        }
        else if (body.velocity.x < -0.1 && facingRight)
        {
            Flip();
        }

    }

    void Update()
    {
//        move = xVel;

        //dash
        // xVel = 6;
        if (Input.GetKey(tapRight))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(16 + xVel, body.velocity.y, 0);
            // body.velocity = new Vector2(1 + xVel, body.velocity.y);

        }
        if (Input.GetKeyDown(tapRight))
        {
            rightTotal += 1;
            //Debug.Log(rightTotal);
        }
        if (Input.GetKeyUp(tapRight))
        {
            xVel = 0;
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, body.velocity.y, 0);
            //   GetComponent<SpriteRenderer>().sprite = idleimage;
        }
        if ((rightTotal == 1) && (rightTimeDelay < .3))
        {
            rightTimeDelay += Time.deltaTime;
        }

        if ((rightTotal == 1) && (rightTimeDelay >= .3))
        {
            rightTimeDelay = 0;
            rightTotal = 0;
        }
        if ((rightTotal == 2) && (rightTimeDelay < .3))
        {
            xVel = 50;
            rightTotal = 0;
            // GetComponent<SpriteRenderer>().sprite = Dashpunch;
        }
        if ((rightTotal == 2) && (rightTimeDelay >= .3))
        {
            xVel = 0;
            rightTotal = 0;
            rightTimeDelay = 0;
        }
        if (xVel > 19)
        {
            dashDuration += Time.deltaTime;
        }
        if (dashDuration > .15)
        {
            xVel = 0;
            dashDuration = 0;
            rightTotal = 0;
            rightTimeDelay = 0;
        }

        //vänster
        if (Input.GetKey(tapLeft))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(-16 + xVel, body.velocity.y, 0);
        }
        if (Input.GetKeyDown(tapLeft))
        {
            leftTotal += 1;
            //Debug.Log(leftTotal);
        }
        if (Input.GetKeyUp(tapLeft))
        {
            xVel = 0;
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, body.velocity.y, 0);
            //   GetComponent<SpriteRenderer>().sprite = idleimage;
        }
        if ((leftTotal == 1) && (leftTimeDelay < .3))
        {
            leftTimeDelay += Time.deltaTime;
        }

        if ((leftTotal == 1) && (leftTimeDelay >= .3))
        {
            leftTimeDelay = 0;
            leftTotal = 0;
        }
        if ((leftTotal == 2) && (leftTimeDelay < .3))
        {
            xVel = -50;
            leftTotal = 0;
            // GetComponent<SpriteRenderer>().sprite = Dashpunch;
        }
        if ((leftTotal == 2) && (leftTimeDelay >= .3))
        {
            xVel = 0;
            leftTotal = 0;
            leftTimeDelay = 0;
        }
        if (xVel < -19)
        {
            dashDuration += Time.deltaTime;
        }
        if (dashDuration > .15)
        {
            xVel = 0;
            dashDuration = 0;
            leftTotal = 0;
            leftTimeDelay = 0;
        }

        if (!grounded && doubleJump && Input.GetKeyDown(jump))
        {
            doubleJump = false;
            body.velocity = new Vector2(body.velocity.x, 0);
            body.AddForce(new Vector2(0, jumpForceTwo));

        }

        if (grounded && Input.GetKeyDown(jump))
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
        transform.localScale = flipScale;
    }



}
