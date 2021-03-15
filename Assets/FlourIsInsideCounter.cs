using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlourIsInsideCounter : MonoBehaviour
{
    static int counterColidedWithFlour;

    public Material GreenMat;
    public Transform LinkCube1;
    public Transform LinkCube2;
    public Transform LinkCube3;
    public Transform LinkCube4;
    public Transform LinkCube5;
    public Transform LinkCube6;
    Material DefaultMat;

  
    // Start is called before the first frame update
    void Start()
    {
        DefaultMat = LinkCube1.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (counterColidedWithFlour == 1)
        {

            LinkCube6.GetComponent<Renderer>().material = GreenMat;

        }

        if (counterColidedWithFlour == 2)
            LinkCube5.GetComponent<Renderer>().material = GreenMat;

        if (counterColidedWithFlour == 3)
            LinkCube4.GetComponent<Renderer>().material = GreenMat;

        if (counterColidedWithFlour == 4)
            LinkCube3.GetComponent<Renderer>().material = GreenMat;


        if (counterColidedWithFlour == 5)
            LinkCube2.GetComponent<Renderer>().material = GreenMat;


        if (counterColidedWithFlour == 6)
            LinkCube1.GetComponent<Renderer>().material = GreenMat;


        if (ElectircWallOnEnterElectricPlayer.WallReachEndDest)
        {
            LinkCube1.gameObject.SetActive(false);
            LinkCube2.gameObject.SetActive(false);
            LinkCube3.gameObject.SetActive(false);
            LinkCube4.gameObject.SetActive(false);
            LinkCube5.gameObject.SetActive(false);
            LinkCube6.gameObject.SetActive(false);
            this.transform.gameObject.SetActive(false);
        }

    }


    

     void OnTriggerEnter(Collider other)

    {
        if (other.transform.name == "Flour")
        {
            counterColidedWithFlour++;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.transform.name == "Flour")
        {

            if (counterColidedWithFlour == 1)
            {

                LinkCube6.GetComponent<Renderer>().material = DefaultMat;

            }

            if (counterColidedWithFlour == 2)
                LinkCube5.GetComponent<Renderer>().material = DefaultMat;

            if (counterColidedWithFlour == 3)
                LinkCube4.GetComponent<Renderer>().material = DefaultMat;

            if (counterColidedWithFlour == 4)
                LinkCube3.GetComponent<Renderer>().material = DefaultMat;


            if (counterColidedWithFlour == 5)
                LinkCube2.GetComponent<Renderer>().material = DefaultMat;


            if (counterColidedWithFlour == 6)
                LinkCube1.GetComponent<Renderer>().material = DefaultMat;

            counterColidedWithFlour--;
        }
    }
}
