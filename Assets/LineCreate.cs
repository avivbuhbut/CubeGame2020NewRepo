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
    bool hitConeyorStart;
    bool hitConvyorEnd;
    Transform ConveyorStartTrans;
    Transform ConveyorEndTrans;
    public Transform StarchConeyorTrans;
    public Transform StartPosSCTrans;
    public Transform EndPosSCTrans;
    Vector3 centerPos;
    GameObject ConveyorStach;
    // Start is called before the first frame update
    int counter = 0;
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {
     
        RaycastHit hit;
   
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);                    ///Very Useful Code! - tells the object name when clicked by the mouse

            // Casts the ray and get the first game object hit
            Physics.Raycast(ray, out hit);

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
        if (hitConeyorStart)
        {
            LineRender.SetPosition(0, ConveyorStartTrans.transform.position);
            LineRender.SetPosition(1, PlayerPos.transform.position);
        }

        if (hitConvyorEnd)
        {
            LineRender.SetPosition(1, ConveyorEndTrans.transform.position);
            // LineRender.SetPosition(1)

            float _Distance = Vector3.Distance(ConveyorStartTrans.position, ConveyorEndTrans.position);
            if (counter == 0)
            {

              ConveyorStach = Instantiate(StarchConeyorTrans.gameObject, new Vector3(ConveyorStartTrans.position.x - 5, ConveyorStartTrans.position.y, 3), Quaternion.identity);

                //ConveyorStach.transform.Rotate(90.0f, 90.0f, 90.0f, Space.Self); ;
                counter++;
        
                //scaling with the object

            }
            centerPos = new Vector3(ConveyorStartTrans.position.x + ConveyorEndTrans.transform.position.x, ConveyorStartTrans.position.y + 3 +
  ConveyorEndTrans.transform.position.y + 3) / 2f;

            centerPos.z = -6.3f;
            //try ConveyorStach rotation.z  = ConveyorEndTrans.position.y *5



            float scaleX = Vector3.Distance(new Vector3(ConveyorStartTrans.position.x, 0, 0), new Vector3(ConveyorEndTrans.transform.position.x, 0, 0));

            ConveyorStach.transform.position = centerPos;
            
           
            ConveyorStach.transform.localScale = new Vector3(scaleX, 0.3f, 1);

            Vector3 directionToFace = ConveyorEndTrans.position - ConveyorStach.transform.position;

            ConveyorStach.transform.rotation = Quaternion.LookRotation(directionToFace);

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

    }


     void OnCollisionStay(Collision collision)
    {
        if(collision.transform.name == "ConeyorBlockStart")
        {
            ConveyorStartTrans = collision.transform;
            hitConeyorStart = true;

        }


        if(collision.transform.name == "ConeyorBlockEnd")
        {
            ConveyorEndTrans = collision.transform;
            hitConvyorEnd = true;

        }
    }


}
