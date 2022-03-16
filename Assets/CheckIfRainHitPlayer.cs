using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfRainHitPlayer : MonoBehaviour
{

    RaycastHit hitAbove;
    public ParticleSystem ElectricParticals;
    public Material ElectricMatPlayer;
    static  float InRainTimer  = 13;
   public static float NOTInRainTimer = 20;
    Material PlayerOriginalMaterial;
    public bool PlayerElectricFull;
    public ParticleSystem RainFallParticale1;
    public ParticleSystem RainFallParticale2;
    public Material FirePariclesMat;
    float timerHitPartricleEnemy = 3;
    static int NumOfParticles = 80;
    // Start is called before the first frame update
    void Start()
    {
      //  this.transform.GetComponent<Renderer>().material = ElectricMatPlayer;
      //  this.transform.GetComponent<ParticleSystem>().Play();
       // PlayerElectricFull = true;

        //ElectricParticals.Stop();
        PlayerOriginalMaterial = this.transform.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

        
        RaycastHit hit;


        if (Physics.Raycast(transform.position, Vector3.right, out hit))
        {
            if (hit.transform.name == "EnemyParticles")
            {
          

                timerHitPartricleEnemy -= 0.8f * Time.deltaTime;

                int ParticleEmmitionCount = hit.transform.GetComponent<ParticleSystem>().particleCount;
                if ((int)timerHitPartricleEnemy == 0)
                {
                    hit.transform.GetComponent<ParticleSystem>().GetComponent<Renderer>().material = FirePariclesMat;
                 //   ParticleEmmitionCount -= 100;
                                   // hit.transform.GetComponent<ParticleSystem>().Emit(ParticleEmmitionCount);
                    var emission = hit.transform.GetComponent<ParticleSystem>().emission;

                    emission.rateOverTime = NumOfParticles;
                    NumOfParticles -= 10;
                }

            }


        }



            if (Physics.Raycast(transform.position, Vector3.up, out hit))
        {
            Debug.Log(hit.transform.name);
            if(hit.transform.tag == "Bounds" || hit.transform.name == "EnemyParticles")
            {
                RainFallParticale1.Play();
                RainFallParticale2.Play();

                //ElectricParticals.gameObject.SetActive(true);
                //ElectricParticals.Play();
                InRainTimer -= 0.8f * Time.deltaTime;




                if ((int)InRainTimer == 10)
                {
                    this.transform.GetComponent<Renderer>().material = ElectricMatPlayer;
                    
                }

                if ((int)InRainTimer <= 10)
                    NOTInRainTimer += 0.8f * Time.deltaTime;


                if ((int)InRainTimer == 5)
                {
                    this.transform.GetComponent<ParticleSystem>().Play();
                    PlayerElectricFull = true;
                }

                Debug.Log(" Charging NOTInRainTimer: " + (int)NOTInRainTimer);


            }
            
            else if (hit.transform.tag != "Bounds" || hit.transform.name != "EnemyParticles")
            {
                RainFallParticale1.Stop();
                RainFallParticale2.Stop();

                InRainTimer = 13;
                NOTInRainTimer -= 0.8f * Time.deltaTime;



                if((int)NOTInRainTimer<=10)
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
        //    Debug.DrawLine(this.transform.position, this.transform.TransformDirection(Vector3.up), Color.white);
        //   }
       // if (PlayerElectricFull == false)
       // {
        //    this.transform.GetComponent<ParticleSystem>().Stop();
        //}
   
        
    }

     void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "TimeCrystalPink(Clone)" && collision.transform.GetComponent<HitPlayerChangeMat>().CrystalElectred)
        {
            NOTInRainTimer = 120;
            this.transform.GetComponent<Renderer>().material = ElectricMatPlayer;
            this.transform.GetComponent<ParticleSystem>().Play();
            PlayerElectricFull = true;
        }
    }
}
