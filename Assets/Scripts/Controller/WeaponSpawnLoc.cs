using UnityEngine;
using System.Collections;

public class WeaponSpawnLoc : MonoBehaviour {

    [Header("Checks"), Tooltip("Both conditions must be true for the weapon to be spawned at specific location")]
    public bool collisionCheck = true;
    public bool spawnCheck = true;

    public bool CanSpawn()
    {
        if (collisionCheck && spawnCheck) {
            return true;
        } else {
            return false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Entity")
        {
            spawnCheck = true;
            collisionCheck = false;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Entity")
        {
            collisionCheck = true;
        }
    }

    public void SetSpawnCheck(bool foo)
    {
        spawnCheck = foo;
    }

    public void SetCollissionCheck(bool foo)
    {
        collisionCheck = foo;
    }

}
