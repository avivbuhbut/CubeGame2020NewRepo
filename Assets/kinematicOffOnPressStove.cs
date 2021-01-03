using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kinematicOffOnPressStove : MonoBehaviour
{

    public Transform StoveBack;
    public Transform MoblieStoveTrnas;
    //public BoxCollider BoxColiderStove;
    public Rigidbody StoveRigidBody;
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

            if (hit.collider.gameObject.name == "MobileStove")
            {
                
        
                StoveRigidBody.isKinematic = false;
            }



   
         



        }else
            StoveRigidBody.isKinematic = true;
        

        if(StoveRigidBody.isKinematic == true)
            StoveBack.parent = null;
        if (StoveRigidBody.isKinematic == false)
            StoveBack.parent = hit.transform;
        //  if((int)StoveRigidBody.velocity.magnitude==0)
        //  StoveBack.parent = null;




    }

}
