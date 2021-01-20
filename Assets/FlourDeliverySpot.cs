using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FlourDeliverySpot : MonoBehaviour
{
    public GameObject MoneyTrans;
    public TextMeshPro MoneyValueTMP;
    bool FlourHit;
    int FlourValue=0;
    int numberOfFourHit;

    // Start is called before the first frame update
    void Start()
    {
        MoneyTrans.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfFourHit == 5)
        {
            numberOfFourHit = 0;
            add4DollarPlayer.MoneyValue++;
        }
        Debug.Log(" Money Value For Flour: "+add4DollarPlayer.MoneyValue);
        MoneyValueTMP.text = add4DollarPlayer.MoneyValue + "$";
        if (FlourHit )
        {
     
            GameObject Clone = Instantiate(MoneyTrans, new Vector3(this.transform.position.x, this.transform.position.y + 1.5f, this.transform.position.z), Quaternion.identity);
            Clone.transform.localRotation = Quaternion.Euler(0, 270, 0);
            MoneyValueTMP.text = add4DollarPlayer.MoneyValue + "$";
                 // FlourValue--;
                 FlourHit = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Flour" || collision.transform.name == "Flour 1(Clone)"||
            collision.transform.name == "Flour")
        {

            

            numberOfFourHit++;
        

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