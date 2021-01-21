using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class add4DollarPlayer : MonoBehaviour
{

    public  int MoneyValue;
    // Start is called before the first frame update
    void Start()
    {
        MoneyValue = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    
}


    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            this.transform.gameObject.SetActive(false);
            PlayerMoney.moneyCounter += MoneyValue;
        }

    }
}
