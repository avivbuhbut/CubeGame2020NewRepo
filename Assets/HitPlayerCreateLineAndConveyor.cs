﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayerCreateLineAndConveyor : MonoBehaviour
{

     Transform PlayerTrans;
    public LineRenderer LineRenderer;
    public bool ColidedWithPlayer;
    public Transform StarchConeyorTrans;
   public  GameObject ConveyorStach;
    int counter = 0;
    public Material ConvyorColorMat;
    public bool EndCubeToTheLeftOfContainer;
    public bool EndCubeToTheRightOfContainer;
    Vector3 centerPos;
   
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     //   LeftArrowRoboticArm.transform.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 1));
        LineRenderer.material.color = Color.Lerp(Color.white, Color.blue, Mathf.PingPong(Time.time, 1));
        if (ColidedWithPlayer)
        {
          //  if (PlayerTrans.transform.position.x < this.transform.position.x)
            LineRenderer.SetPosition(0, new Vector3(this.transform.position.x, PlayerTrans.position.y, PlayerTrans.transform.position.z));
            LineRenderer.SetPosition(1, PlayerTrans.position);
        }
        if(PlayerTrans!=null)
        if (PlayerTrans.GetComponent<HitEndCube>().PlayerHitEndCube)
        {
            ColidedWithPlayer = false;
            LineRenderer.SetPosition(1, PlayerTrans.GetComponent<HitEndCube>().HitCubeTrans.position);
            CreateConvyor();

                if (PlayerTrans.GetComponent<HitEndCube>().HitCubeTrans.position.x < this.transform.position.x)
                {
                    EndCubeToTheLeftOfContainer = true;
                    EndCubeToTheRightOfContainer = false;
                }

                if (PlayerTrans.GetComponent<HitEndCube>().HitCubeTrans.position.x > this.transform.position.x)
                {
                    EndCubeToTheLeftOfContainer = false;
                    EndCubeToTheRightOfContainer = true;
                }


            }





    }


     void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name == "Player")
        {
            
            counter = 0;
            LineRenderer.enabled = true;
            ColidedWithPlayer = true;
            PlayerTrans = collision.transform;
        }


    }


    void CreateConvyor()
    {
        
        float _Distance = Vector3.Distance(this.transform.position, PlayerTrans.GetComponent<HitEndCube>().HitCubeTrans.position);
        if (counter == 0)
        {

            ConveyorStach = Instantiate(StarchConeyorTrans.gameObject, new Vector3(this.transform.position.x, this.transform.position.y, 3), Quaternion.identity);
            ConveyorStach.GetComponent<Renderer>().material.color= ConvyorColorMat.color;
              //ConveyorStach.transform.Rotate(90.0f, 90.0f, 90.0f, Space.Self); ;
              counter++;

            //scaling with the object

        }



        ConveyorStach.transform.Find("StartPos").position = new Vector3(this.transform.position.x, this.transform.position.y + 1f, PlayerTrans.transform.position.z);
        ConveyorStach.transform.Find("EndPos").position = new Vector3(PlayerTrans.GetComponent<HitEndCube>().HitCubeTrans.position.x, PlayerTrans.GetComponent<HitEndCube>().HitCubeTrans.position.y + 3f, PlayerTrans.GetComponent<HitEndCube>().HitCubeTrans.position.z);
        //try ConveyorStach rotation.z  = ConveyorEndTrans.position.y *5



        float scaleX = Vector3.Distance(new Vector3(this.transform.position.x + 1, 0, 0), new Vector3(PlayerTrans.GetComponent<HitEndCube>().HitCubeTrans.position.x + 1, 0, 0));

        ConveyorStach.transform.position = centerPos;


        centerPos = new Vector3(this.transform.position.x + PlayerTrans.GetComponent<HitEndCube>().HitCubeTrans.position.x, this.transform.position.y  +
  PlayerTrans.GetComponent<HitEndCube>().HitCubeTrans.position.y ) / 2;

        Physics.IgnoreCollision(ConveyorStach.GetComponent<BoxCollider>(), PlayerTrans.GetComponent<BoxCollider>());

        centerPos.z = -7.2f;
        ConveyorStach.transform.localScale = new Vector3(scaleX, 0.3f, 3);
    }
}
