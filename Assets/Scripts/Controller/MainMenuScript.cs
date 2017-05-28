using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

    bool versusModeStock;
    bool practiseHCmode;
    int killStockAmount;

    string selectedLevel;
    int practiseHero, player1Hero, player2Hero, gameMode;

    void Awake()
    {
        // Restores settings players have made
        versusModeStock = PlayerPrefs.GetInt(C.PP_VERSUS_MODE, 1) == 1 ? true : false;
        practiseHCmode = PlayerPrefs.GetInt(C.PP_PRACTISE_HC, 1) == 1 ? true : false;
        killStockAmount = PlayerPrefs.GetInt(C.PP_STOCK_KILL_AMOUNT, 3);

    }

    void Start () {
        TextEditScript.SetVersusMode(versusModeStock ? C.VERSUS_MODE_STOCK : C.VERSUS_MODE_DEATHMATCH);
        TextEditScript.SetStockKill(killStockAmount.ToString());
        TextEditScript.SetHCmode(practiseHCmode ? "On" : "Off");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

#region VERSUS MODE

    public void ToggleVersusMode()
    {
        versusModeStock = !versusModeStock;

        TextEditScript.SetVersusMode(versusModeStock ? C.VERSUS_MODE_STOCK : C.VERSUS_MODE_DEATHMATCH);
        Debug.Log("Versus Mode set to " + (versusModeStock ? C.VERSUS_MODE_STOCK : C.VERSUS_MODE_DEATHMATCH));
        PlayerPrefs.SetInt(C.PP_VERSUS_MODE, versusModeStock ? 1 : 0);
    }

#endregion

#region KILLSTOCK AMOUNT
    
    public void IncrementKillStock()
    {
        UpdateKillStockAmount(++killStockAmount > 10 ? --killStockAmount : killStockAmount);
    }

    public void DecrementKillStock()
    {
        UpdateKillStockAmount(--killStockAmount < 1 ? ++killStockAmount : killStockAmount);
    }

    private void UpdateKillStockAmount(int amount)
    {
        TextEditScript.SetStockKill(killStockAmount.ToString());
        PlayerPrefs.SetInt(C.PP_STOCK_KILL_AMOUNT, amount);
    }

#endregion

#region PRACTICE MODE

    public void TogglePracticeHCmode()
    {
        practiseHCmode = !practiseHCmode;

        TextEditScript.SetHCmode(practiseHCmode ? "On" : "Off");
        Debug.Log("Practise Mode HC set to " + (practiseHCmode ? "On" : "Off"));
        PlayerPrefs.SetInt(C.PP_PRACTISE_HC, practiseHCmode ? 1 : 0);
    }

    #endregion

#region HERO SELECT

    // Practise hero
    public void SerPractiseHero(int hero)
    {
        practiseHero = hero;
        Debug.Log("sel helo " + hero);
    }

    // Player one
    public void SetPlayerOneHero(int hero)
    {
        player1Hero = hero;
    }

    // Player two
    public void SetPlayerTwoHero(int hero)
    {
        player2Hero = hero;
    }

    #endregion

#region LEVEL SELECT

    public void SetLevel(string level)
    {
        selectedLevel = level;
    }

    public void SetMode(int mode)
    {
        gameMode = mode;
    }

#endregion

#region PLAY

    public void Play()
    {
        PlayerPrefs.SetInt(C.PP_SEL_HERO_PRACTISE, practiseHero);
        PlayerPrefs.SetInt(C.PP_SEL_HERO_PLAYER1, player1Hero);
        PlayerPrefs.SetInt(C.PP_SEL_HERO_PLAYER2, player2Hero);

        PlayerPrefs.SetInt(C.PP_WHICH_GAMEMODE, gameMode);

        SceneManager.LoadScene(selectedLevel);
    }

#endregion

}
