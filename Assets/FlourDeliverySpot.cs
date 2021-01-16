using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlourDeliverySpot : MonoBehaviour
{
    public GameObject MoneyTrans;
    bool FlourHit;
    int FlourValue=0;
    // Start is called before the first frame update
    void Start()
    {
        MoneyTrans.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (FlourHit && FlourValue >= 0)
        {

            GameObject Clone = Instantiate(MoneyTrans, new Vector3(this.transform.position.x, this.transform.position.y + 1.5f, this.transform.position.z), Quaternion.identity);
            Clone.transform.localRotation = Quaternion.Euler(0, 270, 0);
            FlourValue--;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Flour" || collision.transform.name == "Flour 1(Clone)") 
        {
            FlourHit = true;
            //FlourValue = PizzaValue.pizzaValue;

            //    StartTimerEnterFirstChallange.PlayerPassThrow = false;
            collision.transform.gameObject.SetActive(false);
            MoneyTrans.gameObject.SetActive(true);
        }
    }


    void OnCollisionExit(Collision collision)
    {
     
    }


}