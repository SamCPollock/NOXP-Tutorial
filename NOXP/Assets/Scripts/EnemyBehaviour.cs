using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    Rigidbody enemyRigidbody;
    public GameObject player;
    public float enemySpeed;
    public float secondsBetweenSpawns;
    private float spawnCooldown = 5;


    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnCooldown > 0)
        {
            spawnCooldown -= Time.deltaTime;
        }
        if (spawnCooldown <= 0)
        {
            spawnCooldown = secondsBetweenSpawns;
            Instantiate(gameObject);
        }
        Vector3 vectorToPlayer = player.transform.position - transform.position;
        enemyRigidbody.velocity = vectorToPlayer.normalized * enemySpeed;
    }
}
