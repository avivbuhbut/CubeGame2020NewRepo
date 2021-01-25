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

     void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name== "ConeyorBlockEnd")
        {
            HitConveyorEnd = true;
            ConveyorEnd = collision.transform;
        }
    }
}
