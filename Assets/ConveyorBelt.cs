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

    Color LeftArrowOriginalColor;
    Color RightArrowOriginalColor;

    bool collided;
    bool boolRightArrow;
    bool boolLeftArrow;
    Transform ColidedTrans;

    // Start is called before the first frame update
    void Start()
    {
        LeftArrowOriginalColor = LeftArrow.transform.GetComponent<Renderer>().material.color;
        RightArrowOriginalColor = RightArrow.transform.GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void FixedUpdate()
    {




        RaycastHit hit;
    
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);                    ///Very Useful Code! - tells the object name when clicked by the mouse

            // Casts the ray and get the first game object hit
            Physics.Raycast(ray, out hit);
  

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(hit.transform.name);
            if (hit.transform.name == "ArrowRight")
            {
               RightArrow.transform.GetComponent<Renderer>().material.color = Color.red;
                LeftArrow.transform.GetComponent<Renderer>().material.color = LeftArrowOriginalColor;
                boolRightArrow = true;
                boolLeftArrow = false;
            }


            if (hit.transform.name == "ArrowLeft")
            {
                LeftArrow.transform.GetComponent<Renderer>().material.color = Color.red;
                RightArrow.transform.GetComponent<Renderer>().material.color = RightArrowOriginalColor;
                boolLeftArrow = true;
                boolRightArrow = false;
            }
        }






        if (collided&& boolRightArrow)
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
    }


     void OnCollisionEnter(Collision collision)
    {
        ColidedTrans = collision.transform;
        collided = true;

    }

    void OnCollisionExit(Collision collision)
    {
        collided = false;

    }

}
