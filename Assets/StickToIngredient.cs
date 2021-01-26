using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToIngredient : MonoBehaviour
{


    public SpringJoint SpringJointArm;
    public bool ColidedWithFlour;
    public Transform ArmHitTransfrom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

     //   Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);                    ///Very Useful Code! - tells the object name when clicked by the mouse

        // Casts the ray and get the first game object hit
      
          //  Debug.DrawRay(this.transform.position, transform.TransformDirection(Vector3.down) * 10, Color.white);

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
        ArmHitTransfrom = collision.transform;
        if (collision.transform.name == "Flour" || collision.transform.name == "Flour 1(Clone)")
        {
            SpringJointArm.connectedBody = collision.transform.GetComponent<Rigidbody>();
         
      //    collision.transform.position = new Vector3(  this.transform.position.x  , this.transform.position.y-3, this.transform.position.z);

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
