using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickOnColision : MonoBehaviour
{
    Vector3 PlayerPos;
    float zPos; 
    // Start is called before the first frame update
    void Start()
    {

        zPos = this.transform.position.z;
    }

    // Update is called once per frame

    void Update()
    {
     

        if (Input.GetKey(KeyCode.V))
        {
         
                this.transform.parent = null;


            this.transform.GetComponent<Rigidbody>().detectCollisions = true;
            this.transform.GetComponent<Rigidbody>().isKinematic = false;
     
        }
        
    }


    void OnCollisionEnter(Collision collision)


    {


   
        if (collision.transform.name == "WideBelt1m")
        {
         
                this.transform.parent = collision.transform;

            this.transform.GetComponent<Rigidbody>().detectCollisions = false;
           this.transform.GetComponent<Rigidbody>().isKinematic = true;

        }
        
        
    }
}
