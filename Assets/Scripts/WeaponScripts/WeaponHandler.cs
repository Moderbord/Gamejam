using UnityEngine;
using System.Collections;

public class WeaponHandler : MonoBehaviour
{

    [Header("Hotkeys"), Tooltip("Keys used for firing weapons and bombs")]
    public KeyCode mainFireKey;
    public KeyCode bombKey;

    [Header("Firepoint"), Tooltip("The point of which the projectile will be instantiated")]
    public Transform firePoint;

    [Header("Projectiles"), Tooltip("The index and fire rate of bullets")]
    public GameObject[] weapon_bullet_index;
    public float[] weapon_fire_rate;

    [Header("Ammunition"), Tooltip("Ammunition per pickup")]
    public int knifePickup = 5;
    public int bombPickup = 2;


    float nextFire = 0f;
    int active_weapon;   
    int weaponAmmo = 0;
    int bombAmmo = 0;

    Animator animator;
    bool facingRight;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    

    void Update()
    {
        facingRight = animator.GetBool("FacingRight");
        
        if (Input.GetKey(mainFireKey) && weaponAmmo > 0)
        {
            FireProjectile();
        }
        if (Input.GetKey(bombKey) && bombAmmo > 0)
        {
            DropBomb();
        }
    }

    // Removes the spawned GameObject when the player collides with it and returns corresponding ammunition
    void OnTriggerEnter2D(Collider2D collider)
    {
        switch (collider.tag)
        {
            case "WeaponPickupKnife":
                Debug.Log("Knife");
                AddAmmo(C.WEAPONCODE_KNIFE, knifePickup);
                Destroy(collider.gameObject);
                break;

            case "WeaponPickupBomb":
                Debug.Log("Bomb");
                AddAmmoBomb(bombPickup);
                Destroy(collider.gameObject);
                break;

            default:
                break;
        }
    }
    
    // Fires the loaded projectile
    void FireProjectile()
    {
        // If enough time has passed between the interval of shots
        if (Time.time > nextFire)
        {
            // Saves current time plus the fire rate of current weapon in 'nextFire', which becomes greater than current time
            nextFire = Time.time + weapon_fire_rate[active_weapon];

            // Instatiates the bullet and rotates z-axis if necessary
            Vector3 vector = facingRight ? new Vector3(0, 0, 180f) : new Vector3(0, 0, 0);
            Instantiate(weapon_bullet_index[active_weapon], firePoint.position, Quaternion.Euler(vector));

            weaponAmmo--;
        }
    }

    // Drops a bomb from the firePoint
    void DropBomb()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + weapon_fire_rate[C.WEAPONCODE_BOMB];

            Vector3 vector = facingRight ? new Vector3(0, 0, 180f) : new Vector3(0, 0, 0);
            Instantiate(weapon_bullet_index[C.WEAPONCODE_BOMB], firePoint.position, Quaternion.Euler(vector));

            bombAmmo--;
        }
    }

    public void AddAmmo(int weapon, int amount)
    {
        active_weapon = weapon;
        weaponAmmo = amount;
    }

    public void AddAmmoBomb(int amount)
    {
        bombAmmo = amount;
    }

}
