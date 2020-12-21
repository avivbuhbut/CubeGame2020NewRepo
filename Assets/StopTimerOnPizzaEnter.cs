using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTimerOnPizzaEnter : MonoBehaviour
{

    public GameObject MoneyTrans;
    bool pizzaHit;
    int pizzaValue;
    // Start is called before the first frame update
    void Start()
    {
        MoneyTrans.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (pizzaHit && pizzaValue >= 0)
        {

            GameObject Clone = Instantiate(MoneyTrans, new Vector3(this.transform.position.x, this.transform.position.y + 1.5f, this.transform.position.z), Quaternion.identity);
            Clone.transform.localRotation = Quaternion.Euler(0, 270, 0);
            pizzaValue--;
        }
    }

     void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag== "PizzaBox")
        {
            pizzaHit = true;
                pizzaValue = PizzaValue.pizzaValue;

            //    StartTimerEnterFirstChallange.PlayerPassThrow = false;
            collision.transform.gameObject.SetActive(false);
            MoneyTrans.gameObject.SetActive(true);
        }
    }


    void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "PizzaBox")
        {
            //StartTimerEnterFirstChallange.PlayerPassThrow = true;
        }
    }
}
