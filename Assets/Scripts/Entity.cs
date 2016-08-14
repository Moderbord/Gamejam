using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

    //public GameMaster GM;
    public int entity_ID;
    //private bool death = false;

    void Start()
    {
        Debug.Log("Entity start");
        //GM = GetComponentInParent<GameMaster>();
    }

    //public class PlayerStats
 //   {
 //       public int Health = 100;
 //   }

 //   public PlayerStats playerStats = new PlayerStats();

 //   public void DamagePlayer (int damage)
 //   {
 //       playerStats.Health -= damage;
 //       if (playerStats.Health <= 0)
 //       {
 //           GameMaster.KillEntity(this);
 //       }
 //   }

 //   void Update()
 //   {
 //       if (death)
 //       {
 //           GameMaster.KillEntity(this);
 //       }
 //   }

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
                GameMaster.KillEntity(this);
                break;
            case "Weapon":
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
