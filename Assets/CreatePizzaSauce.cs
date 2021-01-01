using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CreatePizzaSauce : MonoBehaviour
{


    public Button PizzaBuyButton;
    public GameObject PizzaGameObj;
    float TimeLeftToNextCreation = 10;
    float StartTimeLeftToNextCreation;
    [SerializeField] TextMeshProUGUI PizzaNextCreationTMP;
    [SerializeField] TextMeshProUGUI PizzaValueTMP;
    [SerializeField] TextMeshProUGUI NotEnoughMoneyTMP;
    bool startTimer;
    bool buttonPressed;
    float PizzaVaule;
    float TimerNotEnoughMoney;
    bool NotEnoughMoney;
    // Start is called before the first frame update
    void Start()
    {
        PizzaVaule = 3;
        StartTimeLeftToNextCreation = 10;
        startTimer = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer && buttonPressed)
        {
           
            TimeLeftToNextCreation -= 0.8f * Time.deltaTime;
            if (PizzaNextCreationTMP != null)
                PizzaNextCreationTMP.text = (int)TimeLeftToNextCreation + "S";
            if (PizzaValueTMP != null)
                PizzaValueTMP.text = PizzaVaule + "$";
        }
        else
        {
            if (PizzaNextCreationTMP != null)  
                PizzaNextCreationTMP.text = (int)StartTimeLeftToNextCreation + "S";
            if (PizzaValueTMP != null)
                PizzaValueTMP.text = PizzaVaule + "$";
            
        }

        if (TimeLeftToNextCreation <= 0)
        {
            GameObject Clone2 = Instantiate(PizzaGameObj, new Vector3(this.transform.position.x + 0.2f, this.transform.position.y - 2f, this.transform.position.z), Quaternion.identity);
            Clone2.transform.localRotation = Quaternion.Euler(0, 270, 0);
            Clone2.transform.GetComponent<Rigidbody>().useGravity = true;

            StartTimeLeftToNextCreation += 3;
            TimeLeftToNextCreation = StartTimeLeftToNextCreation;

            PizzaVaule++;
           // startTimer = false;
            buttonPressed = false;
            PizzaValueTMP.text = (int)PizzaVaule + "$";
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

        PizzaBuyButton.onClick.AddListener(MyFunction);//adds a listener for when you click the button

    }


    void MyFunction()// your listener calls this function
    {
        if (PlayerMoney.moneyCounter >= PizzaVaule)
        {
            PlayerMoney.moneyCounter -= (int)PizzaVaule;
            //StartTimerEnterFirstChallange.PlayerPassThrow = true;
            buttonPressed = true;

        }
        else
        {
            NotEnoughMoney = true;
        }

    }



}
