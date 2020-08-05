using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject playerBulletPrefab;
    Rigidbody playerRb;
    public float secondsBetweenShots;
    private float shotCooldown;


    // Start is called before the first frame update
    void Start()
    {
       playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shotCooldown > 0)
        {
            shotCooldown -= Time.deltaTime;
        }
        // Find a new position to move to 
        Vector3 inputVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // MOVE
        playerRb.velocity = inputVector * speed;

        Ray rayFromCameraToCursor = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        playerPlane.Raycast(rayFromCameraToCursor, out float distanceFromCamera);
        Vector3 cursorPosition = rayFromCameraToCursor.GetPoint(distanceFromCamera);

        // Look controller
        // Vector3 lookAtPosition = transform.position + inputVector; // This makes you look where you are moving
        Vector3 lookAtPosition = cursorPosition;
        transform.LookAt(lookAtPosition); // Face the new direction
        
        // CLICK TO FIRE
    if (Input.GetMouseButton(0))
        {
            if (shotCooldown <= 0)
            {
                Instantiate(playerBulletPrefab, transform.position + transform.forward, transform.rotation);
                shotCooldown = secondsBetweenShots;
                //playerRb.AddForce(-lookAtPosition * 100); // Trying to get it to push itself back when shooting.
            }
        }
    }
}
