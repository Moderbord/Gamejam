using UnityEngine;
using System.Collections;

public class Bombscript : MonoBehaviour {

    Rigidbody2D body;
    public float projectileSpeed;
    public GameObject explosion;

    // Use this for initialization
    IEnumerator väntaOchExplodera()
    {
        yield return new WaitForSeconds(3);
        CircleCollider2D myCollider = transform.GetComponent<CircleCollider2D>();

        myCollider.isTrigger = true;
        
        myCollider.radius = 4f;
        yield return new WaitForSeconds(1/5);
        //Instantiate(explosion, myRB.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        //GetComponent<SpriteRenderer>().sprite = Dashpunch;
        Destroy(gameObject);

    }


    void Awake()
    {
        StartCoroutine(väntaOchExplodera());

        body = GetComponent<Rigidbody2D>();
        if (transform.localRotation.z > 0)
            body.AddForce(new Vector2(1, 0) * projectileSpeed, ForceMode2D.Impulse);
        else
            body.AddForce(new Vector2(-1, 0) * projectileSpeed, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            //fixa explosion här
            Destroy(gameObject);
        }
        else
        {
            body.gravityScale = 6;
        }
    }
    // Update is called once per frame
    void Update()
    {
    
    }
    

}
