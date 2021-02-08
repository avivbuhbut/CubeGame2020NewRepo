using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayerCreateLineAndConveyor : MonoBehaviour
{

     Transform PlayerTrans;
    public LineRenderer LineRenderer;
    bool ColidedWithPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (ColidedWithPlayer)
        {
            LineRenderer.SetPosition(0, this.transform.position);
            LineRenderer.SetPosition(1, PlayerTrans.position);
        }


    }


     void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name == "Player")
        {
            ColidedWithPlayer = true;
            PlayerTrans = collision.transform;
        }
    }
}
