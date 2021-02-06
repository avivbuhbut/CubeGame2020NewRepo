using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCollisionPlayer : MonoBehaviour
{
    bool armColidedWithCube;
    public Transform PlayerTrans;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    

    }


     void OnCollisionStay(Collision collision)
    {  

        if (collision.transform.name == "Player")
            armColidedWithCube = true;

        if (armColidedWithCube)
        {
            this.transform.position = new Vector3(PlayerTrans.position.x + 1, PlayerTrans.position.y + 1, PlayerTrans.position.z);
            this.transform.GetComponent<Rigidbody>().isKinematic = true;
        }
    }



    void OnCollisionExit(Collision collision)
    {

       // if (collision.transform.name == "Player")
         //   armColidedWithCube = false;
    }
}
