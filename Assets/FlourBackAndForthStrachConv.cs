using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlourBackAndForthStrachConv : MonoBehaviour
{
    Vector3 StartPos;
    Vector3 EndPos;
    bool ReachStartPos;
    bool ColidedAnotherFlouronConv;
    bool ColidedStrachConv;
   public Transform AnotherFlourOnConvTrans;
     public  float Speed;
    // Start is called before the first frame update
    void Start()
    {
        Speed = 0.8f;
    }

    // Update is called once per frame
    void Update()
    {
        if(ColidedStrachConv)
        if(ColidedAnotherFlouronConv)
            Physics.IgnoreCollision(this.transform.GetComponent<BoxCollider>(), AnotherFlourOnConvTrans.GetComponent<BoxCollider>());
        }
    

    void OnCollisionStay(Collision collision)
    {

        if (collision.transform.name == "StrachConveyor 1(Clone)")
        {
            ColidedStrachConv = true;

               StartPos = collision.transform.Find("StartPos").position;
            EndPos = collision.transform.Find("EndPos").position;

            //Physics.IgnoreCollision(collision.transform.GetComponent<BoxCollider>(), collision.transform.GetComponent<BoxCollider>());
       



                //     collision.transform.position = Vector3.MoveTowards(collision.transform.position
                //, StartPos, 1.2f * Time.deltaTime);
                if (ReachStartPos == false)
                {
                this.transform.position = Vector3.MoveTowards(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z),
                    new Vector3(StartPos.x, this.transform.position.y, this.transform.position.z), Speed * Time.deltaTime);


                    Debug.Log((int)Vector3.Distance(this.transform.position, StartPos));



                    if ((int)Vector3.Distance(this.transform.position, StartPos) == 0)
                    {
                        Debug.Log("ReachStartPos is not true");
                        ReachStartPos = true;

                    }
                }




                if (ReachStartPos)
                {
                this.transform.position = Vector3.MoveTowards(this.transform.position, EndPos, Speed * Time.deltaTime);

               
                    if ((int)Vector3.Distance(this.transform.position, EndPos) == 0)
                    {
                        Debug.Log("ReachStartPos is not true");
                        ReachStartPos = false;

                    }
                }


            }

        if (collision.transform.name == "Flour" || collision.transform.name == "Flour 1(Clone)")
        {
            ColidedAnotherFlouronConv = true;
            AnotherFlourOnConvTrans = collision.transform;
        }


    }


 
}
