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
    float timeRobotBackAtStartPos=3;
    float SpringDeafult;
    float SprintdamperDeafult;


    public Transform LeftArrowRoboticArm;
    public Transform RightArrowRoboticArm;
    Color RightArrowOriginalColor;
    Color LeftArrowOriginalColor;
    RaycastHit hit;
    bool GoLeft;
    bool GoRight;
    // Start is called before the first frame update
    void Start()
    {
        RightArrowOriginalColor = RightArrowRoboticArm.transform.GetComponent<Renderer>().material.color;
        LeftArrowOriginalColor = LeftArrowRoboticArm.transform.GetComponent<Renderer>().material.color;
        AnchorStartConfiguration = new Vector3(Arm.GetComponent<SpringJoint>().anchor.x,
            Arm.GetComponent<SpringJoint>().anchor.y,
            Arm.GetComponent<SpringJoint>().anchor.z);

        SpringDeafult = 40.43f;
        SprintdamperDeafult = 13.66f;
        StartPosRoboticArm = this.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);                    ///Very Useful Code! - tells the object name when clicked by the mouse

        // Casts the ray and get the first game object hit
        Physics.Raycast(ray, out hit);


        if (Input.GetMouseButtonDown(0))
        {
            if (hit.collider.gameObject == LeftArrowRoboticArm.gameObject)
            {
                LeftArrowRoboticArm.transform.GetComponent<Renderer>().material.color = Color.red;
                RightArrowRoboticArm.transform.GetComponent<Renderer>().material.color = RightArrowOriginalColor;
                GoLeft = true;
                GoRight = false;

            }

            if (hit.collider.gameObject == RightArrowRoboticArm.gameObject)
            {
                RightArrowRoboticArm.transform.GetComponent<Renderer>().material.color = Color.red;
                LeftArrowRoboticArm.transform.GetComponent<Renderer>().material.color = RightArrowOriginalColor;
                GoRight = true;
                GoLeft = false;
            }

        }

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

        //    SpringJointParent.connectedBody.GetComponent<Rigidbody>().mass = 1;
            SpringJointParent.spring = 1000.4f;
            SpringJointParent.damper = 400;
          //  ArmthrowObject = false;
        
            float Horizantal = Input.GetAxis("Horizontal");
        
                /*time move the robot to the left or right*/
                if ((int)timeLeftBeforeMovment <= 0 )
            {

                if (GoLeft)
                {
                    // ArmthrowObject = true;

                    /*move the robot to left*/
                    //  Arm.GetComponent<SpringJoint>().damper = 160f;

                    this.transform.position = Vector3.MoveTowards(this.transform.position,
                        new Vector3(this.transform.position.x - 2f, this.transform.position.y, this.transform.position.z)
                        , 2.2f * Time.deltaTime);
              

                RobotPosToMoveTo = this.transform.position;
                /*reach the position to the left , drop the product*/



                if ((int)Vector3.Distance(StartPosRoboticArm, RobotPosToMoveTo)==4)
                {
                    timeLeftBeforeMovment = 3;
                    ProductDeliverd = true;

                    Arm.GetComponent<SpringJoint>().connectedBody = null;
                  //  Arm.GetComponent<SpringJoint>().damper = 7.9f;

                    Arm.GetComponent<Rigidbody>().mass = 1;
                   this.transform.GetComponentInChildren<StickToIngredient>().ColidedWithFlour = false;
            

                }
                }

                //  Arm.transform.GetComponent<Rigidbody>().AddForce(Arm.right * Horizantal, ForceMode.Impulse);
                //   SpringJointParent.connectedBody = null;
                //timeLeftBeforeSwing = 0;
            }





        }


        if (ProductDeliverd == false)
        {
            timeLeft -= 0.8f * Time.deltaTime;


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

            timeRobotBackAtStartPos -= 0.8f * Time.deltaTime;

            /*droping product done, come back to start pos*/

            this.transform.position = Vector3.MoveTowards(this.transform.position,
          StartPosRoboticArm
           , 2.2f * Time.deltaTime);

            RobotPosToMoveTo = this.transform.position;


            if ((int)Vector3.Distance(StartPosRoboticArm, RobotPosToMoveTo) == 0 && (int)timeRobotBackAtStartPos==0)
            {
                Arm.GetComponent<SpringJoint>().anchor = AnchorStartConfiguration;
                     ProductDeliverd = false;
                timeRobotBackAtStartPos = 3;
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
