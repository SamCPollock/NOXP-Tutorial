using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehaviour : MonoBehaviour
{
    public int weaponIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name + "collided with me");
        PlayerController playerControllerScript = other.gameObject.GetComponent<PlayerController>();
        if (playerControllerScript != null)
        {
            other.gameObject.GetComponent<PlayerController>().GetWeapon(weaponIndex);
            Destroy(gameObject);
        }
    }
}
