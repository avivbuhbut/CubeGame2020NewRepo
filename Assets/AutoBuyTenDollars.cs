using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AutoBuyTenDollars : MonoBehaviour
{

    public Button AutoBuyBtnTenDollar;
    public static bool AutoButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void OnEnable()
    {

        AutoBuyBtnTenDollar.onClick.AddListener(AutoBuyTenDollar);//adds a listener for when you click the button


    }


    void AutoBuyTenDollar()// your listener calls this function
    {


        if (PlayerMoney.moneyCounter >= createFlournew.FlourVaule)
        {
            AutoButton = true;
         //  counterPressedAutoBuy++;
             PlayerMoney.moneyCounter -= (int)createFlournew.FlourVaule;
        }

    }
}
