using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed;
    Rigidbody bulletRb;
    public float secondsUntilDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
        bulletRb.velocity = transform.forward * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        secondsUntilDestroyed-= Time.deltaTime;
        if (secondsUntilDestroyed < 1)
        {
            transform.localScale *= secondsUntilDestroyed;
        }
        if (secondsUntilDestroyed <= 0)
        {
            Destroy(gameObject);
        }
        //float maxDistanceToMove = bulletSpeed * Time.deltaTime;
        //transform.position += transform.forward * maxDistanceToMove; // this is the old movement code, non physics.
    //if (bulletRb.velocity.magnitude < 0.1f)
    //    {
    //        Destroy(gameObject);
    //    }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}

