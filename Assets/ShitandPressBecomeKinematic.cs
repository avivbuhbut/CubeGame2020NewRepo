using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShitandPressBecomeKinematic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);                    ///Very Useful Code! - tells the object name when clicked by the mouse

        // Casts the ray and get the first game object hit
        Physics.Raycast(ray, out hit);

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(hit.transform.name);
            if (hit.transform.name == "BasicConveyorBelt 1(Clone)" || hit.transform.name == "BasicConveyorBelt 1")
            {
                // hit.transform.gameObject.AddComponent<Rigidbody>();
              //  hit.transform.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                // hit.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ |
                //   RigidbodyConstraints.FreezeRotationZ;
            }



        }
     //   else
       //     hit.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

    }

    // if (hit.transform.name == "BasicConveyorBelt 1(Clone)" || hit.transform.name == "BasicConveyorBelt 1")


}
