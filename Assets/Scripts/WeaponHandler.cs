using UnityEngine;
using System.Collections;

public class WeaponHandler : MonoBehaviour {

    //variabler för skjutning
    public Transform Skjutpunkt;
    public Transform Skjutpunkt2; //höger riktning, buggar, behöver högre position
    public GameObject[] bullets;
    public float[] fireRate;
    float nextFire = 0f;
    int ammo = 0;
    int active;

    Animator animator;
    bool facingRight;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
	}

    void Update()
    {
        facingRight = animator.GetBool("FaceRight");

        //skjuta, ifall vänsterklick är nedpressad och man har skott kvar
        if (Input.GetAxisRaw("Fire1") > 0 && ammo > 0) skjutNu();

    }

    //funktion för att skjuta, vänsterklick = skjut
    void skjutNu()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate[active];
            if (facingRight)
            {
                Instantiate(bullets[active], Skjutpunkt2.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
            }
            else if (!facingRight)
            {
                Instantiate(bullets[active], Skjutpunkt.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            ammo--;
        }
    }

    public void addAmmo(int weapon, int amount)
    {
        active = weapon;
        ammo = amount;
    }

}
