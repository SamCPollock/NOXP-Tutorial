using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed;
    Rigidbody bulletRb;
    public float secondsUntilDestroyed;
    public int bulletDamage = 1;

    // Start is called before the first frame update
    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
        bulletShoot();
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

    public void bulletShoot()
    {
        bulletRb.velocity = transform.forward * bulletSpeed;

    }
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.CompareTag("Enemy"))
        //{
        //    Destroy(collision.gameObject);
        //    Destroy(gameObject);
        //}
        if (collision.gameObject.GetComponent<HealthSystem>() != null)
        {
            HealthSystem theirHealthSystem = collision.gameObject.GetComponent<HealthSystem>();
            EnemyBehaviour theirEnemyBehaviour = collision.gameObject.GetComponent<EnemyBehaviour>();
            // Non-method version of take damage.
            //collision.gameObject.GetComponent<HealthSystem>().health -= bulletDamage;
            theirHealthSystem.TakeDamage(1);
            //theirEnemyBehaviour.alerted = true;
            Destroy(gameObject);

        }
    }
}

