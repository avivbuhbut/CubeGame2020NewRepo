using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class createFlournew : MonoBehaviour
{


    public Transform PlayerTrans;
    public Button FlourBuyButton;
    public GameObject FlourGameObj;
   public float TimeLeftToNextCreation = 3;
  public  float StartTimeLeftToNextCreation;
    [SerializeField] TextMeshProUGUI FlourNextCreationTMP;
    [SerializeField] TextMeshProUGUI FlourValueTMP;
    [SerializeField] TextMeshProUGUI NotEnoughMoneyTMP;
    bool startTimer;
    bool buttonPressed;
   public static float FlourVaule=3;
    float TimerNotEnoughMoney;
    bool NotEnoughMoney;
    int playerMoneyUpdate;
    static int NineDollarCoutner = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerMoneyUpdate = 0;
       // FlourVaule = 3;
       // FlourVaule = 3;
        StartTimeLeftToNextCreation = 4;
        startTimer = true;

    }

    // Update is called once per frame
    void Update()
    {


      

        if (startTimer && buttonPressed || AutoBuy.AutoButton==true|| AutoBuyFlourNineDollars.boolAutoNineDollarButton && PlayerMoney.moneyCounter >= FlourVaule)
        {
            playerMoneyUpdate = 0;
                 TimeLeftToNextCreation -= 0.8f * Time.deltaTime;
            if (FlourNextCreationTMP != null)
                FlourNextCreationTMP.text = (int)TimeLeftToNextCreation + "S";
            if (FlourValueTMP != null)
                FlourValueTMP.text = FlourVaule + "$";
        }
        else 
        {
            if (FlourNextCreationTMP != null&& StartTimeLeftToNextCreation>0)
                FlourNextCreationTMP.text = (int)StartTimeLeftToNextCreation + "S";
            if (FlourValueTMP != null)
                FlourValueTMP.text = FlourVaule + "$";

        }

        if (TimeLeftToNextCreation <= 0 )
        {
            GameObject Clone2 = Instantiate(FlourGameObj, new Vector3(this.transform.position.x , this.transform.position.y - 1f, PlayerTrans.transform.position.z), Quaternion.identity);
          Clone2.transform.localRotation = Quaternion.Euler(-89.141f, 0, 0);
         //   Clone2.name = "Flour";

            if(StartTimeLeftToNextCreation!=3)
            StartTimeLeftToNextCreation -= 1;

            TimeLeftToNextCreation = StartTimeLeftToNextCreation;


        //    if (StartTimeLeftToNextCreation < 0)
           // {
            //    TimeLeftToNextCreation = 2;
           // }

            if (AutoBuy.AutoButton == true&&playerMoneyUpdate==0)
            {
                playerMoneyUpdate++;
                Debug.Log("Hereqweqwe");
                PlayerMoney.moneyCounter = PlayerMoney.moneyCounter - (int)FlourVaule;
                Debug.Log(playerMoneyUpdate);
             // FlourVaule++; 

            }


            // startTimer = false;
            buttonPressed = false;
            FlourValueTMP.text = (int)FlourVaule + "$";


            if (!(PlayerMoney.moneyCounter >= FlourVaule))
            AutoBuy.AutoButton = false;


            if (!(PlayerMoney.moneyCounter >= FlourVaule))
                AutoBuyFlourNineDollars.boolAutoNineDollarButton = false;


            if (AutoBuyFlourNineDollars.boolAutoNineDollarButton == true && (PlayerMoney.moneyCounter >= 9) && NineDollarCoutner <= 3)
            {
                Debug.Log("NineDollarCoutner" + NineDollarCoutner);
                NineDollarCoutner += 1;
                PlayerMoney.moneyCounter = PlayerMoney.moneyCounter - (int)FlourVaule;

                if (NineDollarCoutner == 3)
                {
                    AutoBuyFlourNineDollars.boolAutoNineDollarButton = false;
                    NineDollarCoutner = 0;
                }
            }
       
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

        FlourBuyButton.onClick.AddListener(MyFunction);//adds a listener for when you click the button

    }


    void MyFunction()// your listener calls this function
    {
        if (PlayerMoney.moneyCounter >= FlourVaule)
        {

        PlayerMoney.moneyCounter -= (int)FlourVaule;
            //StartTimerEnterFirstChallange.PlayerPassThrow = true;
            buttonPressed = true;

        }
        else
        {
            NotEnoughMoney = true;//asd
        }

    }





}

