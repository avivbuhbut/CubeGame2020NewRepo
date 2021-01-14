using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShitandPressBecomeKinematic : MonoBehaviour
{

    Transform ArrowRight;
    Transform ArrowLeft;
    Vector3 ArrowRightZPos;
    Vector3 ArrowLeftZPos;
    bool colided;
    Transform ColidedConveyerTans;

    // Start is called before the first frame update
    void Start()
    {
        ArrowRight = this.transform.Find("ArrowRight");
        ArrowRightZPos.z = ArrowRight.position.z;

        ArrowLeft = this.transform.Find("ArrowLeft");
        ArrowLeftZPos.z = ArrowLeft.position.z;



    }

    // Update is called once per frame
    void Update()
    {
        
        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);                    ///Very Useful Code! - tells the object name when clicked by the mouse

        // Casts the ray and get the first game object hit
        Physics.Raycast(ray, out hit);



        if (Input.GetMouseButtonDown(0) && colided == false)
        {
            if (hit.transform.name == "BasicConveyorBelt(Clone)" || hit.transform.name == "BasicConveyorBelt"||
                hit.transform.name == " BasicConveyorBelt 2(Clone)" )
            {
                colided = false;
                // hit.transform.gameObject.AddComponent<Rigidbody>();
              
                this.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ |
                    RigidbodyConstraints.FreezeRotation;

            }
            else
                this.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        }
       
        if(colided == true)
        {
            ColidedConveyerTans.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            this.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }








    }

     void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name == "BasicConveyorBelt(Clone)" || collision.transform.name == "BasicConveyorBelt")
        {
            ColidedConveyerTans = collision.transform;
            ColidedConveyerTans.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            this.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            colided = true;
      
        }
    }


}




