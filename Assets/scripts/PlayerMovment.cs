using UnityEngine;
using System.Collections;

public class PlayerMovment : MonoBehaviour
{
    public float speed =5f;
    // Use this for initialization
    Rigidbody rigidbody;
    bool PlayerTouchingTheFloor;

    void Start()
    {
  
    }

    // Update is called once per frame
     void FixedUpdate()
    {


        if (this.transform.GetComponent<Rigidbody>().velocity.magnitude > 10)
            this.transform.GetComponent<PlayerMovment>().enabled = false;

        PlayerMovmentCotrol();
    }


    void PlayerMovmentCotrol()
    {



      
      


        if (Input.GetKey(KeyCode.Space))
            {
                transform.Translate(Vector3.up * Time.deltaTime * 8f, Space.Self);
                this.transform.GetComponent<Rigidbody>().mass = 0.3f;

            }
            //     rigidbody.velocity = new Vector2(rigidbody.velocity.x, speed);

            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed, Space.Self); //LEFT
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed, Space.Self); //RIGHT
            }

        }
    


}