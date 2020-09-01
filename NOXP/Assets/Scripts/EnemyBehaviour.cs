using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Rigidbody enemyRigidbody;

    public float enemySpeed;
    public float secondsBetweenSpawns;
   
    

    public int enemyDamage;
    private float spawnCooldown = 5;


    // Start is called before the first frame update
    protected void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
     

    }

    // Update is called once per frame
    protected virtual void Update()
    {
         FollowPlayer();
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

        

    }

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HealthSystem>().TakeDamage(enemyDamage);
        }
    }

    protected void FollowPlayer()
    {
        if (References.thePlayer != null)
        {
            Vector3 playerPosition = References.thePlayer.transform.position;
            Vector3 vectorToPlayer = playerPosition - transform.position;
            Vector3 playerGroundPosition = new Vector3(playerPosition.x, transform.position.y, playerPosition.z);
            enemyRigidbody.velocity = vectorToPlayer.normalized * enemySpeed;
            transform.LookAt(playerGroundPosition);
        }

       
    }


}
