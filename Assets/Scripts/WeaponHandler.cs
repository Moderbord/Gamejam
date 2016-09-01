using UnityEngine;
using System.Collections;

public class WeaponHandler : MonoBehaviour {

    //variabler för skjutning
    public string fireBtn;
    public Transform Skjutpunkt;
    public GameObject[] bullets;
    public float[] fireRate;
    float nextFire = 0f;
    int ammo = 0;
    int active;

    public GameObject[] bomb;
    public string fireBtnBomb;
    int ammoBomb = 0;
    int activeBomb;

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
        if (Input.GetAxisRaw(fireBtn) > 0 && ammo > 0) skjutNu();

        if (Input.GetAxisRaw(fireBtnBomb) > 0 && ammoBomb > 0) skjutNuBomb();

    }

    //funktion för att skjuta, vänsterklick = skjut
    void skjutNu()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate[active];

            Vector3 vector = facingRight ? new Vector3(0, 0, 180f) : new Vector3(0, 0, 0);

            Instantiate(bullets[active], Skjutpunkt.position, Quaternion.Euler(vector));

            ammo--;
        }
    }
    void skjutNuBomb()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate[active];

            Vector3 vector = facingRight ? new Vector3(0, 0, 180f) : new Vector3(0, 0, 0);

            Instantiate(bomb[active], Skjutpunkt.position, Quaternion.Euler(vector));

            ammoBomb--;
        }
    }

    public void addAmmo(int weapon, int amount)
    {
        active = weapon;
        ammo = amount;
    }
    public void addAmmoBomb(int weapon, int amount)
    {
        activeBomb = weapon;
        ammoBomb = amount;
    }

}
