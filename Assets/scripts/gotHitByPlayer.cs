using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gotHitByPlayer : MonoBehaviour
{

    static int counter = 0;
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
        if(collision.transform.tag == "Player" && counter <20 && collision.transform.GetComponent<Rigidbody>().mass == 20)
        {
            counter++;
            this.transform.GetComponent<Rigidbody>().isKinematic = false;
            this.transform.GetComponent<MeshDestroy>().DestroyMesh(this.transform.gameObject.GetComponent<MeshFilter>().mesh, this.transform.GetComponent<MeshDestroy>(), this.gameObject);
            
        }
    }
}
