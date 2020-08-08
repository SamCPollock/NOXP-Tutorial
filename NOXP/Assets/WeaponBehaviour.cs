using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    public GameObject playerBulletPrefab;
    public float secondsBetweenShots;
    private float shotCooldown;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (shotCooldown > 0)
        {
            shotCooldown -= Time.deltaTime;
        }

    }

    public void FireWeapon()
    {
        if (shotCooldown <= 0)
        {
            Instantiate(playerBulletPrefab, transform.position + transform.forward, transform.rotation);
            shotCooldown = secondsBetweenShots;
            //playerRb.AddForce(-lookAtPosition * 100); // Trying to get it to push itself back when shooting.
        }
    }
}

