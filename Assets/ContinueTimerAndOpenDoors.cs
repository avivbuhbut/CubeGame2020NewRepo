using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContinueTimerAndOpenDoors : MonoBehaviour
{

    public Button button;
    [SerializeField] TextMeshProUGUI feeCounterTMP;
  //  public TextMeshProUGUI FeeCoutnerTMP;
      float TimeLeftToNextBumpInFee = 20;
    int tempFeeCounter = 6;
    

    public static int CoutnerSecPlayerBuy = 0;


     void Update()
    {
      
       TimeLeftToNextBumpInFee -= 0.8f * Time.deltaTime;

        if(TimeLeftToNextBumpInFee <= 0)
        {
          
            tempFeeCounter++;
            feeCounterTMP.text  = tempFeeCounter + "$";
            //FeeCoutnerTMP.text = tempFeeCounter + "$";
            TimeLeftToNextBumpInFee = 20;
        }


        //if player can affort open the door - acitvate door animation
    }
    void OnEnable()
    {

        button.onClick.AddListener(MyFunction);//adds a listener for when you click the button

    }


    void MyFunction()// your listener calls this function
    {
        if (PlayerMoney.moneyCounter >= 6 && StartTimerEnterFirstChallange.PlayerPassThrow == false)
        {

            StartTimerEnterFirstChallange.PlayerPassThrow = true;


        }

    }
}
