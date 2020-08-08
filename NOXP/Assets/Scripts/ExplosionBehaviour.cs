using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    public float secondsToExist;
    float secondsAlive;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        secondsAlive = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        secondsAlive += Time.fixedDeltaTime;

        float lifeFraction = secondsAlive / secondsToExist;
        Vector3 maxScale = Vector3.one * 5;
        transform.localScale = Vector3.Lerp(Vector3.zero, maxScale, lifeFraction);
        //this.transform.localScale *= timeUntilDestroyed;

        if (secondsAlive >= secondsToExist)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        HealthSystem caughtInExplosion = collision.gameObject.GetComponent<HealthSystem>();
        if (caughtInExplosion != null)
        {
            caughtInExplosion.TakeDamage(damage);
        }
    }
}
