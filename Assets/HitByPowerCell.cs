using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitByPowerCell : MonoBehaviour
{
    bool ColidedPowerCircle;
    int counterPowerCellHit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ColidedPowerCircle&& counterPowerCellHit<9)
            this.transform.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.red, Mathf.PingPong(Time.time, 1));

        if (counterPowerCellHit == 9)
        {
            this.transform.GetComponent<Renderer>().material.color = Color.green;

        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name == "PowerCircle(Clone)")
        {
            counterPowerCellHit++;
            ColidedPowerCircle = true;
            collision.transform.gameObject.SetActive(false);
        }

    }
}
