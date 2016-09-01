using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

    public static Spawner spawner;
    public static WeaponSpawner wSpawner;

    public float wCooldown;
    private float weaponSpawnTimer;

    private static int entity_ID;

    void Start()
    {
        weaponSpawnTimer = wCooldown;

        spawner = GetComponent<Spawner>();
        wSpawner = GetComponent<WeaponSpawner>();
        //RespawnEntity(0);
        //RespawnEntity(1);
        //RespawnEntity(2);
        RespawnEntity(3);
        wSpawner.spawnWeapon();
    }

    public void Update()
    {
        weaponSpawnTimer -= Time.deltaTime;
        if (weaponSpawnTimer <= 0)
        {
            wSpawner.spawnWeapon();
            weaponSpawnTimer = wCooldown;
        }
    }

    /*public static void KillEntity (Entity entity)
    {
        GameMaster.entity_ID = entity.getID();
        entity.triggerDeath();
    }*/

    /**
    *   0 = Fox
    *   1 = Dragon
    *   2 = Reindeer
    *   3 = Unicorn
    */
    public static void RespawnEntity (int id)
    {
        spawner.spawnEntity(id);
    }

}
