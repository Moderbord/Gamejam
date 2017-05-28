using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

    public static Spawner spawner;
    public static WeaponSpawner wSpawner;
    public static int ruleset, p1stock, p2stock, p3stock, p4stock, p1kills, p2kills, p3kills, p4kills;

    public static OverlayMenu overlayMenu;
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

    //public static void RespawnEntity (int player, int entityID)
    //{
    //    spawner.SpawnEntity(player, entityID);
    //}

    public static void EntityDeath (int player, int entityID, int killedBy)
    {
        // Which rules the death counts to
        switch (ruleset)
        {
            case 1: // Versus mode stock
                // Selects the player that died and removes one stock. Respawns player if stock is 1 or more
                switch (player)
                {
                    case 1:
                        --p1stock;
                        if (p1stock > 0) {spawner.SpawnEntity(player, entityID);}
                        break;
                    case 2:
                        --p2stock;
                        if (p2stock > 0) {spawner.SpawnEntity(player, entityID);}
                        break;
                    case 3:
                        --p3stock;
                        if (p3stock > 0) {spawner.SpawnEntity(player, entityID);}
                        break;
                    case 4:
                        --p4stock;
                        if (p4stock > 0) {spawner.SpawnEntity(player, entityID);}
                        break;
                    default:
                        break;
                }
                break;
            case 2: // Versus mode deathmatch
                // If killed by other player, that player recieves points. Suicide removes points?
                if (player != killedBy)
                {
                    switch (killedBy)
                    {
                        case 1:
                            ++p1kills;
                            break;
                        case 2:
                            ++p2kills;
                            break;
                        case 3:
                            ++p3kills;
                            break;
                        case 4:
                            ++p4kills;
                            break;
                        default:
                            break;
                    }
                    break;
                }
                break;
            case 3: // Practise mode normal
                spawner.SpawnEntity(player, entityID);
                break;
            case 4: // Practise mode hardcore
                // Splash showing restarting level..
                overlayMenu.RestartLevel();
                break;
            default:
                break;

        }

    }

    //public static void PauseGame()
    //{
    //    Time.timeScale = 0f;
    //    Debug.Log("Game paused");
    //}

    //public static void ResumeGame()
    //{
    //    Time.timeScale = 1f;
    //    Debug.Log("Game resumed paused");
    //}

}
