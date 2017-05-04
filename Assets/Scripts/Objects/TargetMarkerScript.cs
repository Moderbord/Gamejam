using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMarkerScript : MonoBehaviour {

    [Header("Remains"), Tooltip("The GameObject which contains the individual piecies of the TargetMarker")]
    public GameObject remains;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.transform.tag)
        {
            case "DeathCollider":
                Break();
                break;
            case "DeathProjectile":
                Break();
                break;
            default:
                break;
        }
    }

    private void Break()
    {
        Instantiate(remains, transform.position, Quaternion.Euler(0, 0, 0));
        Destroy(gameObject);
    }
}
