using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HealthSystem : MonoBehaviour
{
    [FormerlySerializedAs("health")] // Write this to tell unity not to lose our data when we rename a variable. 
    public float maxHealth;

    float currentHealth;
    public GameObject healthBarPrefab;
    public GameObject deathEffect;
    HealthBarBehaviour myHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        GameObject healthBarObject = Instantiate(healthBarPrefab, References.canvas.transform);
        myHealthBar = healthBarObject.GetComponent<HealthBarBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        myHealthBar.ShowHealthFraction(currentHealth / maxHealth);
        myHealthBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 2);
    }

    public void TakeDamage(int damageTaken)
    {
        currentHealth -= damageTaken;
        if (currentHealth <= 0)
        {
            Instantiate(deathEffect, this.transform.position, this.transform.rotation);

            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (myHealthBar != null)
        {
            Destroy(myHealthBar.gameObject);
        }
    }
}
