﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectircWallOnEnterElectricPlayer : MonoBehaviour
{

    public Material ElectricWallMat;
    public Transform DownArrowWall;
    public Material BlackColorArrow;
    bool WallIsElectrid;
    RaycastHit hit;
    Transform PlayerTrans;
    Material defaultWallMat;
    Material DeafultDownArrowMat;
   public Material ArrowActivateRedMat;
    public Transform TailCubeTrans;
    Color lerpedColor;
    Vector3 EndPos;
    Vector3 StartPosThisTrans;
    bool PlayerPressedOnArrowDown;
    // Start is called before the first frame update
    void Start()
    {
        EndPos = new Vector3(this.transform.position.x, this.transform.position.y - 8, this.transform.position.z);
        StartPosThisTrans = this.transform.position;

        defaultWallMat = this.transform.GetComponent<Renderer>().material;
        DeafultDownArrowMat = DownArrowWall.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        TailCubeTrans.GetComponent<Renderer>().material = this.transform.GetComponent<Renderer>().material;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);                    ///Very Useful Code! - tells the object name when clicked by the mouse

        // Casts the ray and get the first game object hit
        Physics.Raycast(ray, out hit);

        if (WallIsElectrid)
        {
            if (PlayerTrans.transform.GetComponent<CheckIfRainHitPlayer>().PlayerElectricFull == false)
            {
                this.transform.GetComponent<Renderer>().material = defaultWallMat;
                DownArrowWall.GetComponent<Renderer>().material = DeafultDownArrowMat;


                //this.transform.position = Vector3.MoveTowards(this.transform.position,StartPosThisTrans, )

                /*activate animation up*/
                PlayerPressedOnArrowDown = false;
                WallIsElectrid = false;


            }


            if(hit.collider.gameObject == DownArrowWall.gameObject && Input.GetMouseButtonDown(0))
            {
                // DownArrowWall.GetComponent<Renderer>().material = ArrowActivateRedMat;
                PlayerPressedOnArrowDown = true;
        

                /*activate animation down*/
            }



            if (PlayerPressedOnArrowDown)
            {

                if ((int)Vector3.Distance(this.transform.position, EndPos) == 0)
                {
                    this.transform.GetComponent<Renderer>().material = defaultWallMat;
                    DownArrowWall.GetComponent<Renderer>().material = DeafultDownArrowMat;
                    DownArrowWall.gameObject.SetActive(false);
                }
                else
                {

                    lerpedColor = Color.Lerp(Color.black, ArrowActivateRedMat.color, Mathf.PingPong(Time.time, 1));
                    DownArrowWall.transform.GetComponent<Renderer>().material.color = lerpedColor;
                    Debug.Log("Distance: " + (int)Vector3.Distance(this.transform.position, EndPos));
                    if ((int)Vector3.Distance(this.transform.position, EndPos) > 0)
                    {
                        this.transform.position = Vector3.MoveTowards(this.transform.position, EndPos, 2 * Time.deltaTime);

                    }

                }
             
            }
        }

    }



     void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name == "Player")
        {
            PlayerTrans = collision.transform;
            if (collision.transform.GetComponent<CheckIfRainHitPlayer>().PlayerElectricFull)
            {
                WallIsElectrid = true;
                this.transform.GetComponent<Renderer>().material = ElectricWallMat;
                DownArrowWall.GetComponent<Renderer>().material = BlackColorArrow;

            }
        }
    }
}
