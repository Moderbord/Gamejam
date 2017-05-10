using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {

    // Which versus mode is active
    Text textVersusMode;
    // The amount of kills required or stock lifes
    Text stockKillText;
    // If Hardcore practise mode is on or off
    Text textHCmode;

    bool versusModeStock = true;
    bool practiseHCmode = true;
    int killStockAmount = 3;

    void Start () {
        textVersusMode = EditorUtility.InstanceIDToObject(-208466) as Text;
        stockKillText = EditorUtility.InstanceIDToObject(-274978) as Text;
        textHCmode = EditorUtility.InstanceIDToObject(-261874) as Text;
    }
	
	void Update () {
		
	}

    public void ExitGame()
    {
        Application.Quit();
    }

#region VERSUS MODE

    public void ToggleVersusMode()
    {
        versusModeStock = !versusModeStock;

        textVersusMode.text = versusModeStock ? C.VERSUS_MODE_STOCK : C.VERSUS_MODE_DEATHMATCH;   
    }

#endregion

#region KILLSTOCK AMOUNT

    public void IncrementKillStock()
    {
        killStockAmount = ++killStockAmount > 10 ? 10 : killStockAmount;
        UpdateKillStockAmount();
    }

    public void DecrementKillStock()
    {
        killStockAmount = --killStockAmount < 1 ? 1 : killStockAmount;
        UpdateKillStockAmount();
    }

    private void UpdateKillStockAmount()
    {
        stockKillText.text = killStockAmount.ToString();
    }

#endregion

#region PRACTICE MODE

    public void TogglePracticeHCmode()
    {
        practiseHCmode = !practiseHCmode;

        textHCmode.text = practiseHCmode ? "On" : "Off";

    }

#endregion

}
