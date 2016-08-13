using UnityEngine;
using System.Collections;

public class RobotControllerScript : MonoBehaviour
{
    public float maxSpeed = 10f;
    bool facingRight = true;

    public Rigidbody2D body;
    public Animator anim;

	// Use this for initialization
	void Start () {
        Debug.Log("Start was called");
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void FixedUpdate()
    {

        float move = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(move));

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

    // Flips character
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 flipScale = transform.localScale;
        flipScale.x *= -1;
        transform.localScale = flipScale;
    }

}
