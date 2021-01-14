using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSauceWaterPassButtonTurnRed : MonoBehaviour
{

     bool PlayerPassThrow;
     bool SaucePassThrow;
     bool WaterPassThrow;
    public bool TurnButtonToRed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPassThrow && SaucePassThrow && WaterPassThrow)
            TurnButtonToRed = true;


        }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
            PlayerPassThrow = true;

        if (other.transform.tag == "Sauce")
            SaucePassThrow = true;

        if (other.transform.tag == "Water")
            WaterPassThrow = true;

    }



}
