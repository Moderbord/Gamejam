using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

    public int entity_ID;
    private Animator anim;

    void Start()
    {
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
