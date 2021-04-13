using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableMovment : MonoBehaviour
{
    // Start is called before the first frame update
    bool PlayerTouchingTheFloor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.transform.GetComponent<Rigidbody>().velocity.magnitude > 0.3f)
            PlayerTouchingTheFloor = false;


        if (this.transform.GetComponent<Rigidbody>().velocity.magnitude <1 && PlayerTouchingTheFloor)
            this.transform.GetComponent<PlayerMovment>().enabled = true;
    }


     void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Floor")
            PlayerTouchingTheFloor = true;
        
    }
}
