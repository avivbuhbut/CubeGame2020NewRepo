using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitCreateConveyor : MonoBehaviour
{


    public Transform StartConeyorTrans;
        public Transform EndConeyorTrans;
    Vector3 centerPos;
    public Transform StarchConeyorTrans;
    GameObject ConveyorStach;
    int counter = 0;
    public SpringJoint SpringJoint;
    bool ColidedWithStartCnvy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

     



        if (ColidedWithStartCnvy)
        {
            if (counter == 0)
            {

                ConveyorStach = Instantiate(StarchConeyorTrans.gameObject, new Vector3(StartConeyorTrans.position.x - 5, StartConeyorTrans.position.y, 3), Quaternion.identity);

                //ConveyorStach.transform.Rotate(90.0f, 90.0f, 90.0f, Space.Self); ;
                counter++;

                //scaling with the object

                centerPos = new Vector3(StartConeyorTrans.position.x + EndConeyorTrans.transform.position.x, StartConeyorTrans.position.y + 2 +
             EndConeyorTrans.transform.position.y + 2) / 2f;
            }



            centerPos.z = -6.3f;

            float scaleX = Vector3.Distance(new Vector3(StartConeyorTrans.position.x, 0, 0), new Vector3(EndConeyorTrans.transform.position.x, 0, 0));

            ConveyorStach.transform.position = centerPos;


            ConveyorStach.transform.localScale = new Vector3(scaleX, 0.3f, 1);
        }


    }


     void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name == "ConeyorBlockStart")
        {
            ColidedWithStartCnvy = true;
        }
    }
}
