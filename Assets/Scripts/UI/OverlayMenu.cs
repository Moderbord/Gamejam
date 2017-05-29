using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverlayMenu : MonoBehaviour {
    
	void Start () {
        gameObject.SetActive(false);
    }

    public void EnableMenu()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void DisableMenu()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartLevel()
    {
        string scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        Time.timeScale = 1f;
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(C.SCENE_MAIN_MENU);
    }

}
