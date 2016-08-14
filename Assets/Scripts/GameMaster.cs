using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

    public static Spawner spawner;

    private static int entity_ID;

    void Start()
    {
        spawner = GetComponent<Spawner>();
        RespawnEntity(0);
        RespawnEntity(1);
        RespawnEntity(2);
        RespawnEntity(3);
    }

    public static void KillEntity (Entity entity)
    {
        GameMaster.entity_ID = entity.getID();
        entity.triggerDeath();
    }

    /**
    *   0 = Fox
    *   1 = Dragon
    *   2 = Reindeer
    *   3 = Unicorn
    */
    public static void RespawnEntity (int id)
    {
        spawner.spawnEntity(id);
    }

}
