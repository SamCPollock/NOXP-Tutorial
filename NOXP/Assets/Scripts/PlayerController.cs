using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject playerBulletPrefab;
    Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
       playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Find a new position to move to 
        Vector3 inputVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 lookAtPosition = transform.position + inputVector;

        // WASD TO MOVE
        playerRb.velocity = inputVector * speed;
        transform.LookAt(lookAtPosition); // Face the new direction
        
        // CLICK TO FIRE
    if (Input.GetMouseButtonDown(0))
        {
            Instantiate(playerBulletPrefab, transform.position + transform.forward, transform.rotation);
        }
    }
}
