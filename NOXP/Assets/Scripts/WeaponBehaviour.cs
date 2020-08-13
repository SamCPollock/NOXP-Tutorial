using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    public GameObject playerBulletPrefab;
    public float secondsBetweenShots;
    public float accuracy;
    public float numberOfProjectiles;
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

    public void FireWeapon(Vector3 targetPosition)
    {
        if (shotCooldown <= 0)
        {
            if (accuracy != 0)
            {
                for (int i = 0; i < numberOfProjectiles; i++)
                {
                    GameObject newBullet = Instantiate(playerBulletPrefab, transform.position + transform.forward, transform.rotation);
                    // offset target position by a random amount, according to our accuracy.
                    float inaccuracy = Vector3.Distance(transform.position, targetPosition) / accuracy;
                    Vector3 inaccuratePosition = targetPosition;
                    inaccuratePosition.x += Random.Range(-inaccuracy, inaccuracy);
                    inaccuratePosition.z += Random.Range(-inaccuracy, inaccuracy);
                    newBullet.transform.LookAt(inaccuratePosition);
                    shotCooldown = secondsBetweenShots;
                    //playerRb.AddForce(-lookAtPosition * 100); // Trying to get it to push itself back when shooting.
                    newBullet.name = i.ToString();
                }
            }
        }
    }
}

