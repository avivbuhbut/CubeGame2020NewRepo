using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AutoBuyFlourNineDollars : MonoBehaviour
{

    public Button AutoBuyNineDollarBtn;
    public static bool boolAutoNineDollarButton;
    int PressedAutoNineDollarBuy;

    [SerializeField] TextMeshProUGUI AutoBtnTMP;
    Color AutoBtnNineTMPOriginColor;

    // Start is called before the first frame update
    void Start()
    {

        AutoBtnNineTMPOriginColor = AutoBtnTMP.color;
        PressedAutoNineDollarBuy = 0;

    }

    // Update is called once per frame
    void Update()
    {


        if (PressedAutoNineDollarBuy == 1)
        {
            AutoBtnTMP.color = Color.green;
        }

        if (PressedAutoNineDollarBuy == 2)
        {
            boolAutoNineDollarButton = false;
            AutoBtnTMP.color = AutoBtnNineTMPOriginColor;
            PressedAutoNineDollarBuy = 0;


        }

        if (boolAutoNineDollarButton == false)
        {
            boolAutoNineDollarButton = false;
            AutoBtnTMP.color = AutoBtnNineTMPOriginColor;
            PressedAutoNineDollarBuy = 0;
        }

    }


    void OnEnable()
    {
        // if((int)GetComponent< createFlournew>().TimeLeftToNextCreation==0&& )
        AutoBuyNineDollarBtn.onClick.AddListener(AutoBuyNineDollarButton);//adds a listener for when you click the button


    }


    void AutoBuyNineDollarButton()// your listener calls this function
    {


        if (PlayerMoney.moneyCounter >= createFlournew.FlourVaule)
        {
            boolAutoNineDollarButton = true;
            PressedAutoNineDollarBuy++;
            //      if(counterPressedAutoBuy!=2 && counterPressedAutoBuy==1)
            //  PlayerMoney.moneyCounter -= (int)createFlournew.FlourVaule;
        }


    }
}
