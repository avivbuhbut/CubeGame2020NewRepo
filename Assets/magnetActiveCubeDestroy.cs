﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnetActiveCubeDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // this.transform.GetComponent<SphereCollider>().isTrigger = false; // good to "shoot" the attached objects



        if (Input.GetMouseButtonDown(0))
            PushCubeDestroyer.magnetForce = 80f;
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetMouseButtonDown(0))
            PushCubeDestroyer.magnetForce = 0;
        ///    this.transform.GetComponent<SphereCollider>().isTrigger = true;

    }
}