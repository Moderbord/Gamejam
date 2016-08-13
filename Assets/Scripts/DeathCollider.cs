using UnityEngine;
using System.Collections;

public class DeathCollider : MonoBehaviour {

    void OnTriggerEnter (Collider col)
    {
        Debug.Log(col.tag);
    }

}
