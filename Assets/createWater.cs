using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class createWater : MonoBehaviour
{

    public Transform PlayerTrans;
    public Button WaterBuyButton;
    public GameObject WaterGameObj;
    float TimeLeftToNextCreation = 10;
    float StartTimeLeftToNextCreation;
    [SerializeField] TextMeshProUGUI WaterNextCreationTMP;
    [SerializeField] TextMeshProUGUI WaterValueTMP;
    [SerializeField] TextMeshProUGUI NotEnoughMoneyTMP;
    bool startTimer;
    bool buttonPressed;
    float WaterVaule;
    bool NotEnoughMoney;
    float TimerNotEnoughMoney = 3f;
    // Start is called before the first frame update
    void Start()
    {
        WaterVaule = 3;
        StartTimeLeftToNextCreation = 10;
        startTimer = true;
        NotEnoughMoneyTMP.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer && buttonPressed)
        {
            TimeLeftToNextCreation -= 0.8f * Time.deltaTime;
            if (WaterNextCreationTMP != null)
                WaterNextCreationTMP.text = (int)TimeLeftToNextCreation + "S";
            if (WaterValueTMP != null)
                WaterValueTMP.text = WaterVaule + "$";
        }
        else
        {
            if (WaterNextCreationTMP != null)
                WaterNextCreationTMP.text = (int)StartTimeLeftToNextCreation + "S";
            if (WaterValueTMP != null)
                WaterValueTMP.text = WaterVaule + "$";
        }

        if (TimeLeftToNextCreation <= 0)
        {
            GameObject Clone2 = Instantiate(WaterGameObj, new Vector3(this.transform.position.x , this.transform.position.y-2f, PlayerTrans.transform.position.z), Quaternion.identity);
            Clone2.transform.GetComponent<Rigidbody>().useGravity = true;
            StartTimeLeftToNextCreation += 3;
            TimeLeftToNextCreation = StartTimeLeftToNextCreation;

            WaterVaule++;
          //  startTimer = false;
            buttonPressed = false;
            WaterValueTMP.text = (int)WaterVaule + "$";
        }

        if (NotEnoughMoney)
        {
            TimerNotEnoughMoney -= 0.8f * Time.deltaTime;
            NotEnoughMoneyTMP.gameObject.SetActive(true);
            NotEnoughMoneyTMP.text = "You dont have enough MONEY!";
            if ((int)TimerNotEnoughMoney <= 0)
            {
                NotEnoughMoneyTMP.gameObject.SetActive(false);
                TimerNotEnoughMoney = 3;
                NotEnoughMoney = false;
            }

        }

    }


    void OnEnable()
    {

        WaterBuyButton.onClick.AddListener(MyFunction);//adds a listener for when you click the button

    }


    void MyFunction()// your listener calls this function
    {

        if (PlayerMoney.moneyCounter >= WaterVaule )
        {
            PlayerMoney.moneyCounter -= (int)WaterVaule;
            //StartTimerEnterFirstChallange.PlayerPassThrow = true;
            buttonPressed = true;

        }
        else
        {
            NotEnoughMoney = true;
       
        }

    }

}
