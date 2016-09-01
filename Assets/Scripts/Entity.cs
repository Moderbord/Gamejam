using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

    public int entity_ID;
    private WeaponHandler wHandler;
    private Animator anim;

    void Start()
    {
        wHandler = GetComponent<WeaponHandler>();
        anim = GetComponent<Animator>();
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
                triggerDeath();
                break;
            case "DeathProjectile":
                Destroy(collider.gameObject);
                triggerDeath();
                break;
            case "kniv":
                Debug.Log("knif");
                wHandler.addAmmo(0, 5);
                Destroy(collider.gameObject);
                break;
            case "bomb":
                Debug.Log("bomb");
                wHandler.addAmmoBomb(0, 5);
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

    public GameObject remainsRight;

    public void triggerDeath()
    {
        Debug.Log("death triggered");
        anim.SetBool("death", true);
        if (anim.GetBool("FaceRight"))
        {
            Instantiate(remainsRight, transform.position, transform.rotation);
        } else
        {
            GameObject test = Instantiate(remainsRight, transform.position, transform.rotation) as GameObject;
            test.transform.localScale = new Vector3(test.transform.localScale.x * -1, test.transform.localScale.y);
        }
        GameMaster.RespawnEntity(entity_ID);
        Destroy(this.gameObject);
    }

}
