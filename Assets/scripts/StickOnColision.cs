using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickOnColision : MonoBehaviour
{
    Vector3 PlayerPos;
    float zPos;
    bool colided;
    Transform PlayerTrans;
  
    // Start is called before the first frame update
    void Start()
    {

        zPos = this.transform.position.z;
    }

    // Update is called once per frame

    void Update()
    {

        if (colided && this.transform.parent.name == "Player")
        {
           this.transform.GetComponent<Rigidbody>().isKinematic = true;
          this.transform.position = new Vector3(PlayerTrans.position.x +1.5f , PlayerTrans.position.y, PlayerTrans.position.z) ;
        }
     

        if (Input.GetKey(KeyCode.V))
        {
            colided = false;
              this.transform.parent = null;


            //  this.transform.GetComponent<Rigidbody>().detectCollisions = true;
            this.transform.GetComponent<Rigidbody>().isKinematic = false;
            this.transform.GetComponent<Rigidbody>().useGravity = true;
           // this.transform.GetComponent<Rigidbody>().AddForce(Vector3.forward * 2.2f) ;
        }
        
    }


    void OnCollisionEnter(Collision collision)


    {


   
        if (collision.transform.name == "Player")
        {
            colided = true;
            PlayerTrans = collision.transform;
           
       this.transform.parent = collision.transform;

          //  this.transform.GetComponent<Rigidbody>().detectCollisions = false;
       //   this.transform.GetComponent<Rigidbody>().isKinematic = true;

        }
        
        
    }


    void OnCollisionExit(Collision collision)


    {
        colided = false;
            }
}
