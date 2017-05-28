using UnityEngine;
using System.Collections;

public class Bombscript : MonoBehaviour {

    [Tooltip("The speed of which the bomb will be launched at"), Range(0f, 20f)]
    public float projectileSpeed = 0f;
    [Space(10), Tooltip("Setting for maximum fuse time. Value will be randomed between 2f and this value"), Range(2f, 5f)]
    public float fuseTime = 3f;

    [Space(10), Tooltip("The explosion effect and deathArea that will be instatiated")]
    public GameObject explosion;
    public GameObject deathCircle;

    Rigidbody2D body;
    int controlledByPlayer;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        StartCoroutine(DelayedExplosion());

        int i = transform.localRotation.z > 0 ? 1 : -1;
        body.AddForce(new Vector2(i, 0) * projectileSpeed, ForceMode2D.Impulse);
        
    }


    IEnumerator DelayedExplosion()
    {
        yield return new WaitForSeconds(Random.Range(2f, fuseTime));

        SpriteRenderer render = GetComponentInChildren<SpriteRenderer>();
        render.enabled = false;

        // Instatiates an explosion and destroys it after some time
        GameObject effect = Instantiate(explosion, body.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
        GameObject death = Instantiate(deathCircle, body.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
        death.GetComponent<KilledByScript>().SetControlledByPlayer(controlledByPlayer);

        Destroy(effect, 2f);
        Destroy(death, 1/5f);
        Destroy(gameObject);
    }

    public void SetControlledByPlayer(int player)
    {
        controlledByPlayer = player;
    }

}
