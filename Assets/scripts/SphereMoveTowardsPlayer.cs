using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMoveTowardsPlayer : MonoBehaviour
{
    public Material PlayerRedMaterial;
    public Material PlayerGreenMaterial;


    public Material PizzaBoxMaterial;
    public bool PlayerIsInRadius;
    bool PizzaBoxInRadius;
  public  bool PlayerCloneInRadius;
    Transform Player;

    Transform PizzaBoxTrans;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").transform;
        this.transform.GetComponent<Renderer>().material.SetColor("_Color", Color.green);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerInRadius();
        PlayerCloneInRadiusMethod();

       // EnemyInsidePlayerChangeColorPlayer();

       
            CahngeColorPizzaWhenInRadius();

        CancelDragRigDollWhenPizzaInRadius();

    }

    void CancelDragRigDollWhenPizzaInRadius()
    {
        if (PizzaBoxTrans != null && PizzaBoxInRadius)
        {
            if ((PizzaBoxTrans.GetComponent<Rigidbody>().velocity.magnitude > 1) && (!Input.GetKey(KeyCode.Mouse0)))
            {
                Debug.Log("Cancel rid");
           //     GameObject.Find("Player").GetComponent<DragRigidbody>().enabled = false;
                PizzaBoxTrans.GetComponent<Rigidbody>().mass = 50;
            }
            else
            {
                PizzaBoxTrans.GetComponent<Rigidbody>().mass = 1.4f;
            }

        }

        if (!PizzaBoxInRadius && PizzaBoxTrans!= null)
        {
            PizzaBoxTrans.GetComponent<Rigidbody>().mass = 1.4f;
     //       GameObject.Find("Player").GetComponent<DragRigidbody>().enabled = true;
            Debug.Log("enabled rid");
        }
    }

    //if ((velBox1.magnitude > 8) && (!Input.GetKey(KeyCode.Mouse0)))
    void CahngeColorPizzaWhenInRadius()
    {

        if (PizzaBoxInRadius)
            PizzaBoxTrans.GetComponent<Renderer>().material.color = Color.red;
   //     else
           // if (PizzaBoxTrans != null)
       //     PizzaBoxTrans.GetComponent<Renderer>().material.color = Color.;


    }


    void PlayerInRadius()
    {


 
        if (PlayerIsInRadius)
        {

            this.transform.position = Vector3.MoveTowards(this.transform.position, GameObject.FindWithTag("Player").transform.position, 3.1f * Time.deltaTime); // move towards the pizza box

            this.transform.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
        else
            this.transform.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
    }


    void PlayerCloneInRadiusMethod()
    {



        if (PlayerCloneInRadius)
        {

            this.transform.position = Vector3.MoveTowards(this.transform.position, GameObject.Find("Player(Clone)").transform.position, 11.8f * Time.deltaTime); // move towards the pizza box

            this.transform.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
        else
            this.transform.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
    }


    void EnemyInsidePlayerChangeColorPlayer()
    {
        if (this.transform.position == GameObject.Find("Player").transform.position)
        {
            GameObject.Find("Player").transform.GetComponent<Renderer>().material = PlayerRedMaterial;
            Debug.Log("now isinde player");
        }
       if(this.transform.position != GameObject.Find("Player").transform.position)
            GameObject.Find("Player").transform.GetComponent<Renderer>().material = PlayerGreenMaterial;
    }
 
     void OnTriggerEnter(Collider other)
    {



        if (other.transform.gameObject.tag == "Player")
        {
            PlayerIsInRadius = true;
        }



    }

     void OnTriggerExit(Collider other)//sd
    {


        if (other.transform.gameObject.tag == "Player")
        {
            PlayerIsInRadius = false;
        }

 

    }
}
