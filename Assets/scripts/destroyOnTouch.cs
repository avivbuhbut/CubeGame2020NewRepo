﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOnTouch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    void OnTriggerEnter(Collider col)
    {

        Destroy(col.gameObject);
    }*/


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PizzaBox")
            Destroy(this.gameObject);
        
    }
}