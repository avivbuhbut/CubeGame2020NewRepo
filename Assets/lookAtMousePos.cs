using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookatMousePos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouse = Input.mousePosition;
        mouse.z =-7.6f;
        Vector3 mouseInScene = Camera.main.ScreenToWorldPoint(mouse);

        transform.LookAt(mouse);

    }
}
