using UnityEngine;
using System.Collections;

public class WeaponHandler : MonoBehaviour
{

    //variabler för skjutning
    public KeyCode mainFireBtn;
    public Transform Skjutpunkt;
    public GameObject[] weapon_bullet_index;
    public float[] weapon_fire_rate;
    float nextFire = 0f;
    int weaponAmmo = 0;
    int active_weapon; 
    
    /** Active weapon & weapon_bullet_index
     * 0 = kniv
     * 1 = TBA1
     * 2 = TBA2
     * 3 = TBA3
     * etc..
     */

    private int KNIV = 0, TBA1 = 1, TBA2 = 2, TBA3 = 3;

    Animator animator;
    bool facingRight;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        facingRight = animator.GetBool("FaceRight");

        //skjuta, ifall vänsterklick är nedpressad och man har skott kvar
        if (Input.GetKey(mainFireBtn) && weaponAmmo > 0) skjutNu();

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        switch (collider.tag)
        {
            case "kniv":
                Debug.Log("kvin");
                addAmmo(KNIV, 5);
                break;
            default:
                break;
        }
    }

    //funktion för att skjuta, vänsterklick = skjut
    void skjutNu()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + weapon_fire_rate[active_weapon];

            Vector3 vector = facingRight ? new Vector3(0, 0, 180f) : new Vector3(0, 0, 0);

            Instantiate(weapon_bullet_index[active_weapon], Skjutpunkt.position, Quaternion.Euler(vector));

            weaponAmmo--;
        }
    }

    public void addAmmo(int weapon, int amount)
    {
        active_weapon = weapon;
        weaponAmmo = amount;
    }

}
