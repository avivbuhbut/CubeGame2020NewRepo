﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSauceOnHitOneDollar : MonoBehaviour
{
    public GameObject SauceGamObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "OneDollar")
        {
            collision.gameObject.SetActive(false);
            GameObject Clone2 = Instantiate(SauceGamObj, new Vector3(this.transform.position.x, this.transform.position.y - 5f, this.transform.position.z +0.8f), Quaternion.identity);
            Clone2.transform.localRotation = Quaternion.Euler(0, 270, 0);

        }
    }
}
