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
    bool firstTimeActive;
    RaycastHit hitUnderArm;
    bool DoneLiftArm;
    float ArmMass;
    float TimerLoweringArm;
    bool HitChosenObject;
    Transform ProductTransfering;
    // Start is called before the first frame update
    void Start()
    {
        TimerLoweringArm = 2;
        ArmMass = 70f;
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
                new Vector3(this.transform.position.x + 5, this.transform.position.y, this.transform.position.z), Time.deltaTime * 1.1f);
        }

        //Smart arm implementation (Work on distance of arm from the objecet and checks if there is an actuall object under the arm)



            //  Debug.Log(hitUnderArm.transform.name);


        /*

            Debug.Log((int)Vector3.Distance(SpringJointParent.connectedBody.GetComponent<Rigidbody>().position, hitUnderArm.transform.position));
            if ((int)Vector3.Distance(SpringJointParent.connectedBody.GetComponent<Rigidbody>().position, hitUnderArm.transform.position) >4)
            {
                if (ProductDeliverd == false && GoLeft == false && GoRight == false && hitUnderArm.transform.name != "Flour" || hitUnderArm.transform.name != "Flour(Clone)")
                {
                    TimerLoweringArm-= 0.8f * Time.deltaTime;

                    if ((int)TimerLoweringArm == 0)
                    {
                        SpringJointParent.connectedBody.GetComponent<Rigidbody>().mass = ArmMass += 6;
                        TimerLoweringArm = 2;
                    }

                }

            }
        }*/

        /*
          if ((int)Vector3.Distance(SpringJointParent.connectedBody.GetComponent<Rigidbody>().position, hitUnderArm.transform.position) != 3
              )
          {

              if (ProductDeliverd == false && GoLeft && hitUnderArm.transform.name != "Flour" || hitUnderArm.transform.name != "Flour(Clone)")
              {

                  SpringJointParent.connectedBody.GetComponent<Rigidbody>().mass = ArmMass -= 2;

              }
          }*/

        /*
        Debug.Log("Smart Arm");
        if (ProductDeliverd == false && GoLeft && hitUnderArm.transform.name == "Flour" || hitUnderArm.transform.name == "Flour(Clone)")
        {
            // timeLeft -= 0.8f * Time.deltaTime;


            if (ColidedWithFlour == false)//(int)timeLeft == 0 &&
            {

                SpringJointParent.connectedBody.GetComponent<Rigidbody>().mass = 45.19f;
                SpringJointParent.spring = 0;
                SpringJointParent.damper = 0;
                //  timeLeft = 3;
            }

        }



        if (ProductDeliverd == false && GoRight && hitUnderArm.transform.name == "Flour" || hitUnderArm.transform.name == "Flour(Clone)")
        {
            //  timeLeft -= 0.8f * Time.deltaTime;


            if (ColidedWithFlour == false)//(int)timeLeft == 0 &&
            {

                SpringJointParent.connectedBody.GetComponent<Rigidbody>().mass = 45.19f;
                SpringJointParent.spring = 0;
                SpringJointParent.damper = 0;
                //timeLeft = 3;
            }
        }
    }*/

        if (ProductDeliverd == false && GoLeft)
            {

            timeLeft -= 0.8f * Time.deltaTime;


                if ((int)timeLeft == 0 && ColidedWithFlour == false)
                {

            
                SpringJointParent.connectedBody.GetComponent<Rigidbody>().mass = 45.19f;
                    SpringJointParent.spring = 0;
                    SpringJointParent.damper = 0;
                    timeLeft = 3;



            }


            if (HitChosenObject==false&&Physics.Raycast(SpringJointParent.connectedBody.GetComponent<Rigidbody>().position, SpringJointParent.connectedBody.GetComponent<Rigidbody>().transform.TransformDirection(Vector3.down), out hitUnderArm))
            {
                // Debug.Log((int)Vector3.Distance(SpringJointParent.connectedBody.GetComponent<Rigidbody>().position, hitUnderArm.transform.position));
                SpringJointParent.maxDistance = (int)Vector3.Distance(SpringJointParent.connectedBody.GetComponent<Rigidbody>().position, hitUnderArm.transform.position);




       
            if (hitUnderArm.transform.name == "Flour" || hitUnderArm.transform.name == "Flour 1(Clone)" && HitChosenObject == false && ColidedWithFlour == false)
            {
                hitUnderArm.transform.GetComponent<FlourBackAndForthStrachConv>().Speed = 0.1f;
                ProductTransfering = hitUnderArm.transform;
                HitChosenObject = true;
            }

            }

        }


        /*Try More
    if (SpringJointParent.spring == 1000.4f && this.transform.GetComponentInChildren<StickToIngredient>().ArmHitTransfrom == null && DoneLiftArm == true)
    {
        SpringJointParent.connectedBody.GetComponent<Rigidbody>().mass = 45.19f;
        SpringJointParent.spring = 0;
        SpringJointParent.damper = 0;

        if (SpringJointParent.spring == 0)
            DoneLiftArm = false;

    }
    if (this.transform.GetComponentInChildren<StickToIngredient>().ArmHitTransfrom.name != "Flour" && DoneLiftArm == false )
    {



            SpringJointParent.spring = 1000.4f;
            SpringJointParent.damper = 400;

        if (SpringJointParent.spring == 1000.4f)
            DoneLiftArm = true;


    }
    */






        if (ProductDeliverd == false && GoRight)
            {
                timeLeft -= 0.8f * Time.deltaTime;


                if ((int)timeLeft == 0 && ColidedWithFlour == false)
                {

          
                SpringJointParent.connectedBody.GetComponent<Rigidbody>().mass = 45.19f;

                SpringJointParent.spring = 0;
                    SpringJointParent.damper = 0;
                    timeLeft = 3;
                }



            if (HitChosenObject == false && Physics.Raycast(SpringJointParent.connectedBody.GetComponent<Rigidbody>().position, SpringJointParent.connectedBody.GetComponent<Rigidbody>().transform.TransformDirection(Vector3.down), out hitUnderArm))
            {
                // Debug.Log((int)Vector3.Distance(SpringJointParent.connectedBody.GetComponent<Rigidbody>().position, hitUnderArm.transform.position));
                SpringJointParent.maxDistance = (int)Vector3.Distance(SpringJointParent.connectedBody.GetComponent<Rigidbody>().position, hitUnderArm.transform.position);





                if (hitUnderArm.transform.name == "Flour" || hitUnderArm.transform.name == "Flour 1(Clone)" && HitChosenObject == false && ColidedWithFlour == false)
                {
                    hitUnderArm.transform.GetComponent<FlourBackAndForthStrachConv>().Speed = 0.1f;
                    ProductTransfering = hitUnderArm.transform;
                    HitChosenObject = true;
                }

            }
        }




        if (this.transform.GetComponentInChildren<StickToIngredient>().ColidedWithFlour)
            {
         
            timeLeftBeforeMovment -= 0.8f * Time.deltaTime;
            SpringJointParent.maxDistance = 0;
                //    SpringJointParent.connectedBody.GetComponent<Rigidbody>().mass = 1;
                SpringJointParent.spring = 1000.4f;
                SpringJointParent.damper = 400;
                //  ArmthrowObject = false;

                float Horizantal = Input.GetAxis("Horizontal");
            ProductTransfering.GetComponent<FlourBackAndForthStrachConv>().Speed = 0.8f;

            /*time move the robot to the left or right*/
            if ((int)timeLeftBeforeMovment <= 0)
                {
                if (GoLeft && GoRight == false)
                    {
                        // ArmthrowObject = true;

                        /*move the robot to left*/
                        //  Arm.GetComponent<SpringJoint>().damper = 160f;

                        this.transform.position = Vector3.MoveTowards(this.transform.position,
                            new Vector3(this.transform.position.x - 2f, this.transform.position.y, this.transform.position.z)
                            , 2.2f * Time.deltaTime);


                        RobotPosToMoveTo = this.transform.position;
                        /*reach the position to the left , drop the product*/



                        if ((int)Vector3.Distance(StartPosRoboticArm, RobotPosToMoveTo) == 5)
                        {
                      
                        timeLeftBeforeMovment = 3;
                       // 
//ProductTransfering = null;
                        ProductDeliverd = true;

                            Arm.GetComponent<SpringJoint>().connectedBody = null;
                            //  Arm.GetComponent<SpringJoint>().damper = 7.9f;

                            Arm.GetComponent<Rigidbody>().mass = 1;
                            this.transform.GetComponentInChildren<StickToIngredient>().ColidedWithFlour = false;

                        HitChosenObject = false;
                        hitUnderArm.transform.GetComponent<FlourBackAndForthStrachConv>().Speed = 0.8f;


                    }
                    }


                    if (GoRight && GoLeft == false)
                    {
                        // ArmthrowObject = true;

                        /*move the robot to left*/
                        //  Arm.GetComponent<SpringJoint>().damper = 160f;

                        this.transform.position = Vector3.MoveTowards(this.transform.position,
                            new Vector3(this.transform.position.x + 2f, this.transform.position.y, this.transform.position.z)
                            , 2.2f * Time.deltaTime);


                        RobotPosToMoveTo = this.transform.position;
                        /*reach the position to the left , drop the product*/

                        Debug.Log((int)Vector3.Distance(StartPosRoboticArm, RobotPosToMoveTo));

                        if ((int)Vector3.Distance(StartPosRoboticArm, RobotPosToMoveTo) == 5)
                        {
                        timeLeftBeforeMovment = 3;
                        // 
                        //ProductTransfering = null;
                        ProductDeliverd = true;

                        Arm.GetComponent<SpringJoint>().connectedBody = null;
                        //  Arm.GetComponent<SpringJoint>().damper = 7.9f;

                        Arm.GetComponent<Rigidbody>().mass = 1;
                        this.transform.GetComponentInChildren<StickToIngredient>().ColidedWithFlour = false;

                        HitChosenObject = false;
                        hitUnderArm.transform.GetComponent<FlourBackAndForthStrachConv>().Speed = 0.8f;


                    }
                    }

                    //  Arm.transform.GetComponent<Rigidbody>().AddForce(Arm.right * Horizantal, ForceMode.Impulse);
                    //   SpringJointParent.connectedBody = null;
                    //timeLeftBeforeSwing = 0;
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


                if ((int)Vector3.Distance(StartPosRoboticArm, RobotPosToMoveTo) == 0 && (int)timeRobotBackAtStartPos == 0)
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
