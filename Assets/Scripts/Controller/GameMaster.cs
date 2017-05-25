using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

    public static Spawner spawner;
    public static WeaponSpawner wSpawner;

    public float WeaponSpawningInterval;
    private float weaponSpawnTimer;

    void Awake()
    {
        weaponSpawnTimer = WeaponSpawningInterval;

        spawner = GetComponent<Spawner>();
        wSpawner = GetComponent<WeaponSpawner>();
        wSpawner.spawnWeapon();
    }

    private void Start()
    {
        bool practiseMode = PlayerPrefs.GetInt(C.PP_WHICH_GAMEMDOE) == 1 ? true : false;

        if (practiseMode)
        {
            SpawnEntity(1, PlayerPrefs.GetInt(C.PP_SEL_HERO_PRACTISE), 0);
        }
        else
        {
            Debug.Log("Versus mode");
        }
    }

    public void Update()
    {
        weaponSpawnTimer -= Time.deltaTime;
        if (weaponSpawnTimer <= 0)
        {
            wSpawner.spawnWeapon();
            weaponSpawnTimer = WeaponSpawningInterval;
        }
    }

    public static void SpawnEntity(int player, int entityID, int location)
    {
        spawner.SpawnEntity(player, entityID, location);
    }

    public static void RespawnEntity (int player, int entityID)
    {
        spawner.SpawnEntity(player, entityID);
    }

}
