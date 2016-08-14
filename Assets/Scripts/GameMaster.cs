using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

    public static Spawner spawner;

    private static int entity_ID;

    void Start()
    {
        spawner = GetComponent<Spawner>();
        RespawnEntity(2);
    }

    public static void KillEntity (Entity entity)
    {
        GameMaster.entity_ID = entity.getID();
        entity.triggerDeath();
    }

    public static void RespawnEntity (int id)
    {
        spawner.spawnEntity(id);
    }

}
