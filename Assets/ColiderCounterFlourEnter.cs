using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColiderCounterFlourEnter : MonoBehaviour
{
    int counterFlour;
    bool enterColiderCounterFlourZone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(counterFlour);
    }


     void OnTriggerEnter(Collider other)
   
        
   
    {
        if(other.transform.name == "Flour")
        {
          //  Debug.Log("flour enter zone");
            counterFlour++;
        }
    }
}
