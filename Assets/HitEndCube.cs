using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEndCube : MonoBehaviour
{

    public bool PlayerHitEndCube;
    public Transform HitCubeTrans;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


     void OnCollisionEnter(Collision collision)
    {
        

        if(collision.transform.name == "EndCube")
        {
            PlayerHitEndCube = true;
            HitCubeTrans = collision.transform;
        }
    }
}
