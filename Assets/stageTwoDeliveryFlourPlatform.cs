using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class stageTwoDeliveryFlourPlatform : MonoBehaviour
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

        GetComponent<add4DollarPlayer>().MoneyValue = 4;
    }


    void Update()
    {


        if (numberOfFourHit < 10)
        {
            //CollectMoneyBTN.gameObject.SetActive(false);
            DeliverdFlourTMP.text = "Deliverd \n\n" + "     " + numberOfFourHit + "/6 ";
        }

        if (numberOfFourHit == 10)
        {
            // CollectMoneyBTN.gameObject.SetActive(true);
            //  CollectMoneyTMP.color = Color.Lerp(Color.white, Color.red, Mathf.PingPong(Time.time, 1));

            numberOfFourHit = 10;
            DeliverdFlourTMP.color = Color.green;
            DeliverdFlourTMP.text = "Deliverd \n\n" + "     " + numberOfFourHit + "/6 ";
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
            if (collision.transform.GetComponent<RainDamage>().ValueFlourZero == false &&
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
}
