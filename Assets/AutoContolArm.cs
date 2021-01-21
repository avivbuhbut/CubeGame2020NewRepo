﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoContolArm : MonoBehaviour
{

    public SpringJoint SpringJointParent;
    public Transform Arm;
    Vector3 Endpos;
    Transform TransColided;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.L))
        {
            SpringJointParent.spring = 0;
            SpringJointParent.damper = 0;
            ///TransColided.transform.GetComponent<Rigidbody>().isKinematic = true;
          //  TransColided.transform.position = new Vector3(this.transform.position.x, TransColided.transform.position.y-1 , this.transform.position.z);

        }


        if (Input.GetKey(KeyCode.P))
        {
            SpringJointParent.spring = 43;
            SpringJointParent.damper = 20;
          
        }

        if (Input.GetKey(KeyCode.O))
        {
            Vector3 screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y,this.transform.position.z);
            //this.transform.GetComponent<Rigidbody>().isKinematic = false;

           this.transform.position =  Vector3.MoveTowards(this.transform.position, screenPosition, Time.deltaTime * 1.1f);
        }

       
    }


     void OnCollisionStay(Collision collision)
    {
        if(collision.transform.name == "Flour")
        {
            TransColided = collision.transform;
           // collision.transform.GetComponent<Rigidbody>().isKinematic = true;
          //  collision.transform.position = new Vector3(this.transform.position.x, this.transform.position.y+1, this.transform.position.z);
            SpringJointParent.spring = 43;
            SpringJointParent.damper = 20;
        }
    }
}
