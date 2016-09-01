using UnityEngine;
using System.Collections;

public class EnsamKnivPickup : MonoBehaviour {

    /*void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collision");
        if (col.gameObject)
        {
            Destroy(gameObject);
        }
    }*/

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collider");
        if (col.gameObject)
        {
            Destroy(gameObject);
        }
    }

}
