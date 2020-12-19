using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickOnColision : MonoBehaviour
{

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
          //  if(this.transform.tag == "PizzaBox")
        //    this.transform.position = new Vector3(this.transform.position.x+0.1f, this.transform.position.y, zPos);
        }
        
    }


    void OnCollisionEnter(Collision collision)


    {



        if (collision.transform.tag == "Player")
        {
            this.transform.parent = collision.transform;

            this.transform.GetComponent<Rigidbody>().detectCollisions = false;
           this.transform.GetComponent<Rigidbody>().isKinematic = true;
            this.transform.position =  new Vector3(collision.transform.position.x+1.6f, collision.transform.position.y , zPos);
        }
        
        
    }
}
