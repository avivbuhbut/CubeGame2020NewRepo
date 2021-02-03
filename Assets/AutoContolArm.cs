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
    Transform ProductTransferingFlour;
    Transform ProductTransferingMoney;
    static float DurationPressMouse=3;
    bool PositionEditRightActivate;
    bool PositionEditLeftActivate;
    bool EditPosRight;
    bool EditPosLeft;
    float tempMouseDurationEditMode;
    bool RepositionRobot;
    bool hasReleventObjectUnder;
    //public Transform FutureEndPoint;
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
        Debug.Log(DurationPressMouse);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);                    ///Very Useful Code! - tells the object name when clicked by the mouse

        // Casts the ray and get the first game object hit
        Physics.Raycast(ray, out hit);

        // if (PositionEditRightActivate && Input.GetKey(KeyCode.Mouse0) && !Input.GetMouseButtonUp(0) && hit.collider.gameObject != LeftArrowRoboticArm.gameObject && !Input.GetKey(KeyCode.KeypadEnter))
        //     {

        /*
        if (Input.GetKey(KeyCode.Mouse0))
        {
            tempMouseDurationEditMode -= 0.8f * Time.deltaTime;

            if (tempMouseDurationEditMode <= 0)
            {
                tempMouseDurationEditMode = 0;
            }
            else
            {
                DurationPressMouse = 3;
            }
        }*/

        //     this.transform.position = Vector3.MoveTowards(this.transform.position,
        //  new Vector3(this.transform.position.x + 2f, this.transform.position.y, this.transform.position.z)
        //  , 2.2f * Time.deltaTime);

        //     Arm.GetComponent<StickToIngredient>().SpringJointArm.connectedBody = this.transform.GetComponent<Rigidbody>();
        //      RobotPosToMoveTo = this.transform.position;
        //        DurationPressMouse = 0;
        //      LeftArrowRoboticArm.transform.GetComponent<Renderer>().material.color = RightArrowOriginalColor;
        //   }
        //   if (PositionEditLeftActivate && Input.GetKey(KeyCode.Mouse0) && !Input.GetMouseButtonUp(0) && hit.collider.gameObject != RightArrowRoboticArm.gameObject && !Input.GetKey(KeyCode.KeypadEnter))
        //   {


        /*
        if (Input.GetKey(KeyCode.Mouse0))
        {
            tempMouseDurationEditMode -= 0.8f * Time.deltaTime;

            if (tempMouseDurationEditMode <= 0)
            {
                tempMouseDurationEditMode = 0;
            }
            else
            {
                DurationPressMouse = 3;
            }
        }*/


        //      this.transform.position = Vector3.MoveTowards(this.transform.position,
        //    new Vector3(this.transform.position.x - 2f, this.transform.position.y, this.transform.position.z)
        //   , 2.2f * Time.deltaTime);

        //       Arm.GetComponent<StickToIngredient>().SpringJointArm.connectedBody = this.transform.GetComponent<Rigidbody>();
        //       RobotPosToMoveTo = this.transform.position;
        //       DurationPressMouse = 0;
        //       RightArrowRoboticArm.transform.GetComponent<Renderer>().material.color = RightArrowOriginalColor;

        //    }
        //


        // if (Input.GetMouseButtonDown(0) && hit.collider.gameObject != LeftArrowRoboticArm.gameObject || hit.collider.gameObject != RightArrowRoboticArm.gameObject)
        //   DurationPressMouse = 3;

        if (Input.GetKey(KeyCode.Mouse0) && hit.collider.gameObject == LeftArrowRoboticArm.gameObject || hit.collider.gameObject == RightArrowRoboticArm.gameObject)
        {

            DurationPressMouse -= 0.8f * Time.deltaTime;
            Debug.Log((int)DurationPressMouse);
            if (DurationPressMouse <= 0)
            {
                DurationPressMouse = 0;
            }
            else
            {
                EditPosLeft = false;
                EditPosRight = false;

            }


            if ((int)DurationPressMouse == 0 && hit.collider.gameObject == LeftArrowRoboticArm.gameObject)
            {
                LeftArrowRoboticArm.transform.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 1));

                EditPosLeft = true;
            }


            if ((int)DurationPressMouse == 0 && hit.collider.gameObject == RightArrowRoboticArm.gameObject)
            {
                RightArrowRoboticArm.transform.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 1));
                EditPosRight = true;
            }

            /*
        if (PositionEditRightActivate&& hit.collider.gameObject == RightArrowRoboticArm.gameObject)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position,
                          new Vector3(this.transform.position.x + 2f, this.transform.position.y, this.transform.position.z)
                          , 2.2f * Time.deltaTime);

        }*/

        }



        if (Input.GetMouseButtonUp(0))
        {


            if (hit.collider.gameObject == LeftArrowRoboticArm.gameObject && (int)DurationPressMouse > 1)
            {
                RepositionRobot = false;
                EditPosRight = false;
                EditPosLeft = false;
                PositionEditRightActivate = false;
                PositionEditLeftActivate = false;

                LeftArrowRoboticArm.transform.GetComponent<Renderer>().material.color = Color.red;
                RightArrowRoboticArm.transform.GetComponent<Renderer>().material.color = RightArrowOriginalColor;
                GoLeft = true;
                GoRight = false;

                DurationPressMouse = 3;
            }

            if (hit.collider.gameObject == RightArrowRoboticArm.gameObject && (int)DurationPressMouse > 1)
            {
                RepositionRobot = false;
                EditPosRight = false;
                EditPosLeft = false;

                PositionEditRightActivate = false;
                PositionEditLeftActivate = false;
                RightArrowRoboticArm.transform.GetComponent<Renderer>().material.color = Color.red;
                LeftArrowRoboticArm.transform.GetComponent<Renderer>().material.color = RightArrowOriginalColor;
                GoRight = true;
                GoLeft = false;
                DurationPressMouse = 3;
            }


            if (hit.collider.gameObject == LeftArrowRoboticArm.gameObject && (int)DurationPressMouse == 0 && EditPosLeft)
            {
                PositionEditLeftActivate = true;
                GoRight = false;
                GoLeft = false;
                RightArrowRoboticArm.transform.GetComponent<Renderer>().material.color = RightArrowOriginalColor;
                LeftArrowRoboticArm.transform.GetComponent<Renderer>().material.color = Color.yellow;



                DurationPressMouse = 3;
            }



            if (hit.collider.gameObject == RightArrowRoboticArm.gameObject && (int)DurationPressMouse == 0 && EditPosRight)
            {
                PositionEditRightActivate = true;
                GoRight = false;
                GoLeft = false;
                LeftArrowRoboticArm.transform.GetComponent<Renderer>().material.color = LeftArrowOriginalColor;
                RightArrowRoboticArm.transform.GetComponent<Renderer>().material.color = Color.yellow;
                DurationPressMouse = 3;
            }

        }

        if (PositionEditLeftActivate && Input.GetKey(KeyCode.Mouse0) && hit.collider.gameObject == LeftArrowRoboticArm.gameObject)
        {

            this.transform.position = Vector3.MoveTowards(this.transform.position,
         new Vector3(this.transform.position.x - 2f, this.transform.position.y, this.transform.position.z)
         , 2.2f * Time.deltaTime);

            Arm.GetComponent<StickToIngredient>().SpringJointArm.connectedBody = this.transform.GetComponent<Rigidbody>();
            RobotPosToMoveTo = this.transform.position;

            RepositionRobot = true;
            // DurationPressMouse = 0;
            //    LeftArrowRoboticArm.transform.GetComponent<Renderer>().material.color = RightArrowOriginalColor;
        }



        if (PositionEditRightActivate && Input.GetKey(KeyCode.Mouse0) && hit.collider.gameObject == RightArrowRoboticArm.gameObject)
        {
            RepositionRobot = true;
            this.transform.position = Vector3.MoveTowards(this.transform.position,
         new Vector3(this.transform.position.x + 2f, this.transform.position.y, this.transform.position.z)
         , 2.2f * Time.deltaTime);

            Arm.GetComponent<StickToIngredient>().SpringJointArm.connectedBody = this.transform.GetComponent<Rigidbody>();
            RobotPosToMoveTo = this.transform.position;

            //    FutureEndPoint.transform.position = RobotPosToMoveTo;
            //   FutureEndPoint.GetComponent<LineRenderer>().SetPosition(0, RobotPosToMoveTo);
            //        FutureEndPoint.GetComponent<LineRenderer>().SetPosition(1, new Vector3(RobotPosToMoveTo.x, RobotPosToMoveTo.y-2, RobotPosToMoveTo.z));
            // DurationPressMouse = 0;
            //    LeftArrowRoboticArm.transform.GetComponent<Renderer>().material.color = RightArrowOriginalColor;
        }

        if (RepositionRobot == true)
        {
            StartPosRoboticArm = this.transform.position;
        }


        if (Input.GetKey(KeyCode.O))
        {
            // Vector3 screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, this.transform.position.z);
            //this.transform.GetComponent<Rigidbody>().isKinematic = false;

            this.transform.position = Vector3.MoveTowards(this.transform.position,
                new Vector3(this.transform.position.x + 5, this.transform.position.y, this.transform.position.z), Time.deltaTime * 1.1f);
        }


        if (Physics.Raycast(SpringJointParent.connectedBody.GetComponent<Rigidbody>().position, SpringJointParent.connectedBody.GetComponent<Rigidbody>().transform.TransformDirection(Vector3.down), out hitUnderArm))
            Debug.Log("hitUnderArm.transform.tag: " + hitUnderArm.transform.tag);


        if (Physics.Raycast(SpringJointParent.connectedBody.GetComponent<Rigidbody>().position, SpringJointParent.connectedBody.GetComponent<Rigidbody>().transform.TransformDirection(Vector3.down), out hitUnderArm)){

            if (hitUnderArm.transform.name == "Flour" || hitUnderArm.transform.name == "Flour 1(Clone)")
            {
                    ProductTransferingFlour = hitUnderArm.transform;

                hasReleventObjectUnder = true;
            }


            if (hitUnderArm.transform.tag == "Money" )
            {
       
                    ProductTransferingMoney = hitUnderArm.transform;

                 
               

                hasReleventObjectUnder = true;
            }




        }

        if (ProductDeliverd == false && GoLeft&& hasReleventObjectUnder)
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

                SpringJointParent.maxDistance = (int)Vector3.Distance(SpringJointParent.connectedBody.GetComponent<Rigidbody>().position, hitUnderArm.transform.position);






                if (hitUnderArm.transform.name == "Flour" || hitUnderArm.transform.name == "Flour 1(Clone)" && HitChosenObject == false && ColidedWithFlour == false)
                {
                    hitUnderArm.transform.GetComponent<FlourBackAndForthStrachConv>().Speed = 0.1f;
                    ProductTransferingFlour = hitUnderArm.transform;
                    HitChosenObject = true;
                }
                else 
                    if (ProductTransferingFlour.transform != null)
                    ProductTransferingFlour.transform.GetComponent<FlourBackAndForthStrachConv>().Speed = 0.8f;



                if (hitUnderArm.transform.tag == "Money" && HitChosenObject == false)
               {
                        hitUnderArm.transform.GetComponent<MoneyBackAndForthOnConv>().Speed = 0.1f;
                    ProductTransferingMoney = hitUnderArm.transform;
                    HitChosenObject = true;
                }
                else
                    if (ProductTransferingMoney.transform != null)
                    ProductTransferingMoney.transform.GetComponent<FlourBackAndForthStrachConv>().Speed = 0.8f;

            }

        }

    




        if (ProductDeliverd == false && GoRight&& hasReleventObjectUnder)
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

                SpringJointParent.maxDistance = (int)Vector3.Distance(SpringJointParent.connectedBody.GetComponent<Rigidbody>().position, hitUnderArm.transform.position);






                if (hitUnderArm.transform.name == "Flour" || hitUnderArm.transform.name == "Flour 1(Clone)" && HitChosenObject == false && ColidedWithFlour == false)
                {
                    hitUnderArm.transform.GetComponent<FlourBackAndForthStrachConv>().Speed = 0.1f;
                    ProductTransferingFlour = hitUnderArm.transform;
                    HitChosenObject = true;
                }else
                        if (ProductTransferingFlour.transform != null)
                    ProductTransferingFlour.transform.GetComponent<FlourBackAndForthStrachConv>().Speed = 0.8f;



                if (hitUnderArm.transform.tag == "Money" && HitChosenObject == false)
                {
                    hitUnderArm.transform.GetComponent<MoneyBackAndForthOnConv>().Speed = 0.1f;
                    ProductTransferingMoney = hitUnderArm.transform;
                    HitChosenObject = true;
                }
                if (ProductTransferingMoney.transform != null)
                    ProductTransferingMoney.transform.GetComponent<FlourBackAndForthStrachConv>().Speed = 0.8f;

            }
        }


        
        if (ProductTransferingFlour.transform != null)
            FlourCollision();


        if(ProductTransferingMoney.transform!=null)
           MoneyCollision();


    }



    void FlourCollision()
    {

        if (this.transform.GetComponentInChildren<StickToIngredient>().ColidedWithFlour)
        {

            timeLeftBeforeMovment -= 0.8f * Time.deltaTime;
            SpringJointParent.maxDistance = 0;
            //    SpringJointParent.connectedBody.GetComponent<Rigidbody>().mass = 1;
            SpringJointParent.spring = 1000.4f;
            SpringJointParent.damper = 400;
            //  ArmthrowObject = false;

            float Horizantal = Input.GetAxis("Horizontal");
            ProductTransferingFlour.GetComponent<FlourBackAndForthStrachConv>().Speed = 0.8f;

            /*time move the robot to the left or right*/
            if ((int)timeLeftBeforeMovment <= 0)
            {
                if (GoLeft && GoRight == false && hasReleventObjectUnder)
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
                        ProductTransferingFlour = null;
                        ProductDeliverd = true;

                        Arm.GetComponent<SpringJoint>().connectedBody = null;
                        //  Arm.GetComponent<SpringJoint>().damper = 7.9f;

                        Arm.GetComponent<Rigidbody>().mass = 1;
                        this.transform.GetComponentInChildren<StickToIngredient>().ColidedWithFlour = false;

                        HitChosenObject = false;
                        hitUnderArm.transform.GetComponent<FlourBackAndForthStrachConv>().Speed = 0.8f;


                    }
                }


                if (GoRight && GoLeft == false&& hasReleventObjectUnder)
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
                        ProductTransferingFlour = null;
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
                hasReleventObjectUnder = false;
            }

            // ProductDeliverd = false;
        }


    }


    void MoneyCollision()
    {

        if (this.transform.GetComponentInChildren<StickToIngredient>().ColidedWithMoney&& ProductTransferingMoney.transform.tag == "Money")
        {

            timeLeftBeforeMovment -= 0.8f * Time.deltaTime;
            SpringJointParent.maxDistance = 0;
            //    SpringJointParent.connectedBody.GetComponent<Rigidbody>().mass = 1;
            SpringJointParent.spring = 1000.4f;
            SpringJointParent.damper = 400;
            //  ArmthrowObject = false;

            float Horizantal = Input.GetAxis("Horizontal");
            ProductTransferingMoney.GetComponent<MoneyBackAndForthOnConv>().Speed = 0.8f;

            /*time move the robot to the left or right*/
            if ((int)timeLeftBeforeMovment <= 0)
            {
                if (GoLeft && GoRight == false && hasReleventObjectUnder)
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
                        ProductTransferingMoney = null;
                        ProductDeliverd = true;

                        Arm.GetComponent<SpringJoint>().connectedBody = null;
                        //  Arm.GetComponent<SpringJoint>().damper = 7.9f;

                        Arm.GetComponent<Rigidbody>().mass = 1;
                        this.transform.GetComponentInChildren<StickToIngredient>().ColidedWithMoney = false;

                        HitChosenObject = false;
                        hitUnderArm.transform.GetComponent<MoneyBackAndForthOnConv>().Speed = 0.8f;


                    }
                }


                if (GoRight && GoLeft == false && hasReleventObjectUnder)
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
                        ProductTransferingMoney = null;
                        ProductDeliverd = true;

                        Arm.GetComponent<SpringJoint>().connectedBody = null;
                        //  Arm.GetComponent<SpringJoint>().damper = 7.9f;

                        Arm.GetComponent<Rigidbody>().mass = 1;
                        this.transform.GetComponentInChildren<StickToIngredient>().ColidedWithMoney = false;

                        HitChosenObject = false;
                        hitUnderArm.transform.GetComponent<MoneyBackAndForthOnConv>().Speed = 0.8f;


                    }
                }

                //  Arm.transform.GetComponent<Rigidbody>().AddForce(Arm.right * Horizantal, ForceMode.Impulse);
                //   SpringJointParent.connectedBody = null;
                //timeLeftBeforeSwing = 0;
            }





        }






        if (ProductDeliverd == true && this.transform.GetComponentInChildren<StickToIngredient>().ColidedWithMoney == false)
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
                hasReleventObjectUnder = false;
            }

            // ProductDeliverd = false;
        }


    }


}
