using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ContinueTimerAndOpenDoors : MonoBehaviour
{

    public Button button;


    public static int CoutnerSecPlayerBuy = 0;
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
