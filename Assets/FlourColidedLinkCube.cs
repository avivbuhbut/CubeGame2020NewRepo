using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlourColidedLinkCube : MonoBehaviour
{

    static int counterColidedWithFlour;

    public Material GreenMat;
    public Transform LinkCube1;
    public Transform LinkCube2;
    public Transform LinkCube3;
    public Transform LinkCube4;
    public Transform LinkCube5;
    public Transform LinkCube6;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (counterColidedWithFlour == 1)
            LinkCube1.GetComponent<Renderer>().material = GreenMat;

        if (counterColidedWithFlour == 2)
            LinkCube2.GetComponent<Renderer>().material = GreenMat;

        if (counterColidedWithFlour == 3)
            LinkCube3.GetComponent<Renderer>().material = GreenMat;

        if (counterColidedWithFlour == 4)
            LinkCube4.GetComponent<Renderer>().material = GreenMat;


        if (counterColidedWithFlour == 5)
            LinkCube5.GetComponent<Renderer>().material = GreenMat;


        if (counterColidedWithFlour == 6)
            LinkCube6.GetComponent<Renderer>().material = GreenMat;


    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name == "Flour")
        {
            counterColidedWithFlour++;
        }
    }
}
