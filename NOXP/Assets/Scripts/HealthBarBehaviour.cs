﻿using JetBrains.Annotations;
using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour
{

    public UnityEngine.UI.Image filledPart; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

     public void ShowHealthFraction(float fraction)
        {
        filledPart.rectTransform.localScale = new Vector3(fraction, 1, 1);
        }
   
}
