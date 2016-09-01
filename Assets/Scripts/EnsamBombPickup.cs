using UnityEngine;
using System.Collections;

public class EnsamBombPickup : MonoBehaviour {


    // Use this for initialization
    void Start()
    {

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}