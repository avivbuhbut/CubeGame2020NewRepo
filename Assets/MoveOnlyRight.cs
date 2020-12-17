using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnlyRight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * 5f, Space.Self); //RIGHT
        }
    }
}
