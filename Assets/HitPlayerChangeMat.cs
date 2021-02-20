using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayerChangeMat : MonoBehaviour
{

    public Material ElectredMat;
    Material DefaultMat;
    Transform PlayerTrans;
    public bool CrystalElectred;
    float TimerDestroy=6;
    bool startTimer;
    // Start is called before the first frame update
    void Start()
    {
        PlayerTrans = GameObject.Find("Player").transform;
        DefaultMat = this.transform.GetComponent<Renderer>().material;

    }

    // Update is called once per frame
    void Update() { 
    
        if (startTimer) {

            TimerDestroy -= 0.8f * Time.deltaTime;
            this.transform.GetComponent<Rigidbody>().useGravity = false;
            if ((int)TimerDestroy == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }


     void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name == "Player"  && PlayerTrans.GetComponent<CheckIfRainHitPlayer>().PlayerElectricFull)
        {
            CrystalElectred = true;
            this.transform.GetComponent<Renderer>().material = ElectredMat;

        }

        if (collision.transform.name == "Player" && CrystalElectred && PlayerTrans.GetComponent<CheckIfRainHitPlayer>().PlayerElectricFull == false)
        {
            startTimer = true;
            CrystalElectred = true;
            this.transform.GetComponent<Renderer>().material = ElectredMat;

        }



        //else
        // {
        //     CrystalElectred = false;
        //}
    }
}
