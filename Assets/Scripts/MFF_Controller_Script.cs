using UnityEngine;
using System.Collections;

public class MFF_Controller_Script : MonoBehaviour
{
    public float maxSpeed = 15f;
    public float jumpForce = 500f, jumpForceTwo = 500f;
    float groundRadius = 0.2f;
    bool facingRight = true;
    bool grounded = false;
    bool doubleJump = false;

    public LayerMask whatIsGround;
    public Transform groundCheck;
    public Rigidbody2D body;
    public Animator animator;

    //variabler för skjutning
    public Transform Skjutpunkt;
    public Transform Skjutpunkt2; //höger riktning, buggar, behöver högre position
    public GameObject bullet;
    float baraFemSkott = 6;
    float fireRate = 0.3f;
    float nextFire = 0f;

    // Use this for initialization
    void Start()
    {
        Debug.Log("MFF is live!");
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

        float move = Input.GetAxis("Horizontal");
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

    //plocka upp kniv
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.tag);
        switch (col.gameObject.tag)
        {
            case "xCollision":

                body.velocity = new Vector2(body.velocity.x * -1, body.velocity.y);
                //body.AddForce = new Vector2()
                break;

            case "yCollison":
                break;

            case "kniv":
                baraFemSkott = 0;
                break;

            default:
                break;

        }
    }

    void Update()
    {
        if (!grounded && doubleJump && Input.GetKeyDown(KeyCode.Space))
        {
            doubleJump = false;
            body.velocity = new Vector2(body.velocity.x, 0);
            body.AddForce(new Vector2(0, jumpForceTwo));

        }

        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            doubleJump = true;
            animator.SetBool("Ground", false);
            body.AddForce(new Vector2(0, jumpForce));
        }

        //skjuta, ifall vänsterklick är nedpressad och man har skott kvar
        if (Input.GetAxisRaw("Fire1") > 0 && baraFemSkott < 5) skjutNu();

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 flipScale = transform.localScale;
        flipScale.x *= -1;
        transform.localScale = flipScale;
    }

    //funktion för att skjuta, vänsterklick = skjut
    void skjutNu()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (facingRight)
            {
                Instantiate(bullet, Skjutpunkt2.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
            }
            else if (!facingRight)
            {
                Instantiate(bullet, Skjutpunkt.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            baraFemSkott++;
        }
    }

}
