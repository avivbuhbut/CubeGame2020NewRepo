using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineMovmentControl : MonoBehaviour
{

    public Transform LeftArrowRoboticArm;
   public Transform RightArrowRoboticArm;
    Color RightArrowOriginalColor;
    Color LeftArrowOriginalColor;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        RightArrowOriginalColor = RightArrowRoboticArm.transform.GetComponent<Renderer>().material.color;
         LeftArrowOriginalColor = LeftArrowRoboticArm.transform.GetComponent<Renderer>().material.color;
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
    
            }

            if (hit.collider.gameObject == RightArrowRoboticArm.gameObject)
            {
                RightArrowRoboticArm.transform.GetComponent<Renderer>().material.color = Color.red;
               LeftArrowRoboticArm.transform.GetComponent<Renderer>().material.color = RightArrowOriginalColor;

            }

        }
        }
    }
