using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PowerCellsCounter : MonoBehaviour
{

    public TextMeshPro PowerCellTMP;
    int coutnerPowerCells;
   // public Material ConvyorMat;
    // Start is called before the first frame update
    void Start()
    {
        PowerCellTMP.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


     void OnTriggerEnter(Collider other)
   
    {

        if(other.transform.name == "PowerCircle(Clone)")
        {
            //ConvyorMat.color = other.transform.GetComponent<Renderer>().material.color;
            coutnerPowerCells++;
            PowerCellTMP.text = "Power Cells: " + coutnerPowerCells;
            PowerCellTMP.color = Color.green;
        }
        Debug.Log(other.transform.name);
    }
}
