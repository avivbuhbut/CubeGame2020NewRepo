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
    Material DefaultLineMat;
    void Start()
    {
        LineRender.startColor = Color.black;
        LineRender.endColor = Color.black;
        LineRender.startWidth = 1f;
        LineRender.endWidth = 1f;
        LineRender.positionCount = 2;
        LineRender.useWorldSpace = true;
        DefaultLineMat = LineRender.GetComponent<Renderer>().material;
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
        if(PlayerTrans!=null)
        if (PlayerTrans.transform.GetComponent<getConveyorEnd>().HitConveyorEnd)
        {
            LineRender.SetPosition(1, PlayerTrans.transform.GetComponent<getConveyorEnd>().ConveyorEnd.position);
        }
       // if(EndConvTrans!=null)
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
        ConveyorStach.transform.Find("EndPos").position = new Vector3(EndConvTrans.position.x, EndConvTrans.position.y + 1.5f, EndConvTrans.position.z);




        //try ConveyorStach rotation.z  = ConveyorEndTrans.position.y *5



        float scaleX = Vector3.Distance(new Vector3(this.transform.position.x + 1, 0, 0), new Vector3(EndConvTrans.position.x + 1, 0, 0));

            ConveyorStach.transform.position = centerPos;


            centerPos = new Vector3(this.transform.position.x + EndConvTrans.position.x, this.transform.position.y + 0.9f +
       EndConvTrans.position.y + 0.9f) / 2;

            Physics.IgnoreCollision(ConveyorStach.GetComponent<BoxCollider>(), PlayerTrans.GetComponent<BoxCollider>());

            centerPos.z = -7.2f;
            ConveyorStach.transform.localScale = new Vector3(scaleX, 0.3f, 3);

        if (PlayerTrans.GetComponent<CheckIfRainHitPlayer>().PlayerElectricFull == false)
        {
        
                HitPlayer = false;
            LineRender.GetComponent<LineRenderer>().material = DefaultLineMat;
        }
        

    }


    void OnCollisionStay(Collision collision)
    {

        Debug.Log(collision.transform.name);

        if (collision.transform.name == "Player" && collision.transform.GetComponent<CheckIfRainHitPlayer>().PlayerElectricFull)
        {
            PlayerTrans = collision.transform;
            HitPlayer = true;
            LineRender.GetComponent<LineRenderer>().material = collision.transform.GetComponent<Renderer>().material;
        }
  

    }

    



}
