using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayerCreateLineAndConveyor : MonoBehaviour
{

     Transform PlayerTrans;
    public LineRenderer LineRenderer;
    bool ColidedWithPlayer;
    public Transform StarchConeyorTrans;
    GameObject ConveyorStach;
    int counter = 0;
    Vector3 centerPos;
   
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LineRenderer.material.color = Color.blue;
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
        }





    }


     void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name == "Player")
        {
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
