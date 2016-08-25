using UnityEngine;
using System.Collections;

public class EnsamKnivPickup : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject)
        {
            Destroy(gameObject);
        }
    }

}
