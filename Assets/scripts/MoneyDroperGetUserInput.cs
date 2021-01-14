using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MoneyDroperGetUserInput : MonoBehaviour
{

    public Button LoadMoneyBtn;

    [SerializeField] TextMeshProUGUI MoneyDroperValueTMP;
    [SerializeField] TextMeshProUGUI CreationMoneyTimeTMP;
    public GameObject MoneyGamObj;
    //  public InputField UserInputField;
    public TMP_InputField UserInputField;
    public static bool buttonPreesed;
    public static bool userInputDONE;
    float TimeLeftToNextCreation = 3;
    int amountOfMoneyUserEnter;
    bool wasInside;
    // Start is called before the first frame update
    void Start()
    {
     
        MoneyDroperValueTMP.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonPreesed && amountOfMoneyUserEnter!= 0)
        {
            wasInside = true;
                TimeLeftToNextCreation -= 0.8f * Time.deltaTime;
           
            CreationMoneyTimeTMP.text = (int)TimeLeftToNextCreation + "S";
            if ((int)TimeLeftToNextCreation <= 0)
            {
                UserInputField.enabled = false;
               // CreationMoneyTimeTMP.gameObject.SetActive(false);

                GameObject Clone2 = Instantiate(MoneyGamObj, new Vector3(this.transform.position.x, this.transform.position.y - 5f, this.transform.position.z+0.5f), Quaternion.identity);
                    Clone2.transform.localRotation = Quaternion.Euler(0, 270, 0);
                   
                
                amountOfMoneyUserEnter--;
                TimeLeftToNextCreation = 3;
                CreationMoneyTimeTMP.text = (int)TimeLeftToNextCreation + "S";

            }
         
        }
       
        
        if(amountOfMoneyUserEnter ==0 && wasInside==true)
        {
            UserInputField.enabled = true;
            TimeLeftToNextCreation = 3;
            buttonPreesed = false;
            wasInside = false;
       


        }
    }

    void OnEnable()
    {

        LoadMoneyBtn.onClick.AddListener(MyFunction);//adds a listener for when you click the button

    }


    void MyFunction()// your listener calls this function
    {
        if(int.Parse(UserInputField.text)<= PlayerMoney.moneyCounter&& PlayerMoney.moneyCounter>0)
        {
            amountOfMoneyUserEnter = int.Parse(UserInputField.text);
            userInputDONE = true;
            buttonPreesed = true;
            MoneyDroperValueTMP.text = UserInputField.text;
            MoneyDroperValueTMP.gameObject.SetActive(true);

            PlayerMoney.moneyCounter-= int.Parse(UserInputField.text);
            MoneyDroperValueTMP.text = UserInputField.text +  "$";
            CreationMoneyTimeTMP.gameObject.SetActive(true);
            //  PlayerMoney.moneyCounter -= (int)FlourVaule;
            //StartTimerEnterFirstChallange.PlayerPassThrow = true;


        }
     

    }
}
