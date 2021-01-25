using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBackAndForth : MonoBehaviour
{
    Vector3 StartPos;
    Vector3 EndPos;
    bool goToEndPos;
    bool goToStartPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

     



        StartPos = this.transform.Find("StartPos").position;
        EndPos = this.transform.Find("EndPos").position;
    }

    bool ReachStartPos;
    void OnCollisionStay(Collision collision)
    {
        if (collision.transform.name == "Flour"|| collision.transform.name == "Flour 1(Clone)")
        {



            //     collision.transform.position = Vector3.MoveTowards(collision.transform.position
            //, StartPos, 1.2f * Time.deltaTime);
            if (ReachStartPos == false)
            {
                collision.transform.position = Vector3.MoveTowards(collision.transform.position, StartPos, 0.8f * Time.deltaTime);
               Debug.Log((int)Vector3.Distance(collision.transform.position, StartPos));
                if ((int)Vector3.Distance(collision.transform.position, StartPos) == 0)
                {
                    Debug.Log("ReachStartPos is not true");
                    ReachStartPos = true;

                }
            }


         
               
            if (ReachStartPos)
            {
                collision.transform.position = Vector3.MoveTowards(collision.transform.position, EndPos, 0.8f * Time.deltaTime);

                if ((int)Vector3.Distance(collision.transform.position, EndPos) == 0)
                {
                    Debug.Log("ReachStartPos is not true");
                    ReachStartPos = false;

                }
            }


        }
    }


}
