using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPractiseCounter : MonoBehaviour {

    private int targets, destoyedTargets;

	void Start () {

        foreach (Transform child in transform)
        {
            targets++;
        }
	}
	
    public void TargetDestroyed()
    {
        ++destoyedTargets;

        if (destoyedTargets == targets)
        {
            PractiseCompleted();
        }
    }

    private void PractiseCompleted()
    {
        SplashScreenScript.Victory("STAGE COMPLETED");
    }

}
