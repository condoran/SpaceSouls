﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nonStatic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.isStatic = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
