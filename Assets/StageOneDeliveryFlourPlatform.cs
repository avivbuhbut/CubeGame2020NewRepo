using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class StageOneDeliveryFlourPlatform : MonoBehaviour
{
  //   public GameObject MoneyTrans;
public TextMeshPro MoneyValueTMP;
    public TextMeshPro DeliverdFlourTMP;
    //public Button CollectMoneyBTN;
    //public TextMeshPro CollectMoneyTMP;
   // [SerializeField] TextMeshProUGUI CollectMoneyTMP;
    //    public Image ButtonImage;
    int FlourDeliverdCounter;
    bool FlourHit;
    int FlourValue = 0;
    public static int numberOfFourHit = 0;
    GameObject Clone;
    int MoneyValue = 4;
    bool PressedButton;
    Color ButtonTMPOriginalColor;
    // Start is called before the first frame update
    void Start()
    {
        // this.CollectMoneyBTN.transform.GetComponent<Image>().material.color = Color.white;

        //ButtonTMPOriginalColor = CollectMoneyTMP.color;
        //CollectMoneyBTN.gameObject.SetActive(false);
       // MoneyTrans.gameObject.SetActive(false);
        GetComponent<add4DollarPlayer>().MoneyValue = 4;
    }

    // Update is called once per frame
    void Update()
    {
        //   if (numberOfFourHit == 5)
        //   {
        //      MoneyValue += 1;
        ///      numberOfFourHit = 0;

        //   }
        // Debug.Log(" Money Value For Flour: " + GetComponent<add4DollarPlayer>().MoneyValue);
        //  MoneyValueTMP.text = add4DollarPlayer.MoneyValue + "$";

        //Create Money
        /*
        if (FlourHit )
        {
     
            Clone = Instantiate(MoneyTrans, new Vector3(this.transform.position.x, this.transform.position.y + 1.5f, this.transform.position.z), Quaternion.identity);
            Clone.transform.localRotation = Quaternion.Euler(0, 270, 0);
           
                        // FlourValue--;
                        FlourHit = false;
        }
        if (Clone != null)
        {

            Clone.GetComponent<add4DollarPlayer>().MoneyValue = MoneyValue;
         
            Clone.GetComponentInChildren<TextMeshPro>().text = MoneyValue + "$";
        }*/

        if (numberOfFourHit < 10)
        {
            //CollectMoneyBTN.gameObject.SetActive(false);
            DeliverdFlourTMP.text = "Deliverd \n\n" + "     " + numberOfFourHit + "/3 ";
        }

        if (numberOfFourHit == 10)
        {
           // CollectMoneyBTN.gameObject.SetActive(true);
          //  CollectMoneyTMP.color = Color.Lerp(Color.white, Color.red, Mathf.PingPong(Time.time, 1));

            numberOfFourHit = 10;
            DeliverdFlourTMP.color = Color.green;
            DeliverdFlourTMP.text = "Deliverd \n\n" + "     " + numberOfFourHit + "/3 ";
        }


        if (PressedButton)
        {
           // CollectMoneyBTN.gameObject.SetActive(false);

        }


    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Flour" || collision.transform.name == "Flour 1(Clone)" ||
            collision.transform.name == "Flour")
        {
            numberOfFourHit++;
            if(collision.transform.GetComponent<RainDamage>().ValueFlourZero==false &&
                collision.transform.GetComponent<RainDamage>().ValueFlourOne == false)
            PlayerMoney.moneyCounter += 2;


            if (collision.transform.GetComponent<RainDamage>().ValueFlourOne)
                PlayerMoney.moneyCounter += 1;

            FlourHit = true;
            //FlourValue = PizzaValue.pizzaValue;

            //    StartTimerEnterFirstChallange.PlayerPassThrow = false;
            collision.transform.gameObject.SetActive(false);
//MoneyTrans.gameObject.SetActive(true);


        }
    }


    void OnCollisionExit(Collision collision)
    {

    }


    void OnEnable()
    {
        // if((int)GetComponent< createFlournew>().TimeLeftToNextCreation==0&& )
      //  CollectMoneyBTN.onClick.AddListener(CollectMoney);//adds a listener for when you click the button


    }


    void CollectMoney()// your listener calls this function
    {
        if (PressedButton == false)
        {
            PlayerMoney.moneyCounter += 100;
            PressedButton = true;
        }

    }
}
