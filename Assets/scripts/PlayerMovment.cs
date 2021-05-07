using UnityEngine;
using System.Collections;

public class PlayerMovment : MonoBehaviour
{
    public float speed =5f;
    // Use this for initialization
    Rigidbody rigidbody;
    bool PlayerTouchingTheFloor;
    public PhysicMaterial DefaultBounciessColider;
    float timerDownA;
    float TimerUpA;
    bool PreddesA;
    void Start()
    {
        
    }


    void Update()
    {

     //   if (Input.GetKey(KeyCode.Space))
//this.transform.GetComponent<CapsuleCollider>().material.bounciness = 0;

      //  if (Input.GetKey(KeyCode.LeftControl)) { 
   
      //      this.transform.GetComponent<CapsuleCollider>().material.bounciness = 0;
      //      Debug.Log("Here");
     //   }
    //    else
      //      this.transform.GetComponent<CapsuleCollider>().material = DefaultBounciessColider;
       //his.transform.GetComponent<CapsuleCollider>().material.bounciness = 1;

    }
    // Update is called once per frame
    void FixedUpdate()
    {


        //  if (this.transform.GetComponent<Rigidbody>().velocity.magnitude > 10)
        //     this.transform.GetComponent<PlayerMovment>().enabled = false;

    

        PlayerMovmentCotrol();
    }


    void PlayerMovmentCotrol()
    {







        if (Input.GetKey(KeyCode.Space))
            {
                transform.Translate(Vector3.up * Time.deltaTime * 0.8f, Space.Self);
                this.transform.GetComponent<Rigidbody>().mass = 0.3f;

            this.transform.GetComponent<CapsuleCollider>().material = DefaultBounciessColider;
        }else
            this.transform.GetComponent<CapsuleCollider>().material.bounciness = 0;
        //     rigidbody.velocity = new Vector2(rigidbody.velocity.x, speed);

        if (Input.GetKey(KeyCode.A))
            {
            PreddesA = true;
            TimerUpA += 0.8f * Time.deltaTime;
                transform.Translate(Vector3.left * Time.deltaTime * speed, Space.Self); //LEFT
        }
        else { 
        timerDownA = TimerUpA;
        float TempSped = speed;
            if (PreddesA)
            {
                timerDownA -= 0.8f * Time.deltaTime;

                Debug.Log("timerDownA: " + timerDownA + "TempSped" + TempSped);


                if (timerDownA % 1 == 0)
                {
                    if (TempSped > 0)
                    {
                        TempSped -= 1;
                        transform.Translate(Vector3.left * Time.deltaTime * TempSped, Space.Self); //LEFT
                    }
                    else
                    {
                        PreddesA = false;
                    }
                }



            }
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed, Space.Self); //RIGHT
            }

        }
    


}