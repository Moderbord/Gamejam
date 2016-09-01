using UnityEngine;
using System.Collections;

public class EnsamKnivPickup : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        // Destroys this object if any other object collides with it
        if (col.gameObject)
        {
            Destroy(gameObject);
        }
    }

}
