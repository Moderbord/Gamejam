using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMarkerPieces : MonoBehaviour {

    private void Awake()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject, Random.Range(2f, 3f));
        }

        Destroy(gameObject, 3f);
    }

}
