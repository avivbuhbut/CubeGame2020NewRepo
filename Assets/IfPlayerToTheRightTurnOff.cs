using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfPlayerToTheRightTurnOff : MonoBehaviour
{
    // Start is called before the first frame update

    Transform PlayerTrans;
    Vector3 stratPos;
    void Start()
    {
        PlayerTrans = GameObject.Find("Player").transform;
        stratPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("PlayerTrans.position.x: " + PlayerTrans.position.x + "this.transform.position.x:   " + this.transform.position.x) ;

        if (PlayerTrans.position.x > this.transform.position.x)
        {
            //player to the right
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 5);
        }
        else
            this.transform.position = stratPos;
    }
}
