using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBackAndForthOnConv : MonoBehaviour
{

    Vector3 StartPos;
    Vector3 EndPos;
    bool ReachStartPos;
    bool ColidedAnotherMoneyonConv;
    bool ColidedStrachConv;
    Transform AnotherMoneyOnConvTrans;
    public float Speed;
    FlourBackAndForthStrachConv flourBackANdForth;
    // Start is called before the first frame update
    RaycastHit MoneyRayRight;
    Transform CubeChildMoney;
    void Start()
    {
        CubeChildMoney = this.transform.Find("Cube").transform;
        Speed = 0.8f;
    }

    // Update is called once per frame
    void Update()
    {



        if (ColidedStrachConv)
            if (ColidedAnotherMoneyonConv)
            {
                Physics.IgnoreCollision(CubeChildMoney.GetComponent<BoxCollider>(), AnotherMoneyOnConvTrans.GetComponent<BoxCollider>());
                if (Physics.Raycast(CubeChildMoney.position, CubeChildMoney.TransformDirection(Vector3.right), out MoneyRayRight)) {
                    Physics.IgnoreCollision(CubeChildMoney.GetComponentInChildren<BoxCollider>(), MoneyRayRight.transform.GetComponent<BoxCollider>());
                    Debug.Log(MoneyRayRight.transform.name + "to the right ");

                }

            }
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

        if (collision.transform.tag == "Money")
        {
            ColidedAnotherMoneyonConv = true;
            AnotherMoneyOnConvTrans = collision.transform;
        }


    }





}
