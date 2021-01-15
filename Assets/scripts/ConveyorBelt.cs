using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public Transform EndPoint;
    public Transform EndPointLeft;
    public int currentSpeed;
    public int maxSpeed;
     public Transform LeftArrow;
     public Transform RightArrow;
    public Transform PauseTrans;

    Color LeftArrowOriginalColor;
    Color RightArrowOriginalColor;

    bool collided;
    bool boolRightArrow;
    bool boolLeftArrow;
    Transform ColidedTrans;
    string ColiisionOriginalTag;
    public List<GameObject> TouchingObjects;
    int i = 0;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {

    
        TouchingObjects = new List<GameObject>();
        LeftArrow = this.transform.Find("ArrowLeft");
        RightArrow = this.transform.Find("ArrowRight");
        PauseTrans = this.transform.Find("Pause");
        LeftArrowOriginalColor = LeftArrow.transform.GetComponent<Renderer>().material.color;
        RightArrowOriginalColor = RightArrow.transform.GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    //   foreach(var go in bombList)
    // {
     //    Debug.Log(go.name);
   //  }



        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);                    ///Very Useful Code! - tells the object name when clicked by the mouse

        // Casts the ray and get the first game object hit
        Physics.Raycast(ray, out hit);


        if (Input.GetMouseButtonDown(0))
        {


            if (hit.collider.gameObject == PauseTrans.gameObject)
            {
                LeftArrow.transform.GetComponent<Renderer>().material.color = LeftArrowOriginalColor;
                RightArrow.transform.GetComponent<Renderer>().material.color = RightArrowOriginalColor;
                boolRightArrow = false;
                boolLeftArrow = false;

            }

                if (hit.collider.gameObject == RightArrow.gameObject)
            {
                RightArrow.transform.GetComponent<Renderer>().material.color = Color.red;
                LeftArrow.transform.GetComponent<Renderer>().material.color = LeftArrowOriginalColor;
                boolRightArrow = true;
                boolLeftArrow = false;
            }


            if (hit.collider.gameObject == LeftArrow.gameObject)
            {

                LeftArrow.transform.GetComponent<Renderer>().material.color = Color.red;
                RightArrow.transform.GetComponent<Renderer>().material.color = RightArrowOriginalColor;
                boolLeftArrow = true;
                boolRightArrow = false;
            }
        }



        /*

            if (collided && boolRightArrow)
            {
                RightArrow.transform.GetComponent<Renderer>().material.color = Color.red;
                LeftArrow.transform.GetComponent<Renderer>().material.color = LeftArrowOriginalColor;

                boolLeftArrow = false;
                ColidedTrans.transform.position = Vector3.MoveTowards(ColidedTrans.transform.position
        , EndPoint.transform.position, currentSpeed * Time.deltaTime);
            }


            if (collided && boolLeftArrow)
            {
                RightArrow.transform.GetComponent<Renderer>().material.color = RightArrowOriginalColor;
                LeftArrow.transform.GetComponent<Renderer>().material.color = Color.red;

                boolRightArrow = false;
                ColidedTrans.transform.position = Vector3.MoveTowards(ColidedTrans.transform.position
        , EndPointLeft.transform.position, currentSpeed * Time.deltaTime);
            }
        */

    }

    /*
     void OnCollisionEnter(Collision collision)
    {
     
        Debug.Log(collision.transform.name);
        if (collision.transform.tag== "Floor" || collision.transform.tag == "Untagged")
            collided = false;

        else
        {
            TouchingObjects.Add(collision.gameObject);
            ColiisionOriginalTag = collision.transform.tag;
            collision.transform.tag = "Flour";
            ColidedTrans = collision.transform;
            collided = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        TouchingObjects.Remove(collision.gameObject);
        collided = false;
        collision.transform.tag = ColiisionOriginalTag;
    }
    */

     void OnTriggerEnter(Collider other)
    {
        if (other.transform.name != "BasicConveyorBelt" ||
        other.transform.name != "BasicConveyorBelt(Clone)")
        {
            other.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        }
    }

     int   switchCounter = 0;
    bool RightDone;
    bool somthingHit;
    void OnCollisionStay(Collision collision)
    {

        /*General Case*/ //collision.transform.name != "BasicConveyorBelt(Clone)"
        if (collision.transform.tag != "Floor" && collision.transform.name != "Flour"&& somthingHit==true)
        {
          
            if (boolRightArrow)
            {


                collision.transform.position = Vector3.MoveTowards(collision.transform.position
            , EndPoint.transform.position, currentSpeed * Time.deltaTime);


            }



            if (boolLeftArrow)
            {


                collision.transform.position = Vector3.MoveTowards(collision.transform.position
            , EndPointLeft.transform.position, currentSpeed * Time.deltaTime);

            }

        }


        /*Case Flour*/
        if (collision.transform.name == "Flour") {
   
            Debug.Log(switchCounter);
            if (OpenManuOnPress.bolFlourGoesRight)
            {
            collision.transform.position = Vector3.MoveTowards(collision.transform.position
                , EndPoint.transform.position, currentSpeed * Time.deltaTime);

            }


            if (OpenManuOnPress.bolFlourGoesLeft)
            {
                collision.transform.position = Vector3.MoveTowards(collision.transform.position
           , EndPointLeft.transform.position, currentSpeed * Time.deltaTime);
            }

            if (OpenManuOnPress.bolFlourGoesSwitch)
            {
              
                if(switchCounter ==1 )
                {
                    collision.transform.position = Vector3.MoveTowards(collision.transform.position
                   , EndPoint.transform.position, currentSpeed * Time.deltaTime);

              
                }
                if (switchCounter == 2 )
                {
                    collision.transform.position = Vector3.MoveTowards(collision.transform.position
                    , EndPointLeft.transform.position, currentSpeed * Time.deltaTime);
                   

                   // switchCounter = 0;


                }
  
            }

                if (OpenManuOnPress.bolFlourGoesRight == false && OpenManuOnPress.bolFlourGoesLeft == false && OpenManuOnPress.bolFlourGoesSwitch ==false)
            {
           
                if (boolRightArrow)
                {


                    collision.transform.position = Vector3.MoveTowards(collision.transform.position
                , EndPoint.transform.position, currentSpeed * Time.deltaTime);


                }



                if (boolLeftArrow)
                {


                    collision.transform.position = Vector3.MoveTowards(collision.transform.position
                , EndPointLeft.transform.position, currentSpeed * Time.deltaTime);

                }
            }

        }

    
        
    }


     void OnCollisionEnter(Collision collision)
    {
       if(collision.transform.name=="Flour")
            switchCounter++;

        if (collision.transform.name == "BasicConveyorBelt(Clone)")
            somthingHit = false;
        else
        somthingHit = true;


      


    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.transform.name == "Flour"&& switchCounter==2)
        {
            switchCounter = 0;
        }


      


    }




}
