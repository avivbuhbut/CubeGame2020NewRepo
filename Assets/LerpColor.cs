using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpColor : MonoBehaviour
{
    Color CurrentColor;
    Color lerpedColor;

    // Start is called before the first frame update
    void Start()
    {
        CurrentColor = this.transform.GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
    
          //  this.transform.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, CurrentColor, Mathf.PingPong(Time.deltaTime, 1));
    }
}
