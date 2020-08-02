using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody bulletRb = GetComponent<Rigidbody>();
        bulletRb.velocity = transform.forward * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
    float maxDistanceToMove = bulletSpeed * Time.deltaTime;
        //transform.position += transform.forward * maxDistanceToMove; // this is the old movement code, non physics.

    }
}
