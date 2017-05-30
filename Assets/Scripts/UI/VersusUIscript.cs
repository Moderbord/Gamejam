using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VersusUIscript : MonoBehaviour {

    public Text p1, p2;

    private bool versusMode;
    private int stockKill, ruleset;


    private void Awake()
    {
        versusMode = PlayerPrefs.GetInt(C.PP_WHICH_GAMEMODE) == 1 ? true : false;
        stockKill = PlayerPrefs.GetInt(C.PP_STOCK_KILL_AMOUNT);
        ruleset = PlayerPrefs.GetInt(C.PP_VERSUS_MODE) == 1 ? C.RULESET_VERSUS_STOCK : C.RULESET_VERSUS_DEATHMATCH;
    }

    void Start () {

        if (!versusMode)
        {
            DisableVersusUI();
        }

        if (ruleset == C.RULESET_VERSUS_STOCK)
        {
            p1.text = "P1: " + stockKill.ToString();
            p2.text = "P2: " + stockKill.ToString();
        }
        else if (ruleset == C.RULESET_VERSUS_DEATHMATCH)
        {
            p1.text = "P1 : 0";
            p2.text = "P2 : 0";
        }


    }

    public void UpdateScore(int player, int newScore)
    {
        switch (player)
        {
            case 1:
                p1.text = "P1: " + newScore.ToString();
                break;
            case 2:
                p2.text = "P2: " + newScore.ToString();
                break;
            default:
                break;
        }
    }
	
    private void DisableVersusUI()
    {
        gameObject.SetActive(false);
    }

}
