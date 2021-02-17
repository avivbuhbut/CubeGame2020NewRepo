using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitConyorMove : MonoBehaviour
{
    // Start is called before the first frame update
    bool colidedWithConvyor;
    Transform StartPos;
    Transform EndPos;
    Transform StrachConveyor;
     Transform PlayerTrans;
     Transform ContainerTrans;
    bool DoneMovment;
    void Start()
    {
        PlayerTrans = GameObject.Find("Player").transform;
        ContainerTrans = GameObject.Find("Container").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (colidedWithConvyor && ContainerTrans.GetComponent<HitPlayerCreateLineAndConveyor>().EndCubeToTheLeftOfContainer&& DoneMovment==false)
        {
            this.transform.position = Vector3.MoveTowards(new Vector3(this.transform.position.x, StrachConveyor.position.y + 0.3f, this.transform.position.z), StartPos.position, 0.1f);

            this.transform.GetComponent<Rigidbody>().isKinematic = true;
        }

        if (colidedWithConvyor && ContainerTrans.GetComponent<HitPlayerCreateLineAndConveyor>().EndCubeToTheRightOfContainer && DoneMovment == false)
        {
            /*while on the conveyor move to the desired position*/
            if ((int)Vector3.Distance(new Vector3(this.transform.position.x, StrachConveyor.position.y + 0.3f, this.transform.position.z), new Vector3(EndPos.position.x + 3, EndPos.position.y, EndPos.position.z)) > 1 && DoneMovment == false)
            {
                this.transform.position = Vector3.MoveTowards(new Vector3(this.transform.position.x, StrachConveyor.position.y + 0.3f, this.transform.position.z), new Vector3(EndPos.position.x + 3, EndPos.position.y, EndPos.position.z), 0.1f);
                this.transform.GetComponent<Rigidbody>().isKinematic = true;
                
            }



            /*if reach the desired position turn on gravity*/
            if ((int)Vector3.Distance(new Vector3(this.transform.position.x, StrachConveyor.position.y + 0.3f, this.transform.position.z), new Vector3(EndPos.position.x + 3, EndPos.position.y, EndPos.position.z))<=1)
            {
                DoneMovment = true;
              this.transform.GetComponent<Rigidbody>().isKinematic = false;
               this.transform.GetComponent<Rigidbody>().useGravity = true;

               // this.transform.GetComponent<HitConyorMove>().gameObject.SetActive(false);
                
               //this.transform.GetComponent<Rigidbody>().AddRelativeForce(this.transform.forward * 5f);

            }
           
     

        }
    }

     void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name == "StrachConveyor 1(Clone)")
        {
            colidedWithConvyor = true;
            StrachConveyor = collision.transform;
            StartPos = collision.transform.Find("StartPos").transform;
            EndPos = collision.transform.Find("EndPos").transform;
        }


    }


     void OnCollisionExit(Collision collision)
    {

    }
}
