using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashScreenScript : MonoBehaviour {

    private static readonly string CLIP_COUNTDOWN = "SplashScreenCountdown", CLIP_VICTORY = "SplashScreenVictory";

    private static Text textbox;
    private static Animator anim;

	void Awake () {
        textbox = GetComponent<Text>();
        anim = GetComponent<Animator>();
	}
	
    public static void Countdown()
    {
        anim.Play(CLIP_COUNTDOWN);
    }

    public static void Victory(string text)
    {
        anim.Play(CLIP_VICTORY);
        SetText(text);
        Time.timeScale = 0.3f;
    }

    public static void SetText(string text)
    {
        textbox.text = text;
    }

}
