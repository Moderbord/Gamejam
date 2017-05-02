using UnityEngine;
using System.Collections;

public class WeaponSpawner : MonoBehaviour {

    [Tooltip("Spawning points for weapons to be instantiated at."), Space(10)]
    public WeaponSpawnLoc[] spawners;

    [Tooltip("List of available weapons to spawn."), Space(10)]
    public GameObject[] weapons;

    [Tooltip("A list of weapon clones. Inhibits reference loss when instatiating."), Space(10)]
    public GameObject[] weaponClones;
    

    public void spawnWeapon()
    {
        
        int sel = Random.Range(0, spawners.Length);     // Selects a random spawning point

        if (spawners[sel].CanSpawn())                   // Check if the spawner does not already have a weapong spawned or is blocked by object
        {
            int wep = Random.Range(0, weapons.Length);  // Selects a random weapon to spawn
            int i = 0;
            weaponClones[wep] = Instantiate(weapons[wep], spawners[sel].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;   // Creates a copy of selected weapon and spawns it at the spawn point
            Debug.Log("Weapon spawned at " + sel);
            spawners[sel].SetSpawnCheck(false);         // Inhibits multible weapon to be spawned at same spawn point
        } else
        {
            Debug.Log("Couldn't spawn weapon at " + sel);
        }
    }


}
