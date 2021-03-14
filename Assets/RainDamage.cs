using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainDamage : MonoBehaviour
{

    public Transform Damage6;
    public Transform Damage5;
    public Transform Damage4;
    public Transform Damage3;
    public Transform Damage2;
    public Transform Damage1;


    public Material LightBrownMat;
    public Material MidBrownMat;
    public Material DarkBrownMat;

    public Material DamageMat;
    float InRainTimer;


    public bool ValueFlourZero;
    public bool ValueFlourOne;
    // Start is called before the first frame update
    void Start()
    {
        ValueFlourOne = false;
        ValueFlourZero = false;
        Damage6.gameObject.SetActive(false);
        Damage5.gameObject.SetActive(false);
        Damage4.gameObject.SetActive(false);
        Damage3.gameObject.SetActive(false);
        Damage2.gameObject.SetActive(false);
        Damage1.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.up, out hit))
        {
         


            if (hit.transform.tag == "Bounds")
            {
                InRainTimer += 0.8f * Time.deltaTime;

                if ((int)InRainTimer == 3)
                {

                    Damage6.gameObject.SetActive(true);
                    Damage5.gameObject.SetActive(true);
                    Damage4.gameObject.SetActive(true);
                    Damage3.gameObject.SetActive(true);
                    Damage2.gameObject.SetActive(true);
                    Damage1.gameObject.SetActive(true);


                    Damage6.GetComponent<Renderer>().material = DamageMat;
                }

                if ((int)InRainTimer == 6)
                {
                
                    Damage5.GetComponent<Renderer>().material = DamageMat;
                }

                if ((int)InRainTimer == 9)
                {
                    this.transform.GetComponent<Renderer>().material = LightBrownMat;
                    Damage4.GetComponent<Renderer>().material = DamageMat;
                }

                if ((int)InRainTimer == 12)
                {
                    this.transform.GetComponent<Renderer>().material = MidBrownMat;
                    Damage3.GetComponent<Renderer>().material = DamageMat;
                    ValueFlourOne = true;
                
                }

                if ((int)InRainTimer == 15)
                {
                    Damage2.GetComponent<Renderer>().material = DamageMat;
                }


                if ((int)InRainTimer == 18)
                {
                    this.transform.GetComponent<Renderer>().material = DarkBrownMat;
                    Damage1.GetComponent<Renderer>().material = DamageMat;
                    ValueFlourZero = true;
                }
            }
        }


        

    }

     void OnTriggerEnter(Collider other)
    {
        if(other.transform.name == "TurnOffDamage")
        {
            Damage6.gameObject.SetActive(false);
            Damage5.gameObject.SetActive(false);
            Damage4.gameObject.SetActive(false);
            Damage3.gameObject.SetActive(false);
            Damage2.gameObject.SetActive(false);
            Damage1.gameObject.SetActive(false);
        }
    }
}
