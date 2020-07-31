using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject playerBulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    float maxDistanceToMove = speed * Time.deltaTime;

            transform.position += Vector3.forward * Input.GetAxis("Vertical") * maxDistanceToMove;
            transform.position += Vector3.right * Input.GetAxis("Horizontal") *maxDistanceToMove;
    if (Input.GetMouseButton(0))
        {
            Instantiate(playerBulletPrefab, transform.position, transform.rotation);
        }
    }
}
