using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerKinOnOff : MonoBehaviour
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

        if (Input.GetKey(KeyCode.Mouse0))
        {

            if (hit.collider.gameObject.name == "Container")
            {


                this.transform.GetComponent<Rigidbody>().isKinematic = false;
            }








        }
else
this.transform.GetComponent<Rigidbody>().isKinematic = true;
    }
}
