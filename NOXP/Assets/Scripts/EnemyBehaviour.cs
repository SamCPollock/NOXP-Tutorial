using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    Rigidbody enemyRigidbody;
    public float enemySpeed;
    public float secondsBetweenSpawns;
    public int enemyDamage;
    private float spawnCooldown = 5;


    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // ENEMY CLONE BEHAVIOUR
        //if (spawnCooldown > 0)
        //{
        //    spawnCooldown -= Time.deltaTime;
        //}
        //if (spawnCooldown <= 0)
        //{
        //    spawnCooldown = secondsBetweenSpawns;
        //    Instantiate(gameObject);
        //}
        if (References.thePlayer != null)
        {
            Vector3 vectorToPlayer = References.thePlayer.transform.position - transform.position;
            enemyRigidbody.velocity = vectorToPlayer.normalized * enemySpeed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HealthSystem>().TakeDamage(enemyDamage);
        }
    }
}
