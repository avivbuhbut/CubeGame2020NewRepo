using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToIngredient : MonoBehaviour
{


    public SpringJoint SpringJointArm;
    public bool ColidedWithFlour;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.L))
        {
            SpringJointArm.spring = 0;
            SpringJointArm.damper = 0;
            ///TransColided.transform.GetComponent<Rigidbody>().isKinematic = true;
          //  TransColided.transform.position = new Vector3(this.transform.position.x, TransColided.transform.position.y-1 , this.transform.position.z);

        }


        if (Input.GetKey(KeyCode.P))
        {
            SpringJointArm.spring = 43;
            SpringJointArm.damper = 20;

        }


    }




    void OnCollisionStay(Collision collision)
    {

        if (collision.transform.name == "Flour" || collision.transform.name == "Flour 1(Clone)")
        {
            SpringJointArm.connectedBody = collision.transform.GetComponent<Rigidbody>();
         
            //collision.transform.position = new Vector3(  SpringJointArm.transform.position.x, collision.transform.position.y, collision.transform.position.z);

        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Flour" || collision.transform.name == "Flour 1(Clone)")
        {
            ColidedWithFlour = true;
        
            // collision.transform.GetComponent<Rigidbody>().isKinematic = true;
            //  collision.transform.position = new Vector3(this.transform.position.x, this.transform.position.y+1, this.transform.position.z);

        }
    }


}
