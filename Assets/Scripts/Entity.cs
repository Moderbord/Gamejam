using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

    private bool death = false;

	public class PlayerStats
    {
        public int Health = 100;
    }

    public PlayerStats playerStats = new PlayerStats();

    public void DamagePlayer (int damage)
    {
        playerStats.Health -= damage;
        if (playerStats.Health <= 0)
        {
            GameMaster.KillEntity(this);
        }
    }

    void Update()
    {
        if (death)
        {
            GameMaster.KillEntity(this);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        switch (collider.tag)
        {
            case "DeathCollider":
                GameMaster.KillEntity(this);
                break;
            case "Weapon":
                break;
            default:
                break;       
        }
    }
	
}
