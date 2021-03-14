using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitByElectricPlayer : MonoBehaviour
{
    Material DuefaultMaterial;
    Material ElectredMat;
    public Transform PlayerTrans;

    public static bool ArmHasElectricity;
    // Start is called before the first frame update
    void Start()
    {
        DuefaultMaterial = this.transform.GetComponent<LineRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {


        if (PlayerTrans.GetComponent<CheckIfRainHitPlayer>().PlayerElectricFull == false)
        {
            ArmHasElectricity = false;
            this.transform.GetComponent<LineRenderer>().material = DuefaultMaterial;
        }
    }


     void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Player" && collision.transform.GetComponent<CheckIfRainHitPlayer>().PlayerElectricFull)
        {
            ArmHasElectricity = true;
              ElectredMat = collision.transform.GetComponent<Renderer>().material; 
            this.transform.GetComponent<LineRenderer>().material = collision.transform.GetComponent<Renderer>().material;
        }
    }
}
