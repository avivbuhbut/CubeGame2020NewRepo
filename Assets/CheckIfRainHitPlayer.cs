using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfRainHitPlayer : MonoBehaviour
{

    RaycastHit hitAbove;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);                    ///Very Useful Code! - tells the object name when clicked by the mouse

        // Casts the ray and get the first game object hit
        Physics.Raycast(ray, out hitAbove);
        // if (Physics.Raycast(this.transform.position, this.transform.TransformDirection(Vector3.up), out hitAbove))
        // {
        Debug.DrawLine(this.transform.position,this.transform.TransformDirection(Vector3.up),Color.white);
     //   }


    }
}
