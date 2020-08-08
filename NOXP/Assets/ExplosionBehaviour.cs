﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    public float timeUntilDestroyed;
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
        timeUntilDestroyed -= Time.fixedDeltaTime;
        this.transform.localScale *= timeUntilDestroyed;

        if (timeUntilDestroyed <= 0)
        {
            Destroy(gameObject);
        }
    }
}