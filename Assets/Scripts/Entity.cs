using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

    public int entity_ID;
    public WeaponHandler wHandler;

    void Start()
    {
        wHandler = GetComponent<WeaponHandler>();
        Debug.Log("Entity start");
    }

    public int getID()
    {
        return entity_ID;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        switch (collider.tag)
        {
            case "DeathCollider":
                Debug.Log("Death");
                //GameMaster.KillEntity(this);
                triggerDeath();
                break;
            case "kniv":
                Debug.Log("knif");
                wHandler.addAmmo(0, 5);
                Destroy(collider.gameObject);
                break;
            case "brick":
                Debug.Log("sten");
                wHandler.addAmmo(1, 10);
                Destroy(collider.gameObject);
                break;
            default:
                break;
        }
    }

    public void triggerDeath()
    {
        //TODO death animation connection
        GameMaster.RespawnEntity(entity_ID);
        Destroy(this.gameObject);
    }

}
