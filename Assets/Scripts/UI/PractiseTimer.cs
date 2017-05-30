using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PractiseTimer : MonoBehaviour {

    Text timer;

    bool counting, practiseMode;

    private void Awake()
    {
        practiseMode = PlayerPrefs.GetInt(C.PP_WHICH_GAMEMODE) == 2 ? true : false;
        timer = GetComponent<Text>();
    }

    void Start () {

        if (practiseMode)
        {
            StartCoroutine(WaitForStart());
        }
        else
        {
            DisableTimer();
        }
	}
	

	void Update () {

        if (counting)
        {
            timer.text = (Time.timeSinceLevelLoad - 3.9f).ToString("0.00");
        }
        	
	}


    IEnumerator WaitForStart()
    {
        yield return new WaitForSeconds(3.9f);
        counting = true;
    }

    public void StopCount()
    {
        counting = false;

        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene.Contains("1"))
        {
            PlayerPrefs.SetString(C.PP_HIGHSCORE1, timer.text);
        }
        else if (currentScene.Contains("2"))
        {
            PlayerPrefs.SetString(C.PP_HIGHSCORE2, timer.text);
        }
        
    }

    public void DisableTimer()
    {
        gameObject.SetActive(false);
    }
}
