using UnityEngine;
using System.Collections;

public class WeaponSpawnLoc : MonoBehaviour {

    public bool collisionCheck = true;
    public bool spawnCheck = true;

    public bool canSpawn()
    {
        if (collisionCheck && spawnCheck) {
            return true;
        } else {
            return false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject)
        {
            spawnCheck = true;
            collisionCheck = false;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject)
        {
            collisionCheck = true;
        }
    }

    public void setSpawnCheck(bool foo)
    {
        spawnCheck = foo;
    }

    public void setCollissionCheck(bool foo)
    {
        collisionCheck = foo;
    }

}
