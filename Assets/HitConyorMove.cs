using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitConyorMove : MonoBehaviour
{
    // Start is called before the first frame update
    bool colidedWithConvyor;
    Transform StartPos;
    Transform StrachConveyor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (colidedWithConvyor)
        {
           this.transform.position = Vector3.MoveTowards(new Vector3(this.transform.position.x, StrachConveyor.position.y+0.3f,this.transform.position.z), StartPos.position, 0.1f);

            this.transform.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

     void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name == "StrachConveyor 1(Clone)")
        {
            colidedWithConvyor = true;
            StrachConveyor = collision.transform;
            StartPos = collision.transform.Find("StartPos").transform;
        }
    }
}
