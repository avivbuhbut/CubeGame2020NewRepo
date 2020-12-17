using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityNormal : MonoBehaviour
{

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
            reverseGravityOnColidPlayer.ReverseGravity = false;
            collision.transform.GetComponent<Rigidbody>().useGravity = true;
           // collision.transform.GetComponent<Rigidbody>().AddForce(Vector3.down * 8f, ForceMode.VelocityChange);
        }
    }
}
