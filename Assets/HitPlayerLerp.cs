using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayerLerp : MonoBehaviour
{
    Transform PlayerTrans;
    bool colidedWithPlayer;
    // Start is called before the first frame update
    void Start()
    {
        PlayerTrans = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (colidedWithPlayer)
        {
            //.transform.position = Vector3.Lerp(new Vector3(this.transform.position.x, this.transform.position.y +3, this.transform.position.z)
            //   ,new Vector3(PlayerTrans.position.x+3,PlayerTrans.position.y+3,PlayerTrans.position.z), Time.deltaTime*0.1f);
//this.transform.GetComponent<Rigidbody>().useGravity = false;
             //this.transform.position
        }
    }


     void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Player")
            colidedWithPlayer = true;
    }
}
