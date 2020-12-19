using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConvertMoneyToTime : MonoBehaviour { 
    public Button button;
    public TextMeshPro Plus7SecTMP;
    public TextMeshPro PlayerTimerTMP;
    Color OriginalColorPlayerTMp;
    bool display7Sec;
    float timeShown ;
    public static int CoutnerSecPlayerBuy = 0;
void OnEnable()
{

        button.onClick.AddListener(MyFunction);//adds a listener for when you click the button

}
     void Start()
    {
        OriginalColorPlayerTMp = PlayerTimerTMP.color;
        Plus7SecTMP.gameObject.SetActive(false);
    }
    void Update()
    {
  
        if (display7Sec)
        {
         
            timeShown -= Time.deltaTime;
            if (timeShown >= 0)
            {
               
                Plus7SecTMP.gameObject.SetActive(true);
                Plus7SecTMP.text = "+" + CoutnerSecPlayerBuy + "Sec";
                PlayerTimerTMP.color = Color.green;
            }
            else
            {
                display7Sec = false;
                timeShown = 3;
                Plus7SecTMP.gameObject.SetActive(false);
                PlayerTimerTMP.color = OriginalColorPlayerTMp;
                CoutnerSecPlayerBuy = 0;
            }

        }
       
       

    }

    void MyFunction()// your listener calls this function
{
        if (PlayerMoney.moneyCounter > 0&&StartTimerEnterFirstChallange.PlayerPassThrow)
        {
       
            display7Sec = true;
           
                PlayerMoney.moneyCounter -= 1;

                StartTimerEnterFirstChallange.timeLeft += 7f;
                CoutnerSecPlayerBuy += 7;
                timeShown = CoutnerSecPlayerBuy;
            
        }
        else
            display7Sec = false;
        Debug.Log("this button is pressed!");
}

}
