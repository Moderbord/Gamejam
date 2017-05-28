using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

    public static Spawner spawner;
    public static WeaponSpawner wSpawner;
    public static int ruleset, p1stock, p2stock, p3stock, p4stock, p1kills, p2kills, p3kills, p4kills;

    public OverlayMenu overlayMenu;
    public float WeaponSpawningInterval;
    private float weaponSpawnTimer;

    void Awake()
    {
        weaponSpawnTimer = WeaponSpawningInterval;

        overlayMenu = FindObjectOfType<OverlayMenu>();    
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            overlayMenu.EnableMenu();
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
        switch (ruleset)
        {
            case 1: // Versus mode stock
                // Remove life from stock
                // Win check
                break;
            case 2: // Versus mode deathmatch
                // If killed by other player, that player recieves points. Suicide removes points?
                // Win check
                break;
            case 3: // Practise mode normal
                // Respawn
                break;
            case 4: // Practise mode hardcore
                // Restart level
                break;
            default:
                break;

        }

    }

    public static void PauseGame()
    {
        Time.timeScale = 0f;
        Debug.Log("Game paused");
    }

    public static void ResumeGame()
    {
        Time.timeScale = 1f;
        Debug.Log("Game resumed paused");
    }

}
