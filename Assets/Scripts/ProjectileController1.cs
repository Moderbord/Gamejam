using UnityEngine;
using System.Collections;

public class ProjectileController1 : MonoBehaviour {
    Rigidbody2D myRB;

    public float projectileSpeed;
	// Use this for initialization
	void Awake () {
        myRB = GetComponent<Rigidbody2D>();
        if (transform.localRotation.z>0)
            myRB.AddForce(new Vector2(1, 0)*projectileSpeed, ForceMode2D.Impulse);
        else 
            myRB.AddForce(new Vector2(-1, 0)*projectileSpeed, ForceMode2D.Impulse);
    }

    /*void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Entity")
        {
            StartCoroutine(collide());
        }
    }*/

    IEnumerator collide()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
    }

}
