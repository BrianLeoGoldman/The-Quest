using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    Animator anim;
    private int typeOfBullet;
    public int specialAmmo;
    private int ammo;
    public GameObject normalBullet;
    public GameObject fireBullet;
    public GameObject thunderBullet;
    public GameObject iceBullet;
    private float cooldownTimer;
    public float delay;

    private bool facingRight;

    void Start()
    {
        anim = GetComponent<Animator>();
        typeOfBullet = 0;
        cooldownTimer = 0.0f;
        ammo = 0;
    }

    void FixedUpdate()
    {
        facingRight = gameObject.GetComponent<PlayerMovement>().facingRight;
        cooldownTimer -= Time.deltaTime;
        float shoot = Input.GetAxis("Fire1");
        if (shoot > 0 && cooldownTimer <= 0)
        {
            Invoke("CreateBasicBullet", 0.3f);
            anim.SetBool("Shooting", true);
            cooldownTimer = delay;
        }
        if (shoot == 0)
        {
            anim.SetBool("Shooting", false);
        }

    }

    public void SetBullet(int type)
    {
        typeOfBullet = type;
        ammo = specialAmmo;
    }

    public int ReturnAmmo()
    {
        return typeOfBullet;
    }

    void CreateBasicBullet()
    {
        GameObject bulletToInstantiate = normalBullet;
        if(ammo == 0)
        {
            typeOfBullet = 0;
        }
        if(typeOfBullet == 1 && ammo > 0)
        {
            bulletToInstantiate = fireBullet;
            ammo--;
        }
        if (typeOfBullet == 2 && ammo > 0)
        {
            bulletToInstantiate = thunderBullet;
            ammo--;
        }
        if (typeOfBullet == 3 && ammo > 0)
        {
            bulletToInstantiate = iceBullet;
            ammo--;
        }
        Vector3 position = transform.position + new Vector3(1, 0, 0);
        GameObject newBullet = Instantiate(bulletToInstantiate, position, transform.rotation);
        newBullet.GetComponent<ProyectileManager>().IsFacingRight(facingRight);
  
    }
}
