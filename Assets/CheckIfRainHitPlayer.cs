using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfRainHitPlayer : MonoBehaviour
{

    RaycastHit hitAbove;
    public ParticleSystem ElectricParticals;
    public Material ElectricMatPlayer;
    static  float InRainTimer  = 20;
    static float NOTInRainTimer = 20;
    Material PlayerOriginalMaterial;
    public bool PlayerElectricFull;
    // Start is called before the first frame update
    void Start()
    {
        //ElectricParticals.Stop();
        PlayerOriginalMaterial = this.transform.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.up, out hit))
        {
            Debug.Log(hit.transform.name);
            if(hit.transform.tag == "Bounds")
            {


                //ElectricParticals.gameObject.SetActive(true);
                //ElectricParticals.Play();
                InRainTimer -= 0.8f * Time.deltaTime;




                if ((int)InRainTimer == 10)
                {
                    this.transform.GetComponent<Renderer>().material = ElectricMatPlayer;
                    
                }

                if ((int)InRainTimer <= 10)
                    NOTInRainTimer += 0.8f * Time.deltaTime;


                if ((int)InRainTimer == 0)
                {
                    this.transform.GetComponent<ParticleSystem>().Play();
                    PlayerElectricFull = true;
                }

                Debug.Log(" Charging NOTInRainTimer: " + (int)NOTInRainTimer);


            }
            else
            {
                InRainTimer = 20;
                NOTInRainTimer -= 0.8f * Time.deltaTime;

                Debug.Log("NOTInRainTimer: "  + (int)NOTInRainTimer );

                if((int)NOTInRainTimer==10)
                    this.transform.GetComponent<ParticleSystem>().Stop();


                if ((int)NOTInRainTimer == 0)
                {
                    PlayerElectricFull = false;
                    this.transform.GetComponent<Renderer>().material = PlayerOriginalMaterial;
                    NOTInRainTimer = 0;
                }
            }


        }
        
            // if (Physics.Raycast(this.transform.position, this.transform.TransformDirection(Vector3.up), out hitAbove))
            // {
            Debug.DrawLine(this.transform.position, this.transform.TransformDirection(Vector3.up), Color.white);
            //   }


        
    }
}
