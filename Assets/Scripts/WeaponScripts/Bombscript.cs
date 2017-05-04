using UnityEngine;
using System.Collections;

public class Bombscript : MonoBehaviour {

    [Tooltip("The speed of which the bomb will be launched at"), Range(0f, 20f)]
    public float projectileSpeed = 0f;
    [Space(10), Tooltip("Setting for maximum fuse time. Value will be randomed between 2f and this value"), Range(2f, 5f)]
    public float fuseTime = 3f;

    [Space(10), Tooltip("The explosion effect that will be instatiated")]
    public GameObject explosion;

    Rigidbody2D body;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        StartCoroutine(DelayedExplosion());

        int i = transform.localRotation.z > 0 ? 1 : -1;
        body.AddForce(new Vector2(i, 0) * projectileSpeed, ForceMode2D.Impulse);
        
    }


    IEnumerator DelayedExplosion()
    {
        CircleCollider2D collider = GetComponent<CircleCollider2D>();

        yield return new WaitForSeconds(Random.Range(2f, fuseTime));
 
        collider.radius = 2.5f;
        transform.tag = "DeathCollider";

        // The short delay before bomb explodes
        yield return new WaitForSeconds(1/5);

        SpriteRenderer render = GetComponentInChildren<SpriteRenderer>();
        render.enabled = false;

        // Instatiates an explosion and destroys it after some time
        GameObject effect = Instantiate(explosion, body.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;

        Destroy(effect, 2f);
        Destroy(gameObject, 1/5f);
    }



}
