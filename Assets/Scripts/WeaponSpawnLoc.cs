using UnityEngine;
using System.Collections;

public class WeaponSpawnLoc : MonoBehaviour {

    public Transform location;
    public bool collisionCheck = true;
    public bool spawnCheck = true;
	
    void Start()
    {
        location = GetComponent<Transform>();
    }

	// Update is called once per frame
	void Update () {
	
	}

    public bool canSpawn()
    {
        if (collisionCheck && spawnCheck)
        {
            return true;
        } else
        {
            return false;
        }
    }
}
