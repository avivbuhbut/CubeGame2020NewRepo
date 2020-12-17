using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reverseGravityOnColidPlayer : MonoBehaviour
{


    public static bool ReverseGravity;


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
        if (collision.transform.tag == "Player")
        {
            ReverseGravity = true;
            collision.transform.GetComponent<Rigidbody>().useGravity = false;
            collision.transform.GetComponent<Rigidbody>().AddForce(Vector3.up * 8f, ForceMode.VelocityChange);
        }
    }



}
