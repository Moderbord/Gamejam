using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

    public static void KillEntity (Entity entity)
    {
        Destroy(entity.gameObject);
    }

}
