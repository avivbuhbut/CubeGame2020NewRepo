using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AutoBuy : MonoBehaviour
{
    public Button AutoBuyBtn;
    public static bool AutoButton;
    int counterPressedAutoBuy;

    [SerializeField] TextMeshProUGUI AutoBtnTMP;
    Color AutoBtnTMPOriginColor;
    
    // Start is called before the first frame update
    void Start()
    {

        AutoBtnTMPOriginColor = AutoBtnTMP.color;
        counterPressedAutoBuy = 0;

    }

    // Update is called once per frame
    void Update()
    {


        if (counterPressedAutoBuy == 1)
        {
            AutoBtnTMP.color = Color.green;
        }

        if (counterPressedAutoBuy == 2)
        {
            AutoButton = false;
            AutoBtnTMP.color = AutoBtnTMPOriginColor;
            counterPressedAutoBuy = 0;
        }

    }

   
    void OnEnable()
    {
       // if((int)GetComponent< createFlournew>().TimeLeftToNextCreation==0&& )
        AutoBuyBtn.onClick.AddListener(AutoBuyButton);//adds a listener for when you click the button


    }


    void AutoBuyButton()// your listener calls this function
    {
       

        if (PlayerMoney.moneyCounter >= createFlournew.FlourVaule)
        {
            AutoButton = true;
            counterPressedAutoBuy++;
      //      if(counterPressedAutoBuy!=2 && counterPressedAutoBuy==1)
          //  PlayerMoney.moneyCounter -= (int)createFlournew.FlourVaule;
        }
     
    }

}
