using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KilledByScript : MonoBehaviour {

    int controlledByPlayer;

    public void SetControlledByPlayer(int player)
    {
        controlledByPlayer = player;
    }

    public int GetControlledByPlayer()
    {
        return controlledByPlayer;
    }

}
