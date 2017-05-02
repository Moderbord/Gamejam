using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {

    Rigidbody2D body;

    [Tooltip("The speed of which the projectile is traveling"), Space(10)]
    public float projectileSpeed;

    [Tooltip("The until the projectile is removed"), Space(10)]
    public float aliveTime;
    
    void Awake () {

        body = GetComponent<Rigidbody2D>();

        int i = transform.localRotation.z > 0 ? 1 : -1;
        body.AddForce(new Vector2(i, 0) * projectileSpeed, ForceMode2D.Impulse);

        Destroy(gameObject, aliveTime);
    }

}
