using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreate : MonoBehaviour
{

    Vector3 StartPos;
    Vector3 EndPos;
    public LineRenderer LineRender;
    public Transform FlourPos;
    public Transform PlayerPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    int counter = 1;
    void Update()
    {

        RaycastHit hit;
   
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);                    ///Very Useful Code! - tells the object name when clicked by the mouse

            // Casts the ray and get the first game object hit
            Physics.Raycast(ray, out hit);
        /*
            if (Input.GetMouseButton(0)) {
                //   if (hit.transform.name == "Drawn Mesh") { }

                if (counter == 1)
                {
                    StartPos = hit.transform.position;
                    counter++;
                }

                if (counter == 2)
                {
                    EndPos = hit.transform.position;
                    counter = 1;
                }

                    }
              
    */

            //For creating line renderer object

            LineRender.startColor = Color.black;
        LineRender.endColor = Color.black;
        LineRender.startWidth = 3f;
        LineRender.endWidth = 3f;
        LineRender.positionCount = 2;
        LineRender.useWorldSpace = true;

        //For drawing line in the world space, provide the x,y,z values
     //   LineRender.SetPosition(0, new Vector3(6, 0.79f, -7.35f)); //x,y and z posit
                                                                  // set the position
        LineRender.SetPosition(0, FlourPos.transform.position);
        LineRender.SetPosition(1, PlayerPos.transform.position);
    }
}
