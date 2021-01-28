using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAround : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    Vector3 mousepos;
    // Update is called once per frame
    void Update()
    {

      

            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);                    ///Very Useful Code! - tells the object name when clicked by the mouse

            // Casts the ray and get the first game object hit
            Physics.Raycast(ray, out hit);

            if (hit.collider.name == "RoboticArm")
            {
                mousepos = Input.mousePosition;
                mousepos.z = 14.5f;

                mousepos = Camera.main.ScreenToWorldPoint(mousepos);
                this.transform.position = mousepos;
            this.transform.GetComponentInChildren<Transform>().position = mousepos;
              //  hit.transform.GetComponent<Rigidbody>().isKinematic = false;
                //hit.transform.GetComponentInChildren<Rigidbody>().isKinematic = false;

            }
           // else if(hit.transform.name != "RoboticArm")
          // {
             //   hit.transform.GetComponentInChildren<Rigidbody>().isKinematic = false;
             //   hit.transform.GetComponent<Rigidbody>().isKinematic = true;
          //  }




        
     

    }
}
