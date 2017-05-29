using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

    public static Spawner spawner;
    public static WeaponSpawner wSpawner;
    public static int ruleset, stockKill, p1stock, p2stock, p3stock, p4stock, p1kills, p2kills, p3kills, p4kills;

    public static OverlayMenu overlayMenu;
    public float WeaponSpawningInterval;
    private float weaponSpawnTimer;

    void Awake()
    {
        weaponSpawnTimer = WeaponSpawningInterval + 5f;

        overlayMenu = FindObjectOfType<OverlayMenu>();    
        spawner = GetComponent<Spawner>();
        wSpawner = GetComponent<WeaponSpawner>();

        stockKill = PlayerPrefs.GetInt(C.PP_STOCK_KILL_AMOUNT);
        // Debug.Log("Stock is set to " + stockKill);
        p1stock = stockKill;
        p2stock = stockKill;
        p3stock = 0; // Player not yet implemented
        p4stock = 0; // Player not yet implemented
        p1kills = 0;
        p2kills = 0;
        p3kills = 0;
        p4kills = 0;
    }

    private void Start()
    {
        SplashScreenScript.Countdown();
        StartCoroutine(WaitForStart());
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

    IEnumerator WaitForStart()
    {
        yield return new WaitForSeconds(3.9f);
        StartGame();
    }

    public void StartGame()
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
        wSpawner.spawnWeapon();
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
        Debug.Log("Player : " + player + ". EntityID : " + entityID + ". KilledBy : " + killedBy + ".");
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
                StockWinCheck(p1stock, p2stock, p3stock, p4stock);
                break;
            case 2: // Versus mode deathmatch
                // If killed by other player, that player recieves points. Suicide removes points?
                if (player != killedBy && killedBy != 0)
                {
                    switch (killedBy)
                    {
                        case 1:
                            ++p1kills;
                            spawner.SpawnEntity(player, entityID);
                            if (p1kills >= stockKill){ SplashScreenScript.Victory("PLAYER 1 WINS"); }
                            break;
                        case 2:
                            ++p2kills;
                            spawner.SpawnEntity(player, entityID);
                            if (p2kills >= stockKill) { SplashScreenScript.Victory("PLAYER 2 WINS"); }
                            break;
                        case 3:
                            ++p3kills;
                            spawner.SpawnEntity(player, entityID);
                            if (p3kills >= stockKill) { SplashScreenScript.Victory("PLAYER 3 WINS"); }
                            break;
                        case 4:
                            ++p4kills;
                            spawner.SpawnEntity(player, entityID);
                            if (p4kills >= stockKill) { SplashScreenScript.Victory("PLAYER 4 WINS"); }
                            break;
                        default:
                            break;
                    }

                }
                else if (player == killedBy || killedBy == 0) // Player killed themselves or fell to death
                {
                    switch (player)
                    {
                        case 1:
                            p1kills = --p1kills < 0 ? ++p1kills : p1kills;
                            spawner.SpawnEntity(player, entityID);
                            break;
                        case 2:
                            p2kills = --p2kills < 0 ? ++p2kills : p2kills;
                            spawner.SpawnEntity(player, entityID);
                            break;
                        case 3:
                            p3kills = --p3kills < 0 ? ++p3kills : p3kills;
                            spawner.SpawnEntity(player, entityID);
                            break;
                        case 4:
                            p4kills = --p4kills < 0 ? ++p4kills : p4kills;
                            spawner.SpawnEntity(player, entityID);
                            break;
                        default:
                            break;
                    }     
                }
                break; // Main switch
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


    static void StockWinCheck(int p1, int p2, int p3 , int p4)
    {

        int[] checkStock = { p1, p2, p3, p4 };
        int[] playerList = { 1, 2, 3, 4 };

        int i = 0;
        int j = 0;

        while (i < checkStock.Length)
        {
            if (checkStock[i] > 0)
            {
                j++;
            }
            i++;
        }

        int x = 0;

        if (j == 1)
        {
            while (x < checkStock.Length)
            {
                if (checkStock[x] > 0)
                {
                    SplashScreenScript.Victory("PLAYER " + playerList[x].ToString() + " WINS");
                }
                x++;
            }
        }


    }

}
