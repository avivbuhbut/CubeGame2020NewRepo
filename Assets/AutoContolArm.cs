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
    float timeLeftBeforeMovment = 2;
    bool ColidedWithFlour;
    bool ArmthrowObject;
    Vector3 StartPosRoboticArm;
    Vector3 RobotPosToMoveTo;
    Vector3 ArmStartPos;
    bool RobotHasMoved;
    bool ProductDeliverd;
    Vector3 AnchorStartConfiguration;
    // Start is called before the first frame update
    void Start()
    {
        AnchorStartConfiguration = new Vector3(Arm.GetComponent<SpringJoint>().anchor.x,
            Arm.GetComponent<SpringJoint>().anchor.y,
            Arm.GetComponent<SpringJoint>().anchor.z);
        StartPosRoboticArm = this.transform.position;

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

     
        if (this.transform.GetComponentInChildren<StickToIngredient>().ColidedWithFlour)
        {
            timeLeftBeforeMovment -= 0.8f * Time.deltaTime;
            Debug.Log("HERE");
        //    SpringJointParent.connectedBody.GetComponent<Rigidbody>().mass = 1;
            SpringJointParent.spring = 1000.4f;
            SpringJointParent.damper = 400;
          //  ArmthrowObject = false;

            float Horizantal = Input.GetAxis("Horizontal");

            /*time move the robot to the left or right*/
            if ((int)timeLeftBeforeMovment == 0 )
            {
              // ArmthrowObject = true;

                /*move the robot to left*/
                this.transform.position = Vector3.MoveTowards(this.transform.position, 
                    new Vector3(this.transform.position.x - 1.3f,this.transform.position.y, this.transform.position.z)
                    , 2 * Time.deltaTime);
                Debug.Log((int)Vector3.Distance(StartPosRoboticArm, RobotPosToMoveTo));

                RobotPosToMoveTo = this.transform.position;
                /*reach the position to the left , drop the product*/



                if ((int)Vector3.Distance(StartPosRoboticArm, RobotPosToMoveTo)==4)
                {
                    ProductDeliverd = true;
                    Debug.Log("Got to positino");
                    Arm.GetComponent<SpringJoint>().connectedBody = null;
                    this.transform.GetComponentInChildren<StickToIngredient>().ColidedWithFlour = false;
                }
              //  Arm.transform.GetComponent<Rigidbody>().AddForce(Arm.right * Horizantal, ForceMode.Impulse);
              //   SpringJointParent.connectedBody = null;
              //timeLeftBeforeSwing = 0;
            }
       

         


        }


        if (ProductDeliverd == false)
        {
            timeLeft -= 0.8f * Time.deltaTime;
            Debug.Log((int)timeLeft);
            if ((int)timeLeft == 0 && ColidedWithFlour == false)
            {
                SpringJointParent.connectedBody.GetComponent<Rigidbody>().mass = 45.19f;
                SpringJointParent.spring = 0;
                SpringJointParent.damper = 0;
                timeLeft = 3;
            }

        }

        if (ProductDeliverd == true && this.transform.GetComponentInChildren<StickToIngredient>().ColidedWithFlour == false)
        {

            /*droping product done, come back to start pos*/

            this.transform.position = Vector3.MoveTowards(this.transform.position,
          StartPosRoboticArm
           , 2 * Time.deltaTime);

            RobotPosToMoveTo = this.transform.position;
            Debug.Log((int)Vector3.Distance(StartPosRoboticArm, RobotPosToMoveTo));

            if ((int)Vector3.Distance(StartPosRoboticArm, RobotPosToMoveTo) == 0)
            {
                Arm.GetComponent<SpringJoint>().anchor = AnchorStartConfiguration;
                     ProductDeliverd = false;
            }

            // ProductDeliverd = false;
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
