using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToOtherConveyor : MonoBehaviour
{
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
        if (collision.gameObject.transform.name == "BasicConveyorBelt(Clone)" ||
            collision.gameObject.transform.name == "BasicConveyorBelt")
        {
            Debug.Log(collision.transform.GetChild(1).gameObject.name);

            if(collision.transform.position.x < this.transform.position.x)//to the left of the conveyer.
            {
                this.transform.position = new Vector3(collision.transform.position.x +5.8f, this.transform.position.y,
                    this.transform.position.z);

                this.transform.GetChild(1).position = new Vector3(collision.transform.GetChild(1).position.x,
                    collision.transform.GetChild(1).position.y, collision.transform.GetChild(1).position.z);
            }



            if (collision.transform.position.x > this.transform.position.x)//to the left of the conveyer.
            {
                collision.transform.GetChild(1).position = new Vector3(this.transform.GetChild(1).position.x,
                    this.transform.GetChild(1).position.y, this.transform.GetChild(1).position.z);
            }

            collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, this.transform.position.y, collision.gameObject.transform.position.z);
            this.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            //   collision.gameObject.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
