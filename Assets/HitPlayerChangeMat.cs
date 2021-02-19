using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayerChangeMat : MonoBehaviour
{

    public Material ElectredMat;
     Material DefaultMat;
    Transform PlayerTrans;
    public bool CrystalElectred;
    // Start is called before the first frame update
    void Start()
    {
        PlayerTrans = GameObject.Find("Player").transform;
        DefaultMat = this.transform.GetComponent<Renderer>().material;

    }

    // Update is called once per frame
    void Update()
    {
        
    }


     void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name == "Player"  && PlayerTrans.GetComponent<CheckIfRainHitPlayer>().PlayerElectricFull)
        {
            CrystalElectred = true;
            this.transform.GetComponent<Renderer>().material = ElectredMat;
        }
        else
        {
            CrystalElectred = false;
        }
    }
}
