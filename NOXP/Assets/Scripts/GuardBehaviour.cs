using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardBehaviour : EnemyBehaviour
{

    public Light myLight;

    public float visionRange;
    public float visionRadius;
    public float rotateSpeed;
    
    public bool alerted;

    protected virtual void Start()
    {
        base.Start();
        alerted = false;
        myLight.color = Color.white;

    }

    protected override void Update()
    {
        myLight.color = Color.white;

        if (References.thePlayer != null)
        {
            Vector3 playerPosition = References.thePlayer.transform.position;
            Vector3 vectorToPlayer = playerPosition - transform.position;

            if (!alerted && Vector3.Distance(transform.position, playerPosition) <= visionRange)
            {
                if (Vector3.Angle(transform.forward, vectorToPlayer) <= visionRadius)
                {
                    References.enemySpawner.activated = true;
                    alerted = true;
                }
            }

            else
            {
                if (alerted)
                {
                    // Follow the player
                    FollowPlayer();
                    myLight.color = Color.red;
                    if (Vector3.Distance(transform.position, playerPosition) > visionRange)
                    {
                        alerted = false;
                    }
                }
            }

            if (!alerted)
            {
                Wander();
            }

        }

    }

    private void Wander()
    {
        // TODO: Attemping a random rotation, didn't work. 
        //for(int i = 0; i < 100; i++)
        //{
        //    float roll = Random.Range(i, 1000);
        //    int leftOrRight = Random.Range(0, 1);
        //        if (roll > 99)
        //        {
        //        transform.Rotate(new Vector3(0, 1, 0));
        //        }

        //        if (i >= 100)
        //    {
        //        i = 1;
        //    }
        //}

        float adjustedRotateSpeed = rotateSpeed * Time.deltaTime;
        myLight.color = Color.white;
        transform.Rotate(new Vector3(0, adjustedRotateSpeed, 0));
        //enemyRigidbody.velocity = transform.forward * enemySpeed;
        //transform.LookAt(transform.position + transform.forward);
    }
    

}


