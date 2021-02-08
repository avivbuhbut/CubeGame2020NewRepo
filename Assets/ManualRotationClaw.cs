using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualRotationClaw : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log(this.transform.localRotation.x);
            this.transform.localRotation = Quaternion.Euler(this.transform.localRotation.x + 20, this.transform.localRotation.y + 20, this.transform.localRotation.x + 20);

        }
    }
}
