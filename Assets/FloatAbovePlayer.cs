using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatAbovePlayer : MonoBehaviour
{
    public Transform PlayerTrans;
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
            this.transform.GetComponent<Rigidbody>().useGravity =false;
       //     this.transform.position =Vector3.MoveTowards(new Vector3(PlayerTrans.position.x, PlayerTrans.position.y + 2, PlayerTrans.position.z), new Vector3(PlayerTrans.position.x+2, PlayerTrans.position.y + 2, PlayerTrans.position.z),2f * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        Debug.Log(collision.transform.name);
        if (collision.transform.name == "Player")
        {
            ColidedWithPlayer = true;

        }
    }
}
