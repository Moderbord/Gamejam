using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEditScript : MonoBehaviour
{

    public int index;
    // Which versus mode is active
    static Text textVersusMode;
    // The amount of kills required or stock lifes
    static Text stockKillText;
    // If Hardcore practise mode is on or off
    static Text textHCmode;

    void Awake()
    {
        switch (index)
        {
            case 0:
                textVersusMode = GetComponent<Text>();
                break;
            case 1:
                stockKillText = GetComponent<Text>();
                break;
            case 2:
                textHCmode = GetComponent<Text>();
                break;
            default:
                break;
        }
    }

    public static void SetVersusMode(string mode)
    {
        textVersusMode.text = mode;
    }

    public static void SetStockKill(string amount)
    {
        stockKillText.text = amount;
    }

    public static void SetHCmode(string mode)
    {
        textHCmode.text = mode;
    }

}
