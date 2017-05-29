using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class C  {

    // TODO LIST
    // Pause game -- CHECK
    // Pause screen -- CHECK
    // Win conditions -- CHECK
    // Entry and victory (text) splash screen -- CHECK
    // Victory for practise
    // Timer for practise
    // Practise Highscore
    // Visual representation for ammo, stock and kills

    public static readonly int HERONUMBER_FOX = 0;
    public static readonly int HERONUMBER_DRAGON = 1;
    public static readonly int HERONUMBER_REINDEER = 2;
    public static readonly int HERONUMBER_UNICORN = 3;

    public static readonly int WEAPONCODE_KNIFE = 0;
    public static readonly int WEAPONCODE_BOMB = 1;

    public static readonly int RULESET_VERSUS_STOCK = 1;
    public static readonly int RULESET_VERSUS_DEATHMATCH = 2;
    public static readonly int RULESET_PRACTISE = 3;
    public static readonly int RULESET_PRACTISE_HC = 4;

    public static readonly Color COLOR_HALF_ALPHA = new Color(255, 255, 255, 50);
    public static readonly Color COLOR_FULL_ALPHA = new Color(255, 255, 255, 100);

    public static readonly string SCENE_MAIN_MENU = "MainMenu";

    public static readonly string VERSUS_MODE_STOCK = "Stock";
    public static readonly string VERSUS_MODE_DEATHMATCH = "Deathmatch";

    // PlayerPreferences
    public static readonly string PP_STOCK_KILL_AMOUNT = "PPstockKill";
    public static readonly string PP_VERSUS_MODE = "PPversusMode";
    public static readonly string PP_PRACTISE_HC = "PPpractiseHC";
    public static readonly string PP_SEL_HERO_PRACTISE = "PPselHeroPractise";
    public static readonly string PP_SEL_HERO_PLAYER1 = "PPheroPlayer1";
    public static readonly string PP_SEL_HERO_PLAYER2 = "PPheroPlayer2";
    public static readonly string PP_WHICH_GAMEMODE = "PPgameMode";
}