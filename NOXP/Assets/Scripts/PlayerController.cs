﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    Rigidbody playerRb;
    public List<WeaponBehaviour> weaponList = new List<WeaponBehaviour>();
    public int selectedWeaponIndex;
    public bool hasSmg = false;
    private bool hasShotgun = false;



    // Start is called before the first frame update
    void Start()
    {
       playerRb = GetComponent<Rigidbody>();
        References.thePlayer = gameObject.GetComponent<PlayerController>();
        selectedWeaponIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
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
            // Tell weapon to fire
            weaponList[selectedWeaponIndex].FireWeapon(cursorPosition);
        }

        if (Input.GetMouseButtonDown(1))
        {
            selectedWeaponIndex += 1;
           
            if (selectedWeaponIndex == 1 && !hasSmg)
            {
                selectedWeaponIndex += 1;
            }
            if (selectedWeaponIndex == 2 && !hasShotgun)
            {
                selectedWeaponIndex += 1;
            }
            if (selectedWeaponIndex >= weaponList.Count)
            {
                selectedWeaponIndex = 0;
            }

        }
    }
    
    public void GetWeapon(int weaponIndex)
    {
        if (weaponIndex == 1)
        {
            hasSmg = true;
            selectedWeaponIndex = 1;
        }

        if (weaponIndex == 2)
        {
            hasShotgun = true;
            selectedWeaponIndex = 2;
        }
    }    
}
