using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour {

    public int number;

    public Text highscore;

    private void Awake()
    {
        switch (number)
        {
            case 1:
                highscore.text = PlayerPrefs.GetString(C.PP_HIGHSCORE1, "0.00");
                break;
            case 2:
                highscore.text = PlayerPrefs.GetString(C.PP_HIGHSCORE2, "0.00");
                break;
            default:
                break;
        }
    }	
}
