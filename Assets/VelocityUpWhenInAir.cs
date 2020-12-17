using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class VelocityUpWhenInAir : MonoBehaviour
{

    public Material PlasmaMaterial;
    public Material PlasmaMaterial1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {


   


            /* indeication for the plyer that sprint is ready**/
            if (this.transform.GetComponent<Rigidbody>().velocity.magnitude > 18)
        {
            Vector4 colorvec = new Vector4(38.9371452f, 0.611578226f, 0, 1);
            //this.transform.GetComponent<Renderer>().material.DOColor(colorvec, 2f);
            this.transform.GetComponent<Renderer>().material.color = Color.Lerp(this.transform.GetComponent<Renderer>().material.color, colorvec, Mathf.PingPong(Time.deltaTime, 1));

        }

        if (this.transform.GetComponent<Rigidbody>().velocity.magnitude > 14)
        {
           
            //this.transform.GetComponent<Renderer>().material.DOColor(colorvec, 2f);
            this.transform.GetComponent<Renderer>().material.color = Color.Lerp(this.transform.GetComponent<Renderer>().material.color, PlasmaMaterial1.color, Mathf.PingPong(Time.deltaTime, 1));

        }
        ///////////////////////////////////////////////////

   
        if (this.transform.GetComponent<Rigidbody>().velocity.magnitude < 5)
        {
            this.transform.GetComponent<Rigidbody>().mass = 3.37f;
            this.transform.GetComponent<PlayerMovment>().speed = 5f;
            this.transform.GetComponent<Renderer>().material.DOColor(Color.white, 0.3f);
        }


        if (this.transform.GetComponent<Rigidbody>().velocity.magnitude > 7)
        {


            if (Input.GetKey(KeyCode.LeftShift))
            {
               // this.transform.GetComponent<PlayerMovment>().speed = 12f;
                //this.transform.GetComponent<Renderer>().material.DOColor(Color.yellow, 0.3f);
            }
     
               
        }
        //  this.transform.GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.Force);

        if (this.transform.GetComponent<Rigidbody>().velocity.magnitude > 16)
        {
      
            if (Input.GetKey(KeyCode.LeftShift))
            {
                this.transform.GetComponent<Renderer>().material = PlasmaMaterial1;
                // this.transform.GetComponent<Renderer>().material.DOColor(Color.red, 0.3f);
                this.transform.GetComponent<PlayerMovment>().speed = 22f;

         
                if (Input.GetKey(KeyCode.LeftShift)&& this.transform.GetComponent<Rigidbody>().velocity.magnitude > 20)
                {
                    this.transform.GetComponent<Renderer>().material.DOColor(Color.red, 0.3f);
                    this.transform.GetComponent<PlayerMovment>().speed = 40f;
                    this.transform.GetComponent<Renderer>().material = PlasmaMaterial;
                    this.transform.GetComponent<Rigidbody>().mass = 20;
                }
                //38.9371452,0.611578226,0,1
            }
  
        }
    }
}
