using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickOnColision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

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



        if (collision.transform.tag == "Player")
        {
            this.transform.parent = collision.transform;

            this.transform.GetComponent<Rigidbody>().detectCollisions = false;
           this.transform.GetComponent<Rigidbody>().isKinematic = true;
            this.transform.position =  new Vector3(collision.transform.position.x+1.6f, collision.transform.position.y , collision.transform.position.z);
        }
        
        
    }
}
