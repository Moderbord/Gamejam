using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashScreenText : MonoBehaviour {

    private Text textbox;

	void Awake () {
        textbox = GetComponent<Text>();
	}

    void Update()
    {
        if (Time.timeSinceLevelLoad > 3.9f) 
        {
            SetText("GO");
        } else if (Time.timeSinceLevelLoad > 2.9f)
        {
            SetText("1");
        }
        else if (Time.timeSinceLevelLoad > 1.9f)
        {
            SetText("2");
        }
        else if (Time.timeSinceLevelLoad > 0.9f)
        {
            SetText("3");
        }
    }

    public void SetText(string text)
    {
        textbox.text = text;
    }


}
