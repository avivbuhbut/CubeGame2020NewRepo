using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlourColiderForConeyor : MonoBehaviour
{

    public static bool FlourHitConveyor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

     public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.name == "BasicConveyorBelt(Clone)" ||
              collision.gameObject.transform.name == "BasicConveyorBelt")
        {
            FlourHitConveyor = true;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.transform.name == "BasicConveyorBelt(Clone)" ||
              collision.gameObject.transform.name == "BasicConveyorBelt")
        {
            FlourHitConveyor = false;
        }
    }
}
