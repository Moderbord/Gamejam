﻿using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

    public int entity_ID;
    public GameObject remains;

    private Animator anim;

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
                Debug.Log("Bomb");
                TriggerDeath();
                break;
            case "DeathProjectile":
                Destroy(collider.gameObject);
                TriggerDeath();
                break;
            default:
                break;
        }
    }

    public void TriggerDeath()
    {    
        anim.SetBool("Death", true);

        if (anim.GetBool("FacingRight"))
        {
            Debug.Log("Right");
            Instantiate(remains, transform.position, transform.rotation);
        }
        else
        {
            Debug.Log("Left");
            GameObject mirror = Instantiate(remains, transform.position, transform.rotation) as GameObject;
            mirror.transform.localScale = new Vector2(mirror.transform.localScale.x * -1, mirror.transform.localScale.y);
        }

        GameMaster.RespawnEntity(entity_ID);
        Destroy(gameObject);
    }

}
