using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChnageTagTempWhileOnConveor : MonoBehaviour
{

    string OriginalTag;
    // Start is called before the first frame update
    void Start()
    {
        OriginalTag = this.transform.tag;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name == "BasicConveyorBelt")
        {
            this.transform.tag = "Flour";
        }
    }


    void OnCollisionExit(Collision collision)
    {
        if (collision.transform.name == "BasicConveyorBelt")
        {
            this.transform.tag = OriginalTag;
        }
    }
}
