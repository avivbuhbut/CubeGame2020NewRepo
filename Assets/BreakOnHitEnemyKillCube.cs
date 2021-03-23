﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakOnHitEnemyKillCube : MonoBehaviour
{


    Transform PlayerTrans;
    bool MagnitudeOk;// Start is called before the first frame update
    void Start()
    {
        PlayerTrans = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        //  Debug.Log(this.transform.GetComponent<Rigidbody>().velocity.magnitude);
        //    Debug.Log(tempRenddomNum);
        if (this.transform.GetComponent<Rigidbody>().velocity.magnitude >= 25)
            MagnitudeOk = true;
        else
            MagnitudeOk = false;


    }



    void OnCollisionEnter(Collision collision)
    {


        //  Debug.Log("Destroy cube  Colided with " + collision.transform.name);
        if (collision.transform.tag == "Floor" && MagnitudeOk && PlayerTrans.GetComponent<CheckIfRainHitPlayer>().PlayerElectricFull)
        {
            this.transform.GetComponent<MeshDestroy>().DestroyMesh(this.transform.gameObject.GetComponent<MeshFilter>().mesh, this.transform.GetComponent<MeshDestroy>(), this.transform.gameObject);


        
        }

    }
}
