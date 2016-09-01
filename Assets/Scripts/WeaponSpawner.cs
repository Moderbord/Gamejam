using UnityEngine;
using System.Collections;

public class WeaponSpawner : MonoBehaviour {

    public WeaponSpawnLoc[] spawners;
    public GameObject[] weapons;
    public GameObject[] weaponClones;

    public void spawnWeapon()
    {
        //Debug.Log("Tried to spawn weapon");
        int sel = Random.Range(0, spawners.Length);
        if (spawners[sel].canSpawn())
        {
            int wep = Random.Range(0, weapons.Length);
            weaponClones[wep] = Instantiate(weapons[wep], spawners[sel].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            Debug.Log("Weapon spawned at " + sel);
            spawners[sel].setSpawnCheck(false); //Inhibits multible weapon to be spawned at same point
        } else
        {
            Debug.Log("Couldn't spawn weapon at " + sel);
        }
    }


}
