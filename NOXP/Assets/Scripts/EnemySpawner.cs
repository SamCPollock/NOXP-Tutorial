using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject spawnPoint;
    public float secondsBetweenSpawns;
    float secondsUntilNextSpawn = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void FixedUpdate()
    {
        if (secondsUntilNextSpawn > 0)
        {
            secondsUntilNextSpawn -= Time.fixedDeltaTime;
        }
        if (secondsUntilNextSpawn <= 0)
        {
            secondsUntilNextSpawn = secondsBetweenSpawns;
            Instantiate(enemyPrefab, spawnPoint.transform.position, enemyPrefab.transform.rotation);
        }
    }
}
