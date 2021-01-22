using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoContolArm : MonoBehaviour
{

    public SpringJoint SpringJointParent;
    public Transform Arm;
    Vector3 Endpos;
    Transform TransColided;
    float timeLeft=2; 
    bool ColidedWithFlour;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    



        if (Input.GetKey(KeyCode.O))
        {
           // Vector3 screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, this.transform.position.z);
            //this.transform.GetComponent<Rigidbody>().isKinematic = false;

            this.transform.position = Vector3.MoveTowards(this.transform.position,
                new Vector3(this.transform.position.x+5,this.transform.position.y,this.transform.position.z), Time.deltaTime * 1.1f);
        }


        timeLeft -= 0.8f * Time.deltaTime;
        Debug.Log((int)timeLeft);
        if ((int)timeLeft == 0 && ColidedWithFlour == false)
        {
            SpringJointParent.connectedBody.GetComponent<Rigidbody>().mass = 45.19f;
                SpringJointParent.spring = 0;
            SpringJointParent.damper = 0;
            timeLeft = 3;
        }

        if (this.transform.GetComponentInChildren<StickToIngredient>().ColidedWithFlour)
        {
            Debug.Log("HERE");
        //    SpringJointParent.connectedBody.GetComponent<Rigidbody>().mass = 1;
            SpringJointParent.spring = 1000.4f;
            SpringJointParent.damper = 400;
        }






        /*
         *
                 timeLeft -= 0.8f * Time.deltaTime;
            Debug.Log((int)timeLeft);
            if ((int)timeLeft == 0&& colidedWithFLour==false)
            {
                SpringJointParent.spring = 0;
                SpringJointParent.damper = 0;
                ///TransColided.transform.GetComponent<Rigidbody>().isKinematic = true;
                //  TransColided.transform.position = new Vector3(this.transform.position.x, TransColided.transform.position.y-1 , this.transform.position.z);
                //timeLeft = 3;
            }else if ((int)timeLeft==2&& colidedWithFLour)
            {
                SpringJointParent.spring = 43;
                SpringJointParent.damper = 20;



            }
    */

    }


}
