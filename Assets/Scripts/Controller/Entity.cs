using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

    public int entity_ID;
    public GameObject remains;

    private Animator anim;
    private bool deathBlock = false;
    private int controlledByPlayer, killedByPlayer;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public int GetID()
    {
        return entity_ID;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        switch (collider.tag)
        {
            case "DeathCollider":
                TriggerDeath();
                break;
            case "DeathProjectile":
                killedByPlayer = collider.gameObject.GetComponent<KilledByScript>().GetControlledByPlayer();
                Destroy(collider.gameObject);
                TriggerDeath();
                break;
            default:
                break;
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.transform.tag == "DeathCollider")
    //    {
    //        TriggerDeath();
    //    }
    //}

    public void TriggerDeath()
    {
        Debug.Log("Death trigger??");
        if (!deathBlock)
        {
            anim.SetBool("Death", true);

            if (anim.GetBool("FacingRight"))
            {
                Instantiate(remains, transform.position, transform.rotation);
            }
            else
            {
                GameObject mirror = Instantiate(remains, transform.position, transform.rotation) as GameObject;
                mirror.transform.localScale = new Vector2(mirror.transform.localScale.x * -1, mirror.transform.localScale.y);
            }
            Debug.Log("Death true.. calling " + controlledByPlayer + " as player and " + entity_ID + " as entity");
            GameMaster.RespawnEntity(controlledByPlayer, entity_ID);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Was blocked");
        }
       
        deathBlock = true;
    }

    public void SetControlledByPlayer(int player)
    {
        this.controlledByPlayer = player;
    }

    public int GetControlledByPlayer()
    {
        return controlledByPlayer;
    }

}
