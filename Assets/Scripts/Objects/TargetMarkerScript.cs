﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMarkerScript : MonoBehaviour {

    [Header("Remains"), Tooltip("The GameObject which contains the individual piecies of the TargetMarker")]
    public GameObject remains;

    void OnTriggerEnter2D(Collider2D collision)
    {

        switch (collision.tag)
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
        GetComponentInParent<TargetPractiseCounter>().TargetDestroyed();
        Instantiate(remains, transform.position, Quaternion.Euler(0, 0, 0));
        Destroy(gameObject);
    }
}
