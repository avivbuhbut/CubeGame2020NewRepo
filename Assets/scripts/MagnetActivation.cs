using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetActivation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnMouseOver();
       // if (Input.GetMouseButtonDown(0))
           // MoneyMagnet.magnetForce = 0;
       // this.transform.GetComponent<SphereCollider>().isTrigger = false; // good to "shoot" the attached objects


        if(Input.GetMouseButtonDown(0))
            PowerCellMagnet.magnetForce = 80f;
       if(Input.GetKey(KeyCode.LeftShift) && Input.GetMouseButtonDown(0))
            PowerCellMagnet.magnetForce = 0;
        ///    this.transform.GetComponent<SphereCollider>().isTrigger = true;

    }

     void OnMouseOver()
    {
   
    }
}
