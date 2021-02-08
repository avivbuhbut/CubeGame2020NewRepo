using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockLine : MonoBehaviour
{

    public Transform ClockEndCube;
    public LineRenderer LineRender;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LineRender.SetPosition(0, this.transform.position);
        LineRender.SetPosition(1, ClockEndCube.position);
    }
}
