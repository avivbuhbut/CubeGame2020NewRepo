using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToIngredient : MonoBehaviour
{


    public SpringJoint SpringJointArm;
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

        if(collision.transform.name == "Flour")
        SpringJointArm.connectedBody = collision.transform.GetComponent<Rigidbody>();
    }
}
