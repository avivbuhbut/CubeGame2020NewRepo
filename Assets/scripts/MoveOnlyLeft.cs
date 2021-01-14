using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnlyLeft : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * 5f, Space.Self); //LEFT
        }
    }
}
