using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToOtherConveyor : MonoBehaviour
{
    // Start is called before the first frame update
    float defaultRotation;
    Transform FirstColisionConveyor;

    void Start()
    {
        defaultRotation = this.transform.localRotation.x;
    }

    // Update is called once per frame
    void Update()
    {

   


    }
    int firstConveyor = 0;
    Transform FirstConeyorTrans;
    bool toTheRightOfConvy;
    bool toTheLeftOfConvy;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.name == "BasicConveyorBelt(Clone)" ||
            collision.gameObject.transform.name == "BasicConveyorBelt" )
        {



            firstConveyor++;
            if (firstConveyor == 1)
                FirstConeyorTrans = collision.transform;


            //stick conveyor togheter  - same hight 
            if (collision.transform.position.x < this.transform.position.x && toTheRightOfConvy == false)//to the left of the conveyer.
            {
                this.transform.position = new Vector3(collision.transform.position.x +6f, FirstConeyorTrans.transform.position.y,
                    collision.transform.position.z);

             //   this.transform.GetChild(1).position = new Vector3(collision.transform.GetChild(1).position.x,
             //       collision.transform.GetChild(1).position.y, collision.transform.GetChild(1).position.z);
              //    this.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                toTheLeftOfConvy = true;
                    toTheRightOfConvy = false;
            }


            
            if (collision.transform.position.x > this.transform.position.x&& toTheLeftOfConvy==false)//to the left of the conveyer.
            {
                this.transform.position = new Vector3(collision.transform.position.x -6f, FirstConeyorTrans.transform.position.y,
                 collision.transform.position.z);

              //  this.transform.GetChild(1).position = new Vector3(collision.transform.GetChild(0).position.x,
                //    collision.transform.GetChild(0).position.y, collision.transform.GetChild(0).position.z);
               //  this.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                toTheRightOfConvy = true;
                toTheLeftOfConvy = false;
            }

            //     collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, this.transform.position.y, collision.gameObject.transform.position.z);
            this.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            //  collision.gameObject.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
