using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerbecomeKinematic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            this.transform.GetComponent<Rigidbody>().isKinematic = true;
        }

        if (Input.GetKey(KeyCode.K) && this.transform.GetComponent<Rigidbody>().isKinematic ==true)
        {
            this.transform.GetComponent<Rigidbody>().isKinematic = false;
        }

    }


    
}
