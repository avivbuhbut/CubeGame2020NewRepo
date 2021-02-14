using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PowerCellsCounter : MonoBehaviour
{

    public TextMeshPro PowerCellTMP;
    int coutnerPowerCells;
    // Start is called before the first frame update
    void Start()
    {
        PowerCellTMP.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


     void OnCollisionEnter(Collision collision)
    {

        if(collision.transform.name == "PowerCircle(Clone)")
        {
            coutnerPowerCells++;
            PowerCellTMP.text = "Power Cells: " + coutnerPowerCells;
            PowerCellTMP.color = Color.green;
        }
        Debug.Log(collision.transform.name);
    }
}
