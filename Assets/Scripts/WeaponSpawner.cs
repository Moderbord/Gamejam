using UnityEngine;
using System.Collections;

public class WeaponSpawner : MonoBehaviour {

    public WeaponSpawnLoc[] spawners;
    public GameObject[] weapons;
    public GameObject[] weaponClones;

    public void spawnWeapon()
    {
        Debug.Log("Tried to spawn weapon");
        int sel = Random.Range(0, spawners.Length);
        if (spawners[sel].canSpawn())
        {
            Debug.Log("Weapon spawned at " + sel);
        } else
        {
            Debug.Log("Couldn't spawn weapon at " + sel);
        }
    }


}
