using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

    public static Spawner spawner;
    public static WeaponSpawner wSpawner;

    public float WeaponSpawningInterval;
    private float weaponSpawnTimer;
    private int ruleset, p1stock, p2stock, p3stock, p4stock, p1kills, p2kills, p3kills, p4kills;

    void Awake()
    {
        weaponSpawnTimer = WeaponSpawningInterval;

        spawner = GetComponent<Spawner>();
        wSpawner = GetComponent<WeaponSpawner>();
        wSpawner.spawnWeapon();
    }

    private void Start()
    {
        Debug.Log("Getting practice mode : " + (PlayerPrefs.GetInt(C.PP_PRACTISE_HC) == 0 ? "normal" : "hardcore"));
        Debug.Log("Getting versus mode : " + (PlayerPrefs.GetInt(C.PP_VERSUS_MODE) == 1 ? "stock" : "deathmatch"));

        bool practiseMode = PlayerPrefs.GetInt(C.PP_WHICH_GAMEMODE) == 2 ? true : false;

        if (practiseMode)
        {
            SpawnEntity(5, PlayerPrefs.GetInt(C.PP_SEL_HERO_PRACTISE), 0);

            ruleset = PlayerPrefs.GetInt(C.PP_PRACTISE_HC) == 0 ? C.RULESET_PRACTISE : C.RULESET_PRACTISE_HC;
        }
        else
        {
            SpawnEntity(1, PlayerPrefs.GetInt(C.PP_SEL_HERO_PLAYER1), 0);
            SpawnEntity(2, PlayerPrefs.GetInt(C.PP_SEL_HERO_PLAYER2), 1);

            ruleset = PlayerPrefs.GetInt(C.PP_VERSUS_MODE) == 1 ? C.RULESET_VERSUS_STOCK : C.RULESET_VERSUS_DEATHMATCH;
        }
        Debug.Log("Ruleset : " + ruleset);
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

    public static void EntityDeath (int player, int entityID, int killedBy)
    {

    }

}
