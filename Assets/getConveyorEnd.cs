using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getConveyorEnd : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform ConveyorEnd;
    public bool HitConveyorEnd;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

     void OnCollisionStay(Collision collision)
    {
        if(collision.transform.name== "ConeyorBlockEnd2")
        {
            HitConveyorEnd = true;
            ConveyorEnd = collision.transform;
        }
    }
}
