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
     * 1 = bomb
     * 2 = TBA2
     * 3 = TBA3
     * etc..
     */

    private int KNIV = 0, BOMB = 1, TBA2 = 2, TBA3 = 3;

    // variabler för bomb
    //public GameObject[] bomb;
    public KeyCode bombFireBtn;
    int ammoBomb = 0;
    //int activeBomb;

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

        if (Input.GetKey(bombFireBtn) && ammoBomb > 0) skjutNuBomb();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        switch (collider.tag)
        {
            case "kniv":
                Debug.Log("kvin");
                addAmmo(KNIV, 5);
                break;
            case "bomb":
                Debug.Log("bomb");
                addAmmoBomb(5);
                Destroy(collider.gameObject);
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

    void skjutNuBomb()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + weapon_fire_rate[active_weapon];

            Vector3 vector = facingRight ? new Vector3(0, 0, 180f) : new Vector3(0, 0, 0);

            Instantiate(weapon_bullet_index[BOMB], Skjutpunkt.position, Quaternion.Euler(vector));

            ammoBomb--;
        }
    }

    public void addAmmo(int weapon, int amount)
    {
        active_weapon = weapon;
        weaponAmmo = amount;
    }

    public void addAmmoBomb(int amount)
    {
        ammoBomb = amount;
    }

}
