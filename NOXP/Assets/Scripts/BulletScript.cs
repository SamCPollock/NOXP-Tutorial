using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    float maxDistanceToMove = speed * Time.deltaTime;
        transform.position += transform.forward * maxDistanceToMove;
        if (transform.position.z > 15)
        {
            Destroy(gameObject);
        }
    }
}
