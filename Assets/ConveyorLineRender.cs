using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorLineRender : MonoBehaviour
{


    Vector3 StartPos;
    Vector3 EndPos;
    public LineRenderer LineRender;


  Transform PlayerTrans;
    bool hitConeyorStart;
    bool hitConvyorEnd;
    Transform ConveyorStartTrans;
    Transform ConveyorEndTrans;
    public Transform StarchConeyorTrans;
    Transform EndConvTrans;


    Vector3 centerPos;
    GameObject ConveyorStach;
    // Start is called before the first frame update
    int counter = 0;
    float angel = 1;

    bool HitPlayer;

    void Start()
    {
        LineRender.startColor = Color.black;
        LineRender.endColor = Color.black;
        LineRender.startWidth = 1f;
        LineRender.endWidth = 1f;
        LineRender.positionCount = 2;
        LineRender.useWorldSpace = true;
    }

    // Update is called once per frame

    void Update()
    {

        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);                    ///Very Useful Code! - tells the object name when clicked by the mouse

        // Casts the ray and get the first game object hit
        Physics.Raycast(ray, out hit);

        //For creating line renderer object

    


        //For drawing line in the world space, provide the x,y,z values
        //   LineRender.SetPosition(0, new Vector3(6, 0.79f, -7.35f)); //x,y and z posit
        // set the position
        if (HitPlayer)
        {

            Debug.Log("HitPlayer");
            
            LineRender.SetPosition(0, this.transform.position);
            LineRender.SetPosition(1, PlayerTrans.transform.position);
        }

        if (PlayerTrans.transform.GetComponent<getConveyorEnd>().HitConveyorEnd)
        {
            LineRender.SetPosition(1, PlayerTrans.transform.GetComponent<getConveyorEnd>().ConveyorEnd.position);
        }
        EndConvTrans = PlayerTrans.transform.GetComponent<getConveyorEnd>().ConveyorEnd;



       // float _Distance = Vector3.Distance(ConveyorStartTrans.position, EndConvTrans.position);
            if (counter == 0)
            {
            Debug.Log("Problem counter:" + counter);
            ConveyorStach = Instantiate(StarchConeyorTrans.gameObject, new Vector3(this.transform.position.x + 10, this.transform.position.y, 3), Quaternion.identity);
 
                //ConveyorStach.transform.Rotate(90.0f, 90.0f, 90.0f, Space.Self); ;
                counter++;

                //scaling with the object

            }

            

            ConveyorStach.transform.Find("StartPos").position = new Vector3(this.transform.position.x, this.transform.position.y + 1.5f, this.transform.position.z);
            ConveyorStach.transform.Find("EndPos").position = new Vector3(EndConvTrans.position.x,
              EndConvTrans.position.y + 1.5f, EndConvTrans.position.z);
            //try ConveyorStach rotation.z  = ConveyorEndTrans.position.y *5



            float scaleX = Vector3.Distance(new Vector3(this.transform.position.x + 1, 0, 0), new Vector3(EndConvTrans.position.x + 1, 0, 0));

            ConveyorStach.transform.position = centerPos;


            centerPos = new Vector3(this.transform.position.x + EndConvTrans.position.x, this.transform.position.y + 0.9f +
       EndConvTrans.position.y + 0.9f) / 2;

            Physics.IgnoreCollision(ConveyorStach.GetComponent<BoxCollider>(), PlayerTrans.GetComponent<BoxCollider>());

            centerPos.z = -7.2f;
            ConveyorStach.transform.localScale = new Vector3(scaleX, 0.3f, 3);

            //     ConveyorStach.transform.localRotation = Quaternion.Euler(ConveyorStach.transform.position.x, ConveyorStach.transform.position.y, -ConveyorEndTrans.transform.position.y * 10) ;

            //  Vector3 directionToFace = ConveyorEndTrans.position - ConveyorStach.transform.position;



            // if(ConveyorEndTrans.transform.position.y>1)
            //     if (scaleX > 0.5f)
            //   {
            //(angel < 10 ? angel++ : angel=1)
            //      ConveyorStach.transform.localRotation = Quaternion.Euler(ConveyorStach.transform.position.x, ConveyorStach.transform.position.y, -ConveyorEndTrans.transform.position.y * 6) ;
            //     //      centerPos = new Vector3(ConveyorStartTrans.position.x-1 + ConveyorEndTrans.transform.position.x, ConveyorStartTrans.position.y + 2 +
            //    ConveyorEndTrans.transform.position.y + 2) / 2f;

            //      centerPos.z = -6.3f;


            //  }
            //  else




            //else
            //   ConveyorStach.transform.localRotation = Quaternion.Euler(ConveyorStach.transform.position.x, ConveyorStach.transform.position.y, ConveyorStach.transform.position.z); 

            //   float scaleY = Vector3.Distance(new Vector3(0, ConveyorStartTrans.position.y, 0), new Vector3(0, ConveyorEndTrans.transform.position.y, 0));

            //Vector3 eulerRotation = new Vector3(LineRender.transform.rotation.eulerAngles.x, LineRender.transform.rotation.eulerAngles.y, LineRender.transform.rotation.eulerAngles.z);

            // Vector3 targetPostition = new Vector3(ConveyorEndTrans.position.x,
            //                         ConveyorEndTrans.transform.position.y,
            //                          ConveyorEndTrans.position.z);
            // ConveyorStach.transform.LookAt(targetPostition);

            //ConveyorStach.transform.LookAt(ConveyorEndTrans);



            //ConveyorStach.transform.eulerAngles = new Vector3(0,180, 0); 

            //      ConveyorStach.transform.LookAt(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z)) ;
            //ConveyorStach.transform.localRotation = Quaternion.Euler(5, 0, 5);
            //ConveyorStach.transform.LookAt(ConveyorEndTrans);
            //  StartPosSCTrans.transform.LookAt(ConveyorStartTrans);

            // ConveyorStach.transform.localRotation = Quaternion.Euler(LineRender.transform.rotation.eulerAngles.x, LineRender.transform.rotation.eulerAngles.y, LineRender.transform.rotation.eulerAngles.z); // try to play with that a bit




            //need to be a combination of these two


            //  ConveyorStach.transform.localScale = new Vector3(Mathf.Abs(ConveyorStartTrans.position.x - ConveyorEndTrans.position.x), 0.1f, LineRender.startWidth);
            //    ConveyorStach.transform.position = new Vector3((ConveyorStartTrans.position.x + ConveyorEndTrans.position.x), (ConveyorStartTrans.position.y + ConveyorEndTrans.position.y) + 2, LineRender.GetPosition(1).z);

            // Debug.Log("ConveyorStach roattion.y: " + ConveyorStach.transform.rotation.eulerAngles.z);
            //   Debug.Log("LINE render roattion.y: " + LineRender.transform.rotation.eulerAngles.z);
        

    }


    void OnCollisionStay(Collision collision)
    {

        Debug.Log(collision.transform.name);

       if(collision.transform.name == "Player")
        {
            PlayerTrans = collision.transform;
            HitPlayer = true;
        }
    }


}
